#include <gb/gb.h>
#include <gb/cgb.h>
#include <stdio.h>
#include "GameCharacter.c"
#include "GameSprites.h"
#include "Title_Screen_map.c"
#include "Title_Screen_data.c"
#include "Game_Over_map.c"
#include "Game_Over_data.c"
#include "Win_Screen_map.c"
#include "Win_Screen_data.c"
#include "Level1.h"
#include "Level2.h"
#include "Level3.h"
#include "LevelTiles.h"
#include "HUD.c"

//Creates and initialises all relevant global variables
struct GameCharacter player;
UBYTE spritesize = 8;
BYTE jumping;
UINT8 gravity = (3 + (5/10));
UINT8 spawnY = 110;
UINT8 spawnX = 10;
UINT8 i;
UINT8 walkAnimFrames = 4;
UINT8 idleAnimFrames = 2;
UINT8 currentIdleFrame = 0;
UINT8 currentWalkFrame = 2;
UINT8 state;
BYTE flipped = 0;
BYTE slipping = 0;
UINT8 gameState = 0;
UINT8 currentLevel = 1;

//Creates an array used by the collision functions to determine which tiles have actions tied to them
const char tileMap[4] = {0x00, 0x01, 0x12, 0x14};

//Creates an array to store a colour palette for the menus 
const UWORD menuPalette[] = 
{
     RGB_LIGHTGRAY, RGB_GREEN, RGB_DARKGRAY, RGB_DARKGREEN
};

//Creates an array to store a colour palette for the levels
const UWORD levelPalette[] =
{
 LevelTilesCGBPal0c0,
 LevelTilesCGBPal0c1,
 LevelTilesCGBPal0c2,
 LevelTilesCGBPal0c3,

 LevelTilesCGBPal1c0,
 LevelTilesCGBPal1c1,
 LevelTilesCGBPal1c2,
 LevelTilesCGBPal1c3,

 LevelTilesCGBPal2c0,
 LevelTilesCGBPal2c1,
 LevelTilesCGBPal2c2,
 LevelTilesCGBPal2c3,

 LevelTilesCGBPal3c0,
 LevelTilesCGBPal3c1,
 LevelTilesCGBPal3c2,
 LevelTilesCGBPal3c3,

 LevelTilesCGBPal4c0,
 LevelTilesCGBPal4c1,
 LevelTilesCGBPal4c2,
 LevelTilesCGBPal4c3,

 LevelTilesCGBPal5c0,
 LevelTilesCGBPal5c1,
 LevelTilesCGBPal5c2,
 LevelTilesCGBPal5c3,

 LevelTilesCGBPal6c0,
 LevelTilesCGBPal6c1,
 LevelTilesCGBPal6c2,
 LevelTilesCGBPal6c3,

 LevelTilesCGBPal7c0,
 LevelTilesCGBPal7c1,
 LevelTilesCGBPal7c2,
 LevelTilesCGBPal7c3
};

//Creates an array to store a colour palette for the player sprite
const UWORD spritePalette[] = 
{
    GameSpritesCGBPal0c0,
    GameSpritesCGBPal0c1,
    GameSpritesCGBPal0c2,
    GameSpritesCGBPal0c3,
};

//A function to create a more accurate 'delay' functionality, relying on how many times the screen has been drawn
void performantDelay(UINT8 numloops){
    UINT8 i;
    for(i = 0; i < numloops; i++){
        wait_vbl_done();
    }     
}

//A function used to initialise the game after restarting from death
void initialiseGame()
{
    currentLevel = 1;
    gameState = 1;
    player.health = 3;
    player.currentFriction = 2;
    slipping = 0;
}

//A function used to check the current state of the 'currentLevel' variable, and switch the currently displayed level accordingly
void switchMap()
{
    if(currentLevel == 1)
    {
            VBK_REG = 1;
            set_bkg_tiles(0, 0, Level2Width, Level2Height, Level2PLN1);
            VBK_REG = 0;
            set_bkg_tiles(0, 0, Level2Width, Level2Height, Level2PLN0);
            currentLevel = currentLevel + 1;
    }

    else if(currentLevel == 2)
    {
            VBK_REG = 1;
            set_bkg_tiles(0, 0, Level3Width, Level3Height, Level3PLN1);
            VBK_REG = 0;
            set_bkg_tiles(0, 0, Level3Width, Level3Height, Level3PLN0);
            player.currentFriction = 2;
            slipping = 0;
            currentLevel = currentLevel + 1;
    }
    else if(currentLevel == 3)
    {
        gameState = 2; //State 2 is the 'win state', active only when the player reaches the end of level 3 successfully
    }
}

//A function to determine if the player is at the left edge of the screen, in order to prevent them from leaving the screen
UBYTE isLeftEdgeOfScreen(UINT8 x){
    return x==8;
}

//A function to determine if the player is currently touching the ground. If they are touching the ground, the function determines 
//the player is colliding with and where the collision is happening. 
UBYTE isTouchingGround(struct GameCharacter* character)
{
    UBYTE bottomLeftPixelTouching;
    UBYTE bottomRightPixelTouching; 

    UBYTE middleRightPixelTouching;
    UBYTE middleLeftPixelTouching;

    UBYTE topLeftPixelTouching;
    UBYTE topRightPixelTouching;

    UBYTE hazard;  
    UBYTE levelEnd; 
    UBYTE ice;

    UINT16 indexBLx, indexBLy, tileindexBL;
    UINT16 indexBRx, indexBRy, tileindexBR;
    UINT16 indexTLx, indexTLy, tileindexTL;
    UINT16 indexTRx, indexTRy, tileindexTR;
    UINT16 indexMLx, indexMLy, tileindexML;
    UINT16 indexMRx, indexMRy, tileindexMR;

    //Bottom Left Pixel of the sprite
    indexBLx = (character->x - 8) / 8;
    indexBLy = (character->y + character->height - 16) / 8; 
    tileindexBL = 20 * indexBLy + indexBLx;
    
    //Bottom Right Pixel of the sprite
    indexBRx = (character->x - 1) / 8;
    indexBRy = (character->y + character->height - 16) / 8; 
    tileindexBR = 20 * indexBRy + indexBRx;

    //Top Left Pixel of the sprite
    indexTLx = (character->x - 8) / 8;
    indexTLy = (character->y + character->height - 24) / 8; 
    tileindexTL = 20 * indexTLy + indexTLx;
    
    //Top Right Pixel of the sprite
    indexTRx = (character->x - 1) / 8;
    indexTRy = (character->y + character->height - 24) / 8; 
    tileindexTR = 20 * indexTRy + indexTRx;

    //Middle Left Pixel of the sprite
    indexMLx = (character->x - 9) / 8;
    indexMLy = (character->y + character->height - 20) / 8; 
    tileindexML = 20 * indexMLy + indexMLx;
    
    //Middle Right Pixel of the sprite
    indexMRx = (character->x) / 8;
    indexMRy = (character->y + character->height - 20) / 8; 
    tileindexMR = 20 * indexMRy + indexMRx;  
    
    //Collision map and checks for level 1
    if(currentLevel == 1)
    {
        bottomLeftPixelTouching = Level1[tileindexBL] != tileMap[0]; 
        bottomRightPixelTouching = Level1[tileindexBR] != tileMap[0];

        middleLeftPixelTouching = Level1[tileindexML] != tileMap[0];
        middleRightPixelTouching = Level1[tileindexMR] != tileMap[0]; 

        topLeftPixelTouching = Level1[tileindexTL] != tileMap[0];
        topRightPixelTouching = Level1[tileindexTR] != tileMap[0];
        
        hazard = Level1[tileindexBL] == tileMap[1];
        levelEnd = Level1[tileindexBL] == tileMap[2];
       
    }

    //Collision map and checks for level 2
    else if(currentLevel == 2)
    {
        bottomLeftPixelTouching = Level2[tileindexBL] != tileMap[0]; 
        bottomRightPixelTouching = Level2[tileindexBR] != tileMap[0];

        middleLeftPixelTouching = Level2[tileindexML] != tileMap[0];
        middleRightPixelTouching = Level2[tileindexMR] != tileMap[0]; 

        topLeftPixelTouching = Level2[tileindexTL] != tileMap[0];
        topRightPixelTouching = Level2[tileindexTR] != tileMap[0];


        hazard = Level2[tileindexBL] == tileMap[1];
        levelEnd = Level2[tileindexBL] == tileMap[2];
        ice = Level2[tileindexBL] == tileMap[3];
    }

    //Collision map and checks for level 3
    else if(currentLevel == 3)
    {
        bottomLeftPixelTouching = Level3[tileindexBL] != tileMap[0]; 
        bottomRightPixelTouching = Level3[tileindexBR] != tileMap[0];

        middleLeftPixelTouching = Level3[tileindexML] != tileMap[0];
        middleRightPixelTouching = Level3[tileindexMR] != tileMap[0]; 

        topLeftPixelTouching = Level3[tileindexTL] != tileMap[0];
        topRightPixelTouching = Level3[tileindexTR] != tileMap[0];


        hazard = Level3[tileindexBL] == tileMap[1];
        levelEnd = Level3[tileindexBL] == tileMap[2];
        ice = Level3[tileindexBL] == tileMap[3];
    }


    //Checks for ML and MR pixel collision, to prevent clipping inside platforms from the sides
    if(middleLeftPixelTouching)
    {
        player.velocityX = 0;
        player.x = player.x + 1;
    }

    else if(middleRightPixelTouching)
    {
        player.velocityX = 0;
        player.x = player.x - 1;
    }


    //Checks for BL and BR pixel collision, to keep the player from sinking into the floor
    if(bottomLeftPixelTouching || bottomRightPixelTouching)
    {
        if(character->velocityY != -10){
            character->velocityY = 0;
            character->isJumping = 0;
        }
    }

    //Checks for TL and TR pixel collision, to keep the player clipping through the platforms from the bottom
    else if(topLeftPixelTouching || topRightPixelTouching)
    {
        if(character->velocityY > 0)
        {
            character->velocityY = 0;
        }
        character->velocityY += gravity;
    }

    


    
    //Checks for if the player hits a hazardous tile
    if(hazard)
    {
       player.health = player.health - 1;
       player.y = spawnY;
       player.x = spawnX;

        NR41_REG = 0x1F;
        NR42_REG = 0xF1;
        NR43_REG = 0x30;
        NR44_REG = 0xC0; 

        player.isJumping = 1;
    }

    //Checks for if the player hits a levelEnd tile
    if(levelEnd)
    {
       switchMap();

        player.x = spawnX;
        player.y = spawnY;

        if(player.health < player.healthCap)
        {
            player.health = player.health + 1;
        }
    }

    //Checks, specifically for level 2, to see if the player is on Ice, which creates movement with ice physics
    if(ice && currentLevel == 2)
    {
        player.currentFriction = 0;
        slipping = 1;
    }
    

    return hazard;
}

//A function to move the player depending on which button they press
void moveCharacter(struct GameCharacter* character){
    UBYTE hasmoved = 0;

    if(character->velocityX!=0 && !(character->velocityX<0 && isLeftEdgeOfScreen(character->x)))
    { 
        character->x += character->velocityX;
        character->velocityX += (character->velocityX>0?-character->currentFriction:character->currentFriction);
        hasmoved = 1;
    }

    if(character->velocityY > 4)
    {
        
        character->velocityY = 4; 
    }

    if(!isTouchingGround(character) || character->velocityY < 0)
    {

        character->y += character->velocityY;
        character->velocityY += gravity;
        hasmoved = 1;

    }

    
    if(hasmoved) {
        move_sprite(player.spriteids[0], player.x, player.y);
    }
}

//A function to initialise the player character using values from a structure made in a separate file
void setupPlayer()
{
    player.x = spawnX;
    player.y = spawnY;
    player.width = 8;
    player.height = 8;
    player.isJumping = 0;
    player.currentFriction = 2;
    player.healthCap = 3;
    player.health = player.healthCap;

    set_sprite_tile(0,0);
    set_sprite_prop(0,0);
    player.spriteids[0] = 0;

    move_sprite(player.spriteids[0], player.x, player.y);
}


//The main function, which runs when the game has been launched
void main()
{
    //Initialises sound registers
   NR52_REG = 0x80; 
   NR50_REG = 0x77;
   NR51_REG = 0xFF;

    SHOW_BKG;
    DISPLAY_ON;

//The 'game loop'. An infinite loop that will run until the program has been terminated
while(1)
{
    //Within this conditional statement is all actions required to be performed while in 'state 0'
    if(gameState == 0) //Game State 0 is main menu state, the default for when the game is launched
    {
        set_bkg_palette(0, 1, &menuPalette[0]);

        set_bkg_data(0, 203, Title_Screen_data);
        set_bkg_tiles(0, 0, 20, 18, Title_Screen_map);

        waitpad(J_START);
        gameState = 1;
        setupPlayer();
    }
    




    
    //Within this conditional statement is all of the actions required to be performed while in 'state 1'
   else if(gameState == 1) //Game State 1 houses the main game
    {
        if(currentLevel == 1)
        {
            set_bkg_palette(0, 3, &levelPalette[0]);
            set_bkg_data(0, 23, LevelTiles);
            VBK_REG = 1;
            set_bkg_tiles(0, 0, Level1Width, Level1Height, Level1PLN1);
            VBK_REG = 0;
            set_bkg_tiles(0, 0, Level1Width, Level1Height, Level1PLN0);
        }
    set_sprite_palette(0, 1, &spritePalette[0]);
    set_sprite_data(0, 7, GameSprites);
    
    move_win(7, 135);

    SHOW_SPRITES;
    SHOW_WIN;
    

  
         if(player.x >= 160)
         {
            player.x = 159;
         }

        if(player.x <= 8)
         {
            player.x = 8;
         }

         if(state == 0)
         {
            set_sprite_tile(0, 0); 
         } 

         else if(state == 1)
         {
            if(currentWalkFrame == 5)
            {
                currentWalkFrame = 2;
            }
            
            else
            {
                currentWalkFrame = currentWalkFrame + 1;
            }

            set_sprite_tile(0, currentWalkFrame);

            delay(50);
         }

         else if(state == 2)
         {
            set_sprite_tile(0,6);
         }


        
         //Handles the player's health and updates the HUD accordingly
        if(player.health == 3)
        {
            set_win_tiles(0,0,9,1,maxHealth);
            player.healthCap = 3;
        }
        else if(player.health == 2)
        {
            set_win_tiles(0,0,9,1,halfHealth);
        }
        else if(player.health == 1)
        {
            set_win_tiles(0,0,9,1,lowHealth);
        }
        else
        {
            gameState = 3;
        }
      



      if((joypad() & J_A) && player.isJumping == 0)
      {
        state = 2;
           player.velocityY = -10;
           player.isJumping = 1;
            NR10_REG = 0x16; 
            NR11_REG = 0x40;
            NR12_REG = 0x73;  
            NR13_REG = 0x00;   
            NR14_REG = 0xC3;
        }

        if(joypad() & J_LEFT)
        {
            //if not flipped, don't flip
            //if already flipped, unflip
            set_sprite_prop(0, S_FLIPX);

            if(player.isJumping == 0)
            {
                if(slipping == 0)
                {
                    state = 1;
                }
            }
            player.velocityX = -2;
            
        }

        if(joypad() & J_RIGHT)
        {
            
            //if already flipped, don't flip
            //if not flipped, flip
            set_sprite_prop(0, get_sprite_prop(0) & ~S_FLIPX);

            if(player.isJumping == 0)
            {
                if(slipping == 0)
                {
                    state = 1;
                } 
            }
            player.velocityX = 2;
           
        }

        if(!joypad() && player.isJumping == 0)
        {
            state = 0;
        }

        moveCharacter(&player);
        isTouchingGround(&player);
        performantDelay(2);
     }

    //Within this conditional statement is all of the actions required to be performed while in 'state 2'
    else if(gameState == 2) //Game state 2 is the win state
    {
        set_bkg_palette(0, 1, &levelPalette[4]);

        set_bkg_data(0, 96, Win_Screen_data);
        set_bkg_tiles(0, 0, 20, 18, Win_Screen_map);
        
        HIDE_WIN;
        HIDE_SPRITES;
    }

   //Within this conditional statement is all of the actions required to be performed while in 'state 3'
   else if(gameState == 3) //Game state 3 is the lose state
    {
        set_bkg_palette(0, 1, &levelPalette[4]);
        set_bkg_data(0, 78, Game_Over_data);
        set_bkg_tiles(0, 0, 20, 18, Game_Over_map);
 
        HIDE_WIN;
        HIDE_SPRITES;

        waitpad(J_START);

        initialiseGame();
        
    }
}
}

#include <gb/gb.h>

struct GameCharacter
{
    UBYTE spriteids[1];
    UINT8 x;
    UINT8 y;
    UINT8 width;
    UINT8 height;
    UBYTE isJumping;
    INT8 velocityX;
    INT8 velocityY;
    INT8 currentFriction;
    INT8 health;
    INT8 healthCap;
};
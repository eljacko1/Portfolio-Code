using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;

public class ClueSystem : MonoBehaviour
{
    Stopwatch sw = new Stopwatch();
    int[][] reagents = new int[3][]; //Jagged Array containing reagent catergories and their variants
    int[][] clues = new int[3][]; //Jagged Array containing clue catergories and their variants

    int[,] reagentGrid = new int[9, 9]; //2D array creating a 9x9 grid for reagents and clues

    private List<int> selectedClues = new List<int>(); //List for selected clues
    private List<int> selectedReagents = new List<int>(); //List for selected reagents
    private List<int> remainingClues; //List for remaining clues (initially contains 3 indexes for each clue, but is slowly cut down to only be the remaining clues

    private List<int> clueIndex;

    int clueConfig; //Clue configuration value, to determine which catergory will have a singleton value
    bool validIndex = false;

    public int[] selectedCluesReference = new int[5]; //Array containing the 5 selected clues for later use
    [SerializeField] public int[] scores = new int[9]; //Array containing the 9 score values, 1 for each reagent
    private int[,] reagentReference = new int[9,3]; //Jagged array containing the reagents and clues that point to them
    private int[,] clueReference = new int[9,3]; 

    void Start()
    {
        //for(int i = 0; i < 10; i++)
        //{

        CreateLists();
        SelectReagents();
        ClueConfiguration();
        GenerateReagents();
        CheckValues();
        //print(sw.ElapsedMilliseconds);
        //GenerateGrid();
        //TestTextFile();
        //}
    }

    public void SelectCluesAgain()
    {
        sw.Start();
        PurgeLists();
        CreateLists();
        SelectReagents();
        ClueConfiguration();
        GenerateReagents();
        CheckValues();
        sw.Stop();
    }
    //Initialises the values within the Jagged arrays 'reagents', 'clues' and 'reagentReference'
    private void CreateLists()
    {
        reagents[0] = new int[] { 0, 1, 2 }; //Berries
        reagents[1] = new int[] { 3, 4, 5 }; //Feathers
        reagents[2] = new int[] { 6, 7, 8 }; //Horns

        clues[0] = new int[] { 0, 1, 2 }; //Dead Plants
        clues[1] = new int[] { 3, 4, 5 }; //Rock Marks
        clues[2] = new int[] { 6, 7, 8 }; //Thorns

        remainingClues = new List<int>
        {
        0, 0, 0,
        1, 1, 1,
        2, 2, 2,
        3, 3, 3,
        4, 4, 4,
        5, 5, 5,
        6, 6, 6,
        7, 7, 7,
        8, 8, 8
        };

        clueIndex = new List<int> { 0, 1, 2 };
    }

    //Function which randomly selects 1 reagent variant from each catergory
    private void SelectReagents()
    {
        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, 3);
            selectedReagents.Add(reagents[i][index]);
        }
    }

    //Function which randomly selects the clue configuration for later use
    private void ClueConfiguration()
    {
        int clueConfig = 0;//Random.Range(0, 3); // Random.Range(0, 3);
        SelectClues(clueConfig);
    }

    //Function which randomly selects 5 clues based on the earlier selected configuration
    //Other than the singleton, all the clues that are selected are added to the 'selected clue' list twice, for easier use later
    private void SelectClues(int clueConfig)
    {
        //Configuration 1: Singleton in catergory 3
        if (clueConfig == 0)
        {
            //Selecting first clue from category 1
            int index = Random.Range(0, 3);

            selectedClues.Add(clues[0][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[0][index]));

            selectedClues.Add(clues[0][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[0][index]));

            selectedCluesReference[0] = clues[0][index];


            while (validIndex == false)
            {
                index = Random.Range(0, 3);

                if (!selectedClues.Contains(clues[0][index]))
                {
                    validIndex = true;
                }
                else
                {
                    validIndex = false;
                }
            }

            selectedClues.Add(clues[0][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[0][index]));

            selectedClues.Add(clues[0][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[0][index]));

            selectedCluesReference[1] = clues[0][index];

            validIndex = false;

            //Selecting first clue from category 2
            index = Random.Range(0, 3);

            selectedClues.Add(clues[1][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[1][index]));

            selectedClues.Add(clues[1][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[1][index]));

            selectedCluesReference[2] = clues[1][index];

            //Selecting second clue from category 2
            while (validIndex == false)
            {
                index = Random.Range(0, 3);

                if (!selectedClues.Contains(clues[1][index]))
                {
                    validIndex = true;
                }
                else
                {
                    validIndex = false;
                }
            }

            selectedClues.Add(clues[1][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[1][index]));

            selectedClues.Add(clues[1][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[1][index]));


            selectedCluesReference[3] = clues[1][index];

            //Selecting singleton clue from category 3
            index = Random.Range(0, 3);
            selectedClues.Add(clues[2][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[2][index]));

            selectedCluesReference[4] = clues[2][index];
        }

        //Configuration 2: Singleton in catergory 2
        else if (clueConfig == 1)
        {
            //Selecting first clue from category 1
            int index = Random.Range(0, 3);

            selectedClues.Add(clues[0][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[0][index]));

            selectedClues.Add(clues[0][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[0][index]));


            while (validIndex == false)
            {
                index = Random.Range(0, 3);

                if (!selectedClues.Contains(clues[0][index]))
                {
                    validIndex = true;
                }
                else
                {
                    validIndex = false;
                }
            }

            selectedClues.Add(clues[0][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[0][index]));

            selectedClues.Add(clues[0][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[0][index]));

            validIndex = false;

            //Selecting first clue from category 3
            index = Random.Range(0, 3);

            selectedClues.Add(clues[2][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[2][index]));

            selectedClues.Add(clues[2][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[2][index]));

            //Selecting second clue from category 3
            while (validIndex == false)
            {
                index = Random.Range(0, 3);

                if (!selectedClues.Contains(clues[2][index]))
                {
                    validIndex = true;
                }
                else
                {
                    validIndex = false;
                }
            }

            selectedClues.Add(clues[2][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[2][index]));

            selectedClues.Add(clues[2][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[2][index]));

            //Selecting singleton clue from category 2
            index = Random.Range(0, 3);
            selectedClues.Add(clues[1][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[1][index]));
        }

        //Configuration 3: Singleton in catergory 1
        else if (clueConfig == 2)
        {
            //Selecting first clue from category 2
            int index = Random.Range(0, 3);

            selectedClues.Add(clues[1][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[1][index]));

            selectedClues.Add(clues[1][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[1][index]));

            //Selecting second clue from category 2
            while (validIndex == false)
            {
                index = Random.Range(0, 3);

                if (!selectedClues.Contains(clues[1][index]))
                {
                    validIndex = true;
                }
                else
                {
                    validIndex = false;
                }
            }

            selectedClues.Add(clues[1][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[1][index]));

            selectedClues.Add(clues[1][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[1][index]));

            validIndex = false;

            //Selecting first clue from category 3
            index = Random.Range(0, 3);

            selectedClues.Add(clues[2][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[2][index]));

            selectedClues.Add(clues[2][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[2][index]));

            //Selecting second clue from category 3
            while (validIndex == false)
            {
                index = Random.Range(0, 3);

                if (!selectedClues.Contains(clues[2][index]))
                {
                    validIndex = true;
                }
                else
                {
                    validIndex = false;
                }
            }

            selectedClues.Add(clues[2][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[2][index]));

            selectedClues.Add(clues[2][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[2][index]));

            //Selecting singleton clue from category 1
            index = Random.Range(0, 3);
            selectedClues.Add(clues[0][index]);
            remainingClues.RemoveAt(remainingClues.IndexOf(clues[0][index]));
        }

        //selectedCluesReference = selectedClues.ToArray();
        //foreach (int clue in selectedClues)
        //{
        //    print("True Clue is " + clue);
        //}
    }

    private int LoopIndex(float index, int indexLimit)
    {
        if (index >= indexLimit)
        {
            return Mathf.RoundToInt(index - indexLimit);
        }
        else if (index < 0)
        {
            return Mathf.RoundToInt(index + indexLimit);
        }
        else
        {
            return Mathf.RoundToInt(index);
        }
    }

    int[] SelectRandom(List<int> list, int count)
    {
        int[] returnValue = new int[6];
        for (int i = 0; i < count; i++)
        {
            int randomNumber = Random.Range(0, list.Count);
            returnValue[i] = list[randomNumber];
            list.RemoveAt(randomNumber);
        }

        return returnValue;
    }

    int CheckRepeat(List<int> list)
    {
        int index = 0;

        while(list[index] != list[index+1])
        {
            index++;
        }

        return index;

    }

    //Function which generates the reagents and clues in accordance to the conditions
    private void GenerateReagents()
    {
        int[] howManyCluesDoesReagentHave = new int[9];

        List<int> leftOverReagents = new List<int>();
        List<int> goodClues = new List<int>(6);
        for(int i = 0; i < 9; i++)
        {
            if(!selectedReagents.Contains(i))
            {
                leftOverReagents.Add(i);
            }
        }
        foreach(int clue in remainingClues)
        {
            if(selectedClues.Contains(clue))
            {
                goodClues.Add(clue);
                //print("GOOD CLUE IS " + clue);
            }
        }
        foreach (int clue in goodClues)
        {
            if (remainingClues.Contains(clue))
            {
                remainingClues.Remove(clue);
            }  
        }
        int x = 0;

        int[] randomReagents = SelectRandom(leftOverReagents, 6);
        int randomClueMod = Random.Range(0, 2) * 6;
        for(int i = 0; i < 6; i++)
        {
            int reagent = randomReagents[i];
            int clue = remainingClues[randomClueMod];
            remainingClues.RemoveAt(randomClueMod);
            reagentGrid[reagent, clue] = 1;
            //print("Reagent " + reagent + "gets clue " + clue);
        }

        for (int i = 0; i < 9; i++)
        {
            if (!selectedReagents.Contains(i))
            {
                leftOverReagents.Add(i);
            }
        }
        randomClueMod = 0;
        randomReagents = SelectRandom(leftOverReagents, 6);
        for (int i = 0; i < 4; i++)
        {
            int reagent = randomReagents[i];
            int clue = remainingClues[randomClueMod];
            remainingClues.RemoveAt(randomClueMod);
            reagentGrid[reagent, clue] = 1;
            //print("Reagent " + reagent + "gets clue " + clue);
        }
        for (int i = 0; i < 2; i++)
        {
            int reagent = randomReagents[i];
            int clue = remainingClues[randomClueMod];
            remainingClues.RemoveAt(randomClueMod);
            reagentGrid[reagent, clue] = 1;
            // print("Reagent " + reagent + "gets clue " + clue);
        }

        int j = CheckRepeat(goodClues);
        for (int i = 2; i < 4; i++)
        {
            int reagent = randomReagents[i];
            int clue = goodClues[j];
            goodClues.RemoveAt(j);
            j = LoopIndex(Random.Range(1, goodClues.Count)+j, goodClues.Count);
            
            reagentGrid[reagent, clue] = 2;
            //print("Reagent " + reagent + "gets clue " + clue);
        }
        for (int i = 4; i < 6; i++)
        {
            j = 0;
            int reagent = randomReagents[i];
            int clue = goodClues[j];

            reagentGrid[reagent, clue] = 2;
            //print("Reagent " + reagent + "gets clue " + clue);

            j++;

            clue = goodClues[j];

            reagentGrid[reagent, clue] = 2;
            //print("Reagent " + reagent + "gets clue " + clue);
            goodClues.RemoveAt(j-1);
            goodClues.RemoveAt(j-1);
        }
      

        ////////////////////////////////////////////////////////////////////////////////////////////////
        x = Random.Range(0, 3); //1
        for (int i = 0; i < 3; i++)
        {
            int y = Random.Range(0, 4 - i) * 2; //4
            reagentGrid[selectedReagents[x], selectedClues[y]] = 2;
            //print("Reagent " + selectedReagents[x] + "gets clue " + selectedClues[y]);
            howManyCluesDoesReagentHave[selectedReagents[x]] += 1;

            int storage = LoopIndex(x + Random.Range(1, 3) * Mathf.RoundToInt((Random.Range(0, 2) - 0.5f) * 2), 3);
            //print("STORAGE IS " + storage);
            //print("GETS HERE 1");
            if (howManyCluesDoesReagentHave[selectedReagents[storage]] == 2)
            {
                //print("GETS HERE 2");
                int leftOver = 0;
                //leftOver = x == leftOver ? LoopIndex(leftOver+1, 3) : leftOver;
                //leftOver = storage == leftOver ? LoopIndex(leftOver+1, 3) : leftOver;
                while(leftOver == x || leftOver == storage)
                {
                   leftOver = LoopIndex(leftOver + 1, 3);
                }


                reagentGrid[selectedReagents[leftOver], selectedClues[y + 1]] = 2;
                //print("Reagent " + selectedReagents[leftOver] + "gets clue " + selectedClues[y + 1]);
                howManyCluesDoesReagentHave[selectedReagents[leftOver]] += 1;
            }
            else
            {
                //print("GETS HERE 3");
                reagentGrid[selectedReagents[storage], selectedClues[y + 1]] = 2;
                //print("Reagent " + selectedReagents[storage] + "gets clue " + selectedClues[y + 1]);
                howManyCluesDoesReagentHave[selectedReagents[storage]] += 1;
            }

            selectedClues.RemoveAt(y);
            selectedClues.RemoveAt(y);
        }

        reagentGrid[selectedReagents[LoopIndex(x+1, 3)], selectedClues[0]] = 2;
        //print("Reagent " + selectedReagents[LoopIndex(x+1, 3)] + "gets clue " + selectedClues[0]);
        howManyCluesDoesReagentHave[selectedReagents[LoopIndex(x+1, 3)]] += 1;

        reagentGrid[selectedReagents[LoopIndex(x+2, 3)], selectedClues[1]] = 2;
        //print("Reagent " + selectedReagents[LoopIndex(x+2, 3)] + "gets clue " + selectedClues[1]);

        howManyCluesDoesReagentHave[selectedReagents[LoopIndex(x+2, 3)]] += 1;
        selectedClues.RemoveAt(0);
        selectedClues.RemoveAt(0);


        for (int i = 0; i < 3; i++)
        {
            if (howManyCluesDoesReagentHave[selectedReagents[i]] < 3)
            {
                reagentGrid[selectedReagents[i], selectedClues[0]] = 2;
                //print("Reagent " + selectedReagents[i] + " gets clue " + selectedClues[0]);
                howManyCluesDoesReagentHave[selectedReagents[i]] += 1;
                selectedClues.RemoveAt(0);
            }
        }

        //print("SELECTED CLUES ARE" + selectedClues.Count + " LONG");

        //print(howManyCluesDoesReagentHave[0]);
        //print(howManyCluesDoesReagentHave[1]);
        //print(howManyCluesDoesReagentHave[2]);



    }



    int CheckNeighbours(List<int> list, int index)
    {
        int amount = 0;
        amount += remainingClues[index] == remainingClues[index + 1] ? 1 : 0;
        amount += remainingClues[index] == remainingClues[index + 2] ? 1 : 0;
        return amount;
    }
    
    

    private void CheckValues()
    {
        int oneCount = 0;
        int twoCount = 0;

        for (int j = 0; j < 9; j++)
        {
            for (int i = 0; i < 9; i++)
            {
                if (reagentGrid[i, j] == 2)
                {
                    twoCount = twoCount + 1;
                }
                else if (reagentGrid[i, j] == 1)
                {
                    oneCount = oneCount + 1;
                }
            }


            //if (oneCount == 3)
            //{
            //    for (int i = 0; i < 9; i++)
            //    {
            //        if (reagentGrid[i, j] == 1)
            //        {
            //            reagentGrid[i, j] = -1;
            //        }
            //    }
            //}

            twoCount = 0;
            oneCount = 0;
        }

        SetScores();
    }

    //Sets the scores based on how many values over 0 are in each column
    //Scores should always add up to 15; 9 points from true clues and 6 from false clues
    private void SetScores()
    {
        reagentReference = new int[9,3];
        for(int i = 0; i < 9; i++)
        {
            int reference = 0;
            for (int j = 0; j < 9; j++)
            {
                if(reagentGrid[i, j] != 0)
                {
                    reagentReference[i, reference] = j;
                    reference++;
                    if(reagentGrid[i, j] ==2)
                    {
                        scores[i]++;
                    }
                }
            }


        }

        for (int i = 0; i < 9; i++)
        {
            int reference = 0;
            for (int j = 0; j < 9; j++)
            {
                if (reagentGrid[j, i] != 0)
                {
                    //print("REFERENCE IS " + reference);
                    clueReference[i, reference] = j;
                    reference++;
                }
            }

            //print("Clue " + i + " Gets " + clueReference[i, 0]);
            //print("Clue " + i + " Gets " + clueReference[i, 1]);
            //print("Clue " + i + " Gets " + clueReference[i, 2]);

            
        }

        //GenerateGrid();
        //TestTextFile();
    }

    //Outputs all necessary data to a formatted text file for readability. This can be removed in the final version if necessary


    public int[,] GetClueReference()
    {
        return clueReference;        
    }

    private void TestTextFile()
    {
        string path = Application.dataPath + "/Output.txt";

        File.AppendAllText(path, "Selected Clues: " + "\n");
        for (int i = 0; i < selectedCluesReference.Length; i += 2)
        {
            File.AppendAllText(path, "Clue " + selectedCluesReference[i] + "\n");
        }

        File.AppendAllText(path, "\n");
        File.AppendAllText(path, "\n");

        for (int i = 0; i < 9; i++)
        {
            File.AppendAllText(path, "Reagent " + i + ": ");
            for (int k = 0; k < 3; k++)
            {
                File.AppendAllText(path, "Clue " + reagentReference[i,k] + " ");
            }
            File.AppendAllText(path, "\n");
            File.AppendAllText(path, "Score: " + scores[i]);
            File.AppendAllText(path, "\n");
            File.AppendAllText(path, "\n");
        }
    }


    private void GenerateGrid()
    {
        string path = Application.dataPath + "/Output.txt";
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                File.AppendAllText(path, "[" + reagentGrid[j, i] + "]");
            }
            File.AppendAllText(path, "\n");
        }
        File.AppendAllText(path, "\n");
    }

    private void PurgeLists()
    {
        print("Purging");
        selectedReagents.Clear();
        remainingClues.Clear();
        selectedClues.Clear();
        clueIndex.Clear();

        System.Array.Clear(reagentGrid, 0, reagentGrid.Length);
        System.Array.Clear(reagents, 0, reagents.Length);
        System.Array.Clear(clues, 0, clues.Length);
        System.Array.Clear(reagentReference, 0, reagentReference.Length);
        System.Array.Clear(selectedCluesReference, 0, selectedCluesReference.Length);
        System.Array.Clear(scores, 0, scores.Length);

        validIndex = false;
    }
}

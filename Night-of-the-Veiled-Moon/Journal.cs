using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Journal : MonoBehaviour
{
    [SerializeField]
    private ClueSystem clueSystem;

    private int[,] clueReference = new int[9, 3];

    [SerializeField] private GameObject[] clueText;
    private string[] reagentFlavourText;

    private List<string> reagents = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        clueReference = clueSystem.GetClueReference();
        GetTextFields();
        GetReagentText();
        SetClueText();
    }

    void GetTextFields()
    {
        //clueText = GameObject.FindGameObjectsWithTag("ClueText");
    }

    void GetReagentText()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (clueReference[i, j] == 0)
                {
                    reagents.Add("<b><color=#FF3232FF>red berries</color></b>");
                }
                else if (clueReference[i, j] == 1)
                {
                    reagents.Add("<b><color=#01deb4ff>green berries</color></b>");
                }
                else if (clueReference[i, j] == 2)
                {
                    reagents.Add("<b><color=#8690f7ff>lilac berries</color></b>");
                }
                else if (clueReference[i, j] == 3)
                {
                    reagents.Add("<b><color=#e06cbc>pink feathers</color></b>");
                }
                else if (clueReference[i, j] == 4)
                {
                    reagents.Add("<b><color=#fe6d7b>red feathers</color></b>");
                }
                else if (clueReference[i, j] == 5)
                {
                    reagents.Add("<b><color=#749ae9>lilac feathers</color></b>");
                }
                else if (clueReference[i, j] == 6)
                {
                    reagents.Add("<b><color=#886051>branched horns</color></b>");
                }
                else if (clueReference[i, j] == 7)
                {
                    reagents.Add("<b><color=#bb8f7f>straight horns</color></b>");
                }
                else if (clueReference[i, j] == 8)
                {
                    reagents.Add("<b><color=#5c3627>curled horns</color></b>");
                }
            }
        }
    }

    void SetClueText()
    {
        for (int i = 0; i < 27; i++)
        {
            int rand = Random.Range(0, 5);

            if (rand == 0)
            {
                clueText[i].GetComponent<TextMeshProUGUI>().text = "These might be negated with " + reagents[i];
            }
            else if (rand == 1)
            {
                clueText[i].GetComponent<TextMeshProUGUI>().text = "Some say " + reagents[i] + " could help here";
            }
            else if (rand == 2)
            {
                clueText[i].GetComponent<TextMeshProUGUI>().text = "My research has shown that " + reagents[i] + " works well";
            }
            else if (rand == 3)
            {
                clueText[i].GetComponent<TextMeshProUGUI>().text = "This beast might be weak to " + reagents[i];
            }
            else if (rand == 4)
            {
                clueText[i].GetComponent<TextMeshProUGUI>().text = "Some say " + reagents[i] + " repel this beast";
            }
        }
    }
}

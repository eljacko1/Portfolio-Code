using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tutorialTextBox;
    [SerializeField]
    private GameObject tutorialUI;
    private List<string> tutorialText;
    private int messageNumber = 0;
    private bool textVisible = false;
    private string currentText = "";
    private string fullText;
    [SerializeField]
    private float delay = 0.1f;
    private bool multiple = true;


    [HideInInspector]
    public bool deathMessageShown = false;
    private bool berriesMessageShown = false;
    private bool feathersMessageShown = false;
    private bool barkMessageShown = false;
    

    // Start is called before the first frame update
    void Start()
    {
        tutorialText = new List<string>
        {
            "I should get a move on (WASD).",
            "Perhaps I should examine my surroundings (Mouse Wheel).",
            "I can't gather reagents with my arm like this. My companion can do it for me (RMB).",
            "My parent's journal has valuable information for me, I should take a look (J).",

            "My companion could easily rip that bark off the trees, it could be handy.",
            "The juice from those berries could be useful. My companion can gather some for me.",
            "These small creatures have feathers which could be used in the ritual, I'll have my companion get some for me.",

            "I should stay away from the spirit until I'm ready for the ritual."
        };
        ShowTutorial(0);
        

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private IEnumerator ShowTextMultiple()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            tutorialTextBox.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(2);

        messageNumber += 1;
        ShowTutorial(messageNumber);
    }

    private IEnumerator ShowTextSingle()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            tutorialTextBox.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(2);
        HideTutorial();
    }

    public void ShowTutorial(int messageNum)
    {
        tutorialUI.SetActive(true);
        fullText = tutorialText[messageNum];
        currentText = "";


        

        if(messageNumber > 2)
        {
            multiple = false;
        }

        if (multiple == true)
        {
            StartCoroutine(ShowTextMultiple());
        }
        else
        {
            StartCoroutine(ShowTextSingle());
        }
    }
    public void HideTutorial()
    {
        tutorialUI.SetActive(false);
    }
}

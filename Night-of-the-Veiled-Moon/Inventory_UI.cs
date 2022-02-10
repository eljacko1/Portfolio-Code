using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private ClueSystem clueSystem;
    private SimpleInventory inventory;
    private GameObject[] inventorySlots;
  
    [SerializeField]
    private Sprite[] inventoryImages;

    [SerializeField] private Button startRitualButton;
    [SerializeField] private Button previousMaskButton;
    [SerializeField] private Button nextMaskButton;

    bool[] allComponents = { false, false, false };

    // Start is called before the first frame update
    void Start()
    {
        inventory = player.GetComponent<SimpleInventory>();
        inventorySlots = GameObject.FindGameObjectsWithTag("InventorySlot");
    }

    private void Update()
    {
        allComponents[0] = CheckBerries();
        allComponents[1] = CheckFeathers();
        allComponents[2] = CheckBark();

        if (allComponents.All(x => x))
        {
            startRitualButton.interactable = true;
        }
        else
        {
            startRitualButton.interactable = false;
        }
    }

    private bool CheckBerries()
    {
        switch (inventory.GetItem(0))
        {
            case 0:
                //red
                inventorySlots[0].GetComponent<Image>().sprite = inventoryImages[0];
                break;

            case 1:
                //green
                inventorySlots[0].GetComponent<Image>().sprite = inventoryImages[1];
                break;

            case 2:
                //purple
                inventorySlots[0].GetComponent<Image>().sprite = inventoryImages[2];
                break;

            case 4:
                inventorySlots[0].GetComponent<Image>().sprite = null;
                return false;
        }

        Color tempColour = inventorySlots[0].GetComponent<Image>().color;
        tempColour.a = 1;
        inventorySlots[0].GetComponent<Image>().color = tempColour;

        return true;
    }

    private bool CheckFeathers()
    {
        switch (inventory.GetItem(1))
        {
            case 0:
                //pink
                inventorySlots[1].GetComponent<Image>().sprite = inventoryImages[3];
                break;

            case 1:
                //red
                inventorySlots[1].GetComponent<Image>().sprite = inventoryImages[4];
                break;

            case 2:
                //blue
                inventorySlots[1].GetComponent<Image>().sprite = inventoryImages[5];
                break;

            case 4:
                inventorySlots[1].GetComponent<Image>().sprite = null;
                return false;
        }

        Color tempColour = inventorySlots[1].GetComponent<Image>().color;
        tempColour.a = 1;
        inventorySlots[1].GetComponent<Image>().color = tempColour;

        return true;
    }

    private bool CheckBark()
    {
        switch (inventory.GetItem(2))
        {
            case 0:
                //branched
                inventorySlots[2].GetComponent<Image>().sprite = inventoryImages[7];
                currentBarkId = 0;
                break;

            case 1:
                //small
                inventorySlots[2].GetComponent<Image>().sprite = inventoryImages[8];
                currentBarkId = 1;
                break;

            case 2:
                //curled
                inventorySlots[2].GetComponent<Image>().sprite = inventoryImages[9];
                currentBarkId = 2;
                break;

            case 3:
                //display bark
                inventorySlots[2].GetComponent<Image>().sprite = inventoryImages[6];
                previousMaskButton.gameObject.SetActive(true);
                nextMaskButton.gameObject.SetActive(true);
                return false;

            case 4:
                //nothing gathered
                inventorySlots[2].GetComponent<Image>().sprite = null;
                previousMaskButton.gameObject.SetActive(false);
                nextMaskButton.gameObject.SetActive(false);
                return false;
        }

        Color tempColour = inventorySlots[2].GetComponent<Image>().color;
        tempColour.a = 1;
        inventorySlots[2].GetComponent<Image>().color = tempColour;

        previousMaskButton.gameObject.SetActive(true);
        nextMaskButton.gameObject.SetActive(true);

        return true;
    }

    int currentBarkId = 5;

    public void PrevTypeButton()
    {
        if (currentBarkId == 0)
            currentBarkId = 2;
        else
            currentBarkId--;

        inventory.AddItem(2, currentBarkId);
    }

    public void NextTypeButton()
    {
        if (currentBarkId == 2)
            currentBarkId = 0;
        else
            currentBarkId++;

        inventory.AddItem(2, currentBarkId);
    }

    public void OnStartRitualButton()
    {
        //Get total score
        int score = 0;
        for (int i=0; i < 3; i++)
        {
            score += clueSystem.scores[inventory.GetItem(i) + (i * 3)];
        }

        Debug.Log(score);

        SceneController sc = SceneController.instance;

        sc.loadedFromRitual = true;
        sc.maskQuality = score;
        sc.berry = inventory.GetItem(0);
        sc.feather = inventory.GetItem(1);
        sc.horn = inventory.GetItem(2);

        SceneController.instance.LoadSceneFromIndex(2);
    }
}

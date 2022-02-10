using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Journal_UI : MonoBehaviour
{
    InputMaster input;
    [SerializeField]
    private GameObject journalObject;
    private bool journalOpen = false;
    
    [SerializeField]
    private GameObject[] journalPages;
    [SerializeField]
    private GameObject[] notesPages;

    // Start is called before the first frame update
    void Start()
    {
        input = new InputMaster();
        input.Player.Journal.performed += x => Journal();
        input.Player.Enable();
    }

    private void Update()
    {
        journalObject.SetActive(journalOpen);
    }

    private void Journal()
    {
        journalOpen = !journalOpen;   
    }


    public void OnReagentTab()
    {
        foreach(GameObject page in journalPages)
        {
            page.SetActive(false);
        }
        foreach (GameObject page in notesPages)
        {
            page.SetActive(false);
        }

        journalPages[0].SetActive(true);
        journalPages[1].SetActive(true);
    }
    public void OnClueTab()
    {
        foreach (GameObject page in journalPages)
        {
            page.SetActive(false);
        }
        foreach (GameObject page in notesPages)
        {
            page.SetActive(false);
        }

        journalPages[2].SetActive(true);
        journalPages[3].SetActive(true);
    }
    public void OnNotesTab()
    {
        foreach (GameObject page in journalPages)
        {
            page.SetActive(false);
        }
        foreach(GameObject page in notesPages)
        {
            page.SetActive(false);
        }

        journalPages[6].SetActive(true);
        journalPages[7].SetActive(true);
    }


    public void OnInventoryTab()
    {
        foreach (GameObject page in journalPages)
        {
            page.SetActive(false);
        }
        foreach (GameObject page in notesPages)
        {
            page.SetActive(false);
        }


        journalPages[8].SetActive(true);
        journalPages[9].SetActive(true);
    }


    public void OnNextPage()
    {
        foreach (GameObject page in journalPages)
        {
            page.SetActive(false);
        }


        journalPages[4].SetActive(true);
        journalPages[5].SetActive(true);
    }
    public void OnPreviousPage()
    {
        foreach (GameObject page in journalPages)
        {
            page.SetActive(false);
        }

        journalPages[2].SetActive(true);
        journalPages[3].SetActive(true);
    }

    public void OnNotes1()
    {
        foreach (GameObject page in journalPages)
        {
            page.SetActive(false);
        }
        foreach (GameObject page in notesPages)
        {
            page.SetActive(false);
        }
        journalPages[6].SetActive(true);
        notesPages[0].SetActive(true);
    }

    public void OnNotes2()
    {
        foreach (GameObject page in journalPages)
        {
            page.SetActive(false);
        }
        foreach (GameObject page in notesPages)
        {
            page.SetActive(false);
        }
        journalPages[6].SetActive(true);
        notesPages[1].SetActive(true);
    }

    public void OnNotes3()
    {
        foreach (GameObject page in journalPages)
        {
            page.SetActive(false);
        }
        foreach (GameObject page in notesPages)
        {
            page.SetActive(false);
        }
        journalPages[6].SetActive(true);
        notesPages[2].SetActive(true);
    }

    public void OnNotes4()
    {
        foreach (GameObject page in journalPages)
        {
            page.SetActive(false);
        }
        foreach (GameObject page in notesPages)
        {
            page.SetActive(false);
        }
        journalPages[6].SetActive(true);
        notesPages[3].SetActive(true);
    }

    public void OnBack()
    {
        foreach (GameObject page in journalPages)
        {
            page.SetActive(false);
        }
        foreach (GameObject page in notesPages)
        {
            page.SetActive(false);
        }
        journalPages[6].SetActive(true);
        journalPages[7].SetActive(true);
    }
}

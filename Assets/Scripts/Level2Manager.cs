using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level2Manager : MonoBehaviour
{
    // Array of all trigger objects in the scene
    public GameObject[] triggers = new GameObject[4];
    public int correctTriggerIndex;
    public GameObject currentTrigger = null;
    public int nextScene;
    public AssignTriggers TriggerAssigns;
    public int NumeroBarriles;
    public GameObject[] Barrels = new GameObject[4];
    public GameObject[] Scents;
    public FilledBar filledBar;
    public bool MenuIsActive;
    public GameObject Sloof;
    private Animator sloofAnimator;

    void Start()
    {
        sloofAnimator = Sloof.GetComponent<Animator>();
        // Initialize the triggers and barrels
        TriggerAssigner();
        SearchBarrels();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && currentTrigger != null)
        {
            int index = System.Array.IndexOf(triggers, currentTrigger);
            if (index == correctTriggerIndex)
            {
                CorrectOption(); // Call correct function
            }
            else
            {
                IncorrectOption(); // Call incorrect function
            }
        }

        checkSloofMode();
    }

    public void checkSloofMode()
    {
        if (Input.GetKeyDown(KeyCode.R) && filledBar.currentValue > 0.1f)
        {
            filledBar.StartDraining();
            MenuIsActive = !MenuIsActive;
        }

        if (MenuIsActive)
        {
            for (int i = 0; i < Scents.Length; i++)
            {
                Scents[i].SetActive(false);
            }
            Scents[correctTriggerIndex].SetActive(true);
            sloofAnimator.SetBool("SloofMode", true);
        }
        else
        {
            for (int i = 0; i < Scents.Length; i++)
            {
                Scents[i].SetActive(false);
            }
            sloofAnimator.SetBool("SloofMode", false);
        }

        if (filledBar.currentValue == 0)
        {
            for (int i = 0; i < Scents.Length; i++)
            {
                Scents[i].SetActive(false);
            }
            filledBar.StartFilling();
            MenuIsActive = false;
        }
    }

    public void CurrentTriggerSetter(GameObject trigger)
    {
        currentTrigger = trigger;
    }

    public void CurrentTriggerUnsetter(GameObject trigger)
    {
        if (currentTrigger == trigger)
        {
            currentTrigger = null;
        }
    }

    void CorrectOption()
    {
        Debug.Log("Correct Trigger!");
        SceneManager.LoadScene(TriggerAssigns.nextScene);
    }

    void IncorrectOption()
    {
        Debug.Log("Incorrect Trigger!");
        SceneManager.LoadScene(7);
    }

    public void TriggerAssigner()
    {
        TriggerAssigns = GameObject.Find("Puertas").GetComponent<AssignTriggers>();
        correctTriggerIndex = TriggerAssigns.correctTriggerIndex;
        switch (correctTriggerIndex)
        {
            case 0:
                NumeroBarriles = 4;
                break;
            case 1:
                NumeroBarriles = 3;
                break;
            case 2:
                NumeroBarriles = 2;
                break;
            case 3:
                NumeroBarriles = 1;
                break;
        }
    }

    public void SearchBarrels()
    {
        for (int i = 0; i < Barrels.Length; i++)
        {
            Barrels[i].SetActive(i < NumeroBarriles);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Manager : MonoBehaviour
{
    // Array of all trigger objects in the scene
    public GameObject[] triggers = new GameObject[4];
    public int correctTriggerIndex;
    public GameObject currentTrigger = null;
    public int nextScene;
    public AssignTriggers TriggerAssigns;
    

    void Start()
    {
        // Randomly assign one trigger as the correct one
        correctTriggerIndex = Random.Range(0, triggers.Length);
        
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

        SearchTriggers();
        TriggerAssigner();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object collided with is one of the triggers
        if (System.Array.IndexOf(triggers, other.gameObject) != -1)
        {
            currentTrigger = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Clear the current trigger when exiting
        if (currentTrigger == other.gameObject)
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
        SceneManager.LoadScene(3);

    }

    public void SearchTriggers()
    {
        for (int i = 0; i < triggers.Length; i++)
        {
            triggers[i] = GameObject.Find("Puerta" + (i + 1).ToString());
            if (triggers[i] == null)
            {
                Debug.LogError("Trigger 'Puerta" + (i + 1) + "' not found in the scene.");
            }
        }
    }

    public void TriggerAssigner()
    {
        TriggerAssigns = GameObject.Find("Puertas").GetComponent<AssignTriggers>();
    }
}

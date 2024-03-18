using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool BI_0 { get; private set; } = false;
   

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps the game manager across scenes
        }
        else
        {
            Destroy(gameObject); // Ensures there's only one GameManager instance
        }
    }

    
    public void SetBI_0(bool value)
    {
        BI_0 = value;
    }

    
    public void ToggleBI_0()
    {
        BI_0 = !BI_0;
    }
}

 
  
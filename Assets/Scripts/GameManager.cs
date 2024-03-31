using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool[] ConditionsBartender;
    public bool[] ConditionsCiervo;
    public bool[] ConditionsPaloma;
    public bool[] ConditionsPanda;
    public bool[] ConditionsRatona;
    public bool isTalking = false;
    



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

    

}

 
  
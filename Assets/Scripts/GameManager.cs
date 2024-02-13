using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    public GameObject objectToDisappear; // The object that will disappear
    private int itemsCollected = 0; // Track the number of items collected

    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncrementItemsCollected()
    {
        itemsCollected++;
        CheckItemsCollected();
    }

    void CheckItemsCollected()
    {
        // If 2 items are collected, make another object disappear
        if (itemsCollected >= 2)
        {
            if (objectToDisappear != null)
            {
                objectToDisappear.SetActive(false);
            }
        }
    }
}

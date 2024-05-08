using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzleManager : MonoBehaviour
{
    public GameObject CablesHolder;
    public GameObject[] Cables;
    public InteractuableDoor interactuableDoor;

    [SerializeField]
    int totalCables = 0;
    [SerializeField]
    int correctedCables = 0;

    void Start ()
    {
        totalCables = CablesHolder.transform.childCount;

        Cables = new GameObject[totalCables];

        for (int i=0; i < Cables.Length; i++)
        {
            Cables[i] = CablesHolder.transform.GetChild(i).gameObject;
        }
    }

    public void correctMove()
    {
        correctedCables += 1;

        Debug.Log("Cable Conectado");

        if(correctedCables == totalCables)  
        {
            Debug.Log("Puzle Completado!");
            CompletedPuzle();
        }
    }

    public void wrongMove()
    {
        correctedCables -= 1;
    }

    void CompletedPuzle()
    {
        interactuableDoor.ReactiveCameraPlayer();
    }

}

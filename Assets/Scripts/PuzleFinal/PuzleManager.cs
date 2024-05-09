using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzleManager : MonoBehaviour
{
    public GameObject CablesHolder;
    public GameObject[] Cables;
    public InteractuableDoor interactuableDoor;
    public GameObject objectToDisable1;
    public GameObject objectToDisable2;
    public GameObject objectToDisable3;
    public GameObject objectToDisable4;

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
    if(objectToDisable1 != null)
        objectToDisable1.SetActive(false);

    if(objectToDisable2 != null)
        objectToDisable2.SetActive(false);

    if(objectToDisable3 != null)
        objectToDisable3.SetActive(false);

    if(objectToDisable4 != null)
        objectToDisable4.SetActive(false);
    if (interactuableDoor != null)
    {
        interactuableDoor.ReactiveCameraPlayer();
    }
    else
    {
        Debug.LogError("No se ha asignado el objeto InteractuableDoor en el PuzleManager.");
    }
    }

}

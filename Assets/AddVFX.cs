using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVFX : MonoBehaviour
{
    public GameObject[] Sprites;
    // Start is called before the first frame update
    void Start()
    {
        Sprites[0].SetActive(false);
        Sprites[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Client")) Sprites[0].SetActive(true);
        if (other.CompareTag("Interactable")) Sprites[1].SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Sprites[0].SetActive(false);
        Sprites[1].SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable")) Sprites[1].SetActive(true);
    }
}

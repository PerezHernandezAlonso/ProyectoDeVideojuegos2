using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    public Level2Manager manager;

    void Start()
    {
        if (manager == null)
        {
            manager = FindObjectOfType<Level2Manager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.CurrentTriggerSetter(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.CurrentTriggerUnsetter(gameObject);
        }
    }
}
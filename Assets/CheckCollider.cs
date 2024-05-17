using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public Level2Manager manager;
    public Collider collider;
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        manager.CurrentTriggerSetter(collider);
    }

    private void OnTriggerExit(Collider other)
    {
        manager.CurrentTriggerUnsetter(collider);
    }
}

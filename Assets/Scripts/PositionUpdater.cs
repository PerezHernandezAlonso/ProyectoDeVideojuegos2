using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionUpdater : MonoBehaviour
{
    public GameObject perrito;
    public Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        perrito = GameObject.Find("PerroDetective");
        updatePosition();
    }

    // Update is called once per frame
    void Update()
    {
        perrito = GameObject.Find("PerroDetective");
    }

    public void updatePosition()
    {
        perrito.transform.position = targetPosition;
    }
}

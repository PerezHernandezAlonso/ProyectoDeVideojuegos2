using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractuableDoor : MonoBehaviour
{
    public Camera camaraJugador;
    public Camera camaraPuzzle;

    private void Start()
    {
        AssignPlayerCamera();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            camaraJugador.gameObject.SetActive(false);
            camaraPuzzle.gameObject.SetActive(true);
        }
    }

    public void ReactiveCameraPlayer()
    {
        camaraJugador.gameObject.SetActive(true);
        camaraPuzzle.gameObject.SetActive(false);
    }

    public void AssignPlayerCamera()
    {
        {
            camaraJugador = FindObjectOfType<Camera>();
            if (camaraJugador == null)
            {
                Debug.LogError("Player camera not found.");
            }
        }
    }
}


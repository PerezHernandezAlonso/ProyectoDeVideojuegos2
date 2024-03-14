using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamComic : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed;

    private Transform currentView;
    private int currentIndex = 0;
    private bool viewsChanged = false;
    public Canvas textoCanvas;

    void Start()
    {
        currentView = views[0];
        transform.position = currentView.position;
        StartCoroutine(ChangeViewAutomatically());
    }

    IEnumerator ChangeViewAutomatically()
    {
        while (!viewsChanged && currentIndex < views.Length - 1)
        {
            yield return new WaitForSeconds(4f);
            currentIndex++;
            currentView = views[currentIndex];
        }

        // Si la cámara ha alcanzado el último punto de vista, muestra el Canvas con el texto después de esperar 4 segundos
        if (currentIndex == views.Length - 1)
        {
            yield return new WaitForSeconds(4f);
            ShowTextCanvas();
        }
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
    }

    // Método para mostrar el Canvas con el texto
    void ShowTextCanvas()
    {
        textoCanvas.gameObject.SetActive(true);
    }
}

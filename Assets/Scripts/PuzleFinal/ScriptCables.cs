using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCables : MonoBehaviour
{
    float[] rotations = {0, 90, 180, 270};
    public float[] correctRotation;
    [SerializeField]
    bool isPlaced = false;

    int PossiblesRotations = 1;

    PuzleManager puzleManager;

    private void Awake()
    {
        puzleManager = GameObject.Find("PuzleManager").GetComponent<PuzleManager>();
    }

    private void Start()
    {
        PossiblesRotations = correctRotation.Length;
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        // Mejora: Verifica si la pieza está correctamente rotada con una tolerancia
        if (IsCorrectlyRotated(transform.eulerAngles.z, correctRotation))
        {
            isPlaced = true;
            puzleManager.correctMove();
        }
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        // Mejora: Verifica si la pieza está correctamente rotada con una tolerancia
        if (IsCorrectlyRotated(transform.eulerAngles.z, correctRotation) &&!isPlaced)
        {
            isPlaced = true;
            puzleManager.correctMove();
        }
        else if (isPlaced)
        {
            isPlaced = false;
            puzleManager.wrongMove();
        }
    }

    // Método para verificar si la rotación actual es correcta con una tolerancia
    private bool IsCorrectlyRotated(float currentRotation, float[] correctRotations)
    {
        // Ajusta la tolerancia según sea necesario
        float tolerance = 0.01f;
        foreach (float correctRotation in correctRotations)
        {
            if (Mathf.Abs(currentRotation - correctRotation) <= tolerance)
            {
                return true;
            }
        }
        return false;
    }
}
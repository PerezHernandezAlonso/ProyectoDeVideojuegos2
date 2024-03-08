using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSelect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int SiguienteEscena = 0;
    public int EscenaActual = 0;



    public void PlayGame()
    {

        SceneLoader.Instance.CargarEscena(SiguienteEscena, EscenaActual);
        Time.timeScale = 1f;
        Debug.Log("Funcionando");
    }

    public void QuitGame()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    public void Opciones()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string[] gameScene;

    public static SceneLoader Instance;
    [SerializeField] public GameObject PanelAnimacion;
    private Level2Manager level2manager;


    [ContextMenu("CargarEscena")]


 
    public void Awake()
    {
        Instance = this;
        StartCoroutine(LoadSceneAdditive(gameScene[1]));
        
    }


    public void CargarEscena(int EscenaACargar, int EscenaADescargar)
    {
        
        
        PanelAnimacion.SetActive(true);
        StartCoroutine(EsperarSegundos(EscenaACargar, EscenaADescargar));
        StartCoroutine(Esperar1Segundo());
        //level2manager.SearchTriggers();




    }
    public void DescargarEscena(int EscenaActual)
    {
        if( EscenaActual != 0)
        SceneManager.UnloadSceneAsync(gameScene[EscenaActual]);

    }

    IEnumerator Esperar1Segundo()
    {
        yield return new WaitForSeconds(1.1f);
        PanelAnimacion.SetActive(false);
        
    }
    IEnumerator EsperarSegundos(int EscenaACargar, int EscenaADescargar)
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(LoadSceneAdditive(gameScene[EscenaACargar]));
        DescargarEscena(EscenaADescargar);
       
        

    }
    private static IEnumerator LoadSceneAdditive(string sceneName)
    {

        Scene sceneToLoad = SceneManager.GetSceneByName(sceneName);
        if (sceneToLoad.isLoaded)
        {
            AsyncOperation unloadSceneAsycnOp = SceneManager.UnloadSceneAsync(sceneToLoad, UnloadSceneOptions.None);

            while (unloadSceneAsycnOp.isDone)
            {
                yield return null;
            }
        }

        AsyncOperation loadScenASycnOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (loadScenASycnOp.isDone)
        {
            yield return null;
        }
        Debug.Log("escena cargada");
    }

}

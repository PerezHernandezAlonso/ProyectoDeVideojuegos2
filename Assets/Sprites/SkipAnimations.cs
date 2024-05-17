using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipAnimations : MonoBehaviour
{
    public SceneSelect sceneSelect;
    public bool[] conditions = new bool[2];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            skip();
        }
    }
    public void skip()
    {
        sceneSelect.PlayGame();
    }
}

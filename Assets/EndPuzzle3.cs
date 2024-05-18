using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPuzzle3 : MonoBehaviour
{
    public Collider collider;
    private bool isColliding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding == true)
        {
            LoadNextScene();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isColliding = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(12);
    }
}

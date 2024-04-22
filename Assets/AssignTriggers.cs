using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignTriggers : MonoBehaviour
{
    public GameObject Perrito;
    private Level2Manager level2manager;
    public int nextScene;
    // Start is called before the first frame update
    void Start()
    {
        
        level2manager = Perrito.GetComponent<Level2Manager>();
        level2manager.SearchTriggers();
        
    }

    // Update is called once per frame
    void Update()
    {
        level2manager.nextScene = nextScene;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignTriggers : MonoBehaviour
{
    public GameObject Perrito;
    private Level2Manager level2manager;
    public int nextScene;
    public int correctTriggerIndex;
    public GameObject MenuBarriles;
    // Start is called before the first frame update
    void Start()
    {
        
        level2manager = Perrito.GetComponent<Level2Manager>();
        //level2manager.SearchTriggers();
        correctTriggerIndex = Random.Range(0, 4);
        MenuBarriles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        level2manager.nextScene = nextScene;
    }

    public void activeMenu()
    {
        MenuBarriles.SetActive(true);
    }
}

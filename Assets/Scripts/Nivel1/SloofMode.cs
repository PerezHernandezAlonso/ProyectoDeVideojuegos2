using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SloofMode : MonoBehaviour
{
    public GameObject Scents;
    private bool MenuIsActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (MenuIsActive == false)
            {
                LoadMenu();
            }
            else
            {
                UnloadMenu();
            }
        }


    }
  

    private void LoadMenu()
    {
        Scents.SetActive(true);
        MenuIsActive = true;
    }
    private void UnloadMenu()
    {
        Scents.SetActive(false);
        MenuIsActive = false;
    }
}

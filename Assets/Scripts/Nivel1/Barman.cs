using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barman : MonoBehaviour
{
    
    private bool isColliding = false;
    public GameObject menu;
    private bool MenuIsActive = false;

    private void Update()
    {
        if (isColliding == true && Input.GetKeyDown(KeyCode.F))
        {
            if (MenuIsActive == false)
            {
                LoadMenu();
            } else
            {
                UnloadMenu();
            }
        }
        if (isColliding == false)
        {
            UnloadMenu();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isColliding = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isColliding = false;
    }

    private void LoadMenu()
    {
        menu.SetActive(true);
        MenuIsActive = true;
    }
    private void UnloadMenu()
    {
        menu.SetActive(false);
        MenuIsActive = false;
    }
}

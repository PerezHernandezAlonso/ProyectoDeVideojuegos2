using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SloofMode : MonoBehaviour
{
    public GameObject Scents;
    private bool MenuIsActive = false;
    public GameManager gamemanager;
    public GameObject[] allScents;
    public bool[] scentsActive; // ciervo = 0, paloma = 1, panda = 2, ratona = 3. Bebida1 = 4, Bebida 2 = 5, Bebida3 = 6, Bebida4 = 7, Bebida5 = 8.
    public bool step1, step2, step3, step4 = false;

    private void Update()
    {
        checkScents();
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
    private void checkScents()
    {
        if (step1 == false && step2 == false && step3 == false && step4 == false)
        {
            if (gamemanager.ConditionsCiervo[0] == false)
                scentsActive[0] = true;
            else scentsActive[0] = false;

            if (gamemanager.ConditionsPaloma[0] == false)
                scentsActive[1] = true;
            else scentsActive[1] = false;

            if (gamemanager.ConditionsPanda[0] == false)
                scentsActive[2] = true;
            else scentsActive[2] = false;

            if (gamemanager.ConditionsRatona[0] == false)
                scentsActive[3] = true;
            else scentsActive[3] = false;
        }


        if (gamemanager.ConditionsCiervo[0] == true && gamemanager.ConditionsPaloma[0] == true && gamemanager.ConditionsPanda[0] == true && gamemanager.ConditionsRatona[0] == true)
        {
            step1 = true;
        }
        if (step1 == true && step2 == false && step3 == false && step4 == false)
        {
            if (gamemanager.ConditionsCiervo[1] == false)
            {
                cleanScents();
                scentsActive[0] = true;
                scentsActive[4] = true;
                scentsActive[7] = true;
                scentsActive[8] = true;
            }
        }
        if (gamemanager.ConditionsCiervo[1] == true && (gamemanager.ConditionsPaloma[2] == false || gamemanager.ConditionsRatona[1] == false))
        {
            step2 = true;
        }
        if (step1 == true && step2 == true && step3 == false && step4 == false)
        {
            if (gamemanager.ConditionsPaloma[1] == false)
            {
                cleanScents();
                scentsActive[1] = true;
                scentsActive[4] = true;
                scentsActive[5] = true;
                scentsActive[7] = true;
            }
            else if (gamemanager.ConditionsRatona[1] == false)
            {
                cleanScents();
                scentsActive[3] = true;
                scentsActive[4] = true;
                scentsActive[6] = true;
                scentsActive[8] = true;

            }
            else if (gamemanager.ConditionsPaloma[2] == false)
            {
                cleanScents();
                scentsActive[1] = true;
                scentsActive[4] = true;
                scentsActive[5] = true;
                scentsActive[7] = true;
            }
        }
        if (step2 == true && (gamemanager.ConditionsPanda[1] == false || gamemanager.ConditionsRatona[2] == false))
        {
            step3 = true;
        }
        if (step3 == true)
        {
            if (gamemanager.ConditionsPanda[1] == false)
            {
                cleanScents();
                scentsActive[2] = true;
                scentsActive[5] = true;
                scentsActive[6] = true;
                scentsActive[7] = true;
            }
            else if (gamemanager.ConditionsRatona[2] == false)
            {
                cleanScents();
                scentsActive[3] = true;
                scentsActive[4] = true;
                scentsActive[6] = true;
                scentsActive[8] = true;
            }
        }
    }
    private void cleanScents()
    {
        for (int i = 0; i < scentsActive.Length; i++)
        {
            scentsActive[i] = false;
        }
    }

    private void LoadMenu()
    {
        loadScents();
        Scents.SetActive(true);
        MenuIsActive = true;
    }
    private void UnloadMenu()
    {
        Scents.SetActive(false);
        MenuIsActive = false;
    }

    public void loadScents()
    {
        for (int i = 0; i < scentsActive.Length; i++)
        {
            if (scentsActive[i] == true)
            {
                allScents[i].SetActive(true);
            }
            else
            {
                allScents[i].SetActive(false);
            }
        }
    }
}

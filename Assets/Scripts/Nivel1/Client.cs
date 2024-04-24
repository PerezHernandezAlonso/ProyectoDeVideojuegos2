using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Client : MonoBehaviour
{
    public List<int> requiredItems = new List<int>(); // Correct combination of item IDs
    public int clientId; // Unique ID for each client
    private bool isColliding = false;
    public TextMeshPro Texto;
    public Dialogue[] Dialogo;
    public int[] Conditions;
    private GameManager gamemanager;
    private DialogueManager dialoguemanager;
    private Animator animator;
    private Animator animatorPanda;
    private GameObject Panda;
    public SpriteRenderer iconos;
    public GameObject menuBarriles;
 

    private void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        dialoguemanager = FindObjectOfType<DialogueManager>();
        animator = GetComponent<Animator>();
        Panda = GameObject.Find("Client3");
        animatorPanda = Panda.GetComponent<Animator>();
        
    }

    private void Update()
    {

            if (isColliding == true && Input.GetKeyDown(KeyCode.F) && gamemanager.isTalking == false)
            {

            switch (clientId)
            {
                case 1:
                    if (gamemanager.ConditionsCiervo[0] == false || gamemanager.ConditionsPaloma[0] == false || gamemanager.ConditionsPanda[0] == false || gamemanager.ConditionsRatona[0] == false)
                    {
                        dialoguemanager.StartDialogue(Dialogo[0]);
                        gamemanager.ConditionsCiervo[0] = true;
                    }
                    else if (gamemanager.ConditionsCiervo[0] == true)
                    {
                        drinkDialoguesOne();
                        if (CheckItems() == true)
                        {
                            gamemanager.ConditionsCiervo[1] = true; //Recibimos somnifero
                        }
                        cleanInventory();

                    }
                    break;

                case 2:
                    if (gamemanager.ConditionsCiervo[0] == false || gamemanager.ConditionsPaloma[0] == false || gamemanager.ConditionsPanda[0] == false || gamemanager.ConditionsRatona[0] == false)
                    {
                        dialoguemanager.StartDialogue(Dialogo[0]);
                        gamemanager.ConditionsPaloma[0] = true;
                    }
                    else if (gamemanager.ConditionsPaloma[0] == true && gamemanager.ConditionsPaloma[1] == false)
                    {
                        drinkDialoguesOne();
                        if (CheckItems() == true)
                        gamemanager.ConditionsPaloma[1] = true;
                    } else if (gamemanager.ConditionsPaloma[1] == true && gamemanager.ConditionsCiervo[1] == true) 
                    { 

                        if (CheckItems() == true)
                        {
                            dialoguemanager.StartDialogue(Dialogo[3]); //Recibes la pluma
                            gamemanager.ConditionsPaloma[2] = true;
                        } else
                        {
                            dialoguemanager.StartDialogue(Dialogo[2]);
                        }
                        cleanInventory();
                    }
                        
                        break;

                    case 3:
                        if (gamemanager.ConditionsCiervo[0] == false || gamemanager.ConditionsPaloma[0] == false || gamemanager.ConditionsPanda[0] == false || gamemanager.ConditionsRatona[0] == false)
                        {
                            dialoguemanager.StartDialogue(Dialogo[0]);
                            gamemanager.ConditionsPanda[0] = true;
                        }
                        else if (gamemanager.ConditionsPanda[0] == true && gamemanager.ConditionsPanda[1] == false)
                        {
                            drinkDialoguesOne();
                            if (CheckItems() == true)
                            {
                                gamemanager.ConditionsPanda[1] = true;
                            }
                        cleanInventory();
                        } else if (gamemanager.ConditionsRatona[2] == true)
                        {
                            dialoguemanager.StartDialogue(Dialogo[3]);
                        }
                        break;

                    case 4:
                        if (gamemanager.ConditionsCiervo[0] == false || gamemanager.ConditionsPaloma[0] == false || gamemanager.ConditionsPanda[0] == false || gamemanager.ConditionsRatona[0] == false)
                        {
                            dialoguemanager.StartDialogue(Dialogo[0]);
                            gamemanager.ConditionsRatona[0] = true;
                        }
                        else if (gamemanager.ConditionsRatona[0] == true && gamemanager.ConditionsRatona[1] == false)
                        {
                            drinkDialoguesOne();
                            if (CheckItems() == true)
                            {
                                gamemanager.ConditionsRatona[1] = true;
                            }
                        cleanInventory();
                    } else if (gamemanager.ConditionsRatona[1] == true && gamemanager.ConditionsPaloma[2] == true && gamemanager.ConditionsPanda[1] == true)
                        {
                            if (CheckItems() == true)
                            {
                                dialoguemanager.StartDialogue(Dialogo[3]);
                                gamemanager.ConditionsRatona[2] = true;
                                animator.SetBool("Estornudando", true);
                                animatorPanda.SetBool("Riendo", true);
                            }
                        cleanInventory();
                    }
                        break;

                case 5:
                    
                    if (gamemanager.ConditionsCocodrilo[0] == false)
                    {

                        dialoguemanager.StartDialogue(Dialogo[0]);
                        gamemanager.ConditionsCocodrilo[0] = true;
                    } else
                    {
                        
                        menuBarriles.SetActive(true);
                    }
                    break;
                }

            }
        
        
    }
    private void cleanInventory()
    {
        PlayerInventory.instance.RemoveItems(PlayerInventory.instance.items.ToList());
    }
    private void drinkDialoguesOne()
    {
        if (CheckItems() == true)
        {
            dialoguemanager.StartDialogue(Dialogo[1]);
        }
        else
        {
            dialoguemanager.StartDialogue(Dialogo[2]);
        }
    }
    private bool CheckItems()
    {
        // Check if player has exactly the required items, no more, no less
        if (PlayerInventory.instance.items.Count == requiredItems.Count && requiredItems.All(id => PlayerInventory.instance.items.Contains(id)))
        {
            return true;
        }
        else
        {
            return false;
            PlayerInventory.instance.RemoveItems(PlayerInventory.instance.items.ToList());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isColliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isColliding = false;
    }
}

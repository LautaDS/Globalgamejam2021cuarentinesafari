using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class Mom : MonoBehaviour
{
   
    private int levelOfPuzzles;
    public Door[] doors;
   
    // THIRD TRY
    public GameObject dialogBox;
    public Text dialogText;
    public Dialog dialogs;
    public bool playerInRange;

    private void Awake()
    {
        levelOfPuzzles = 0;
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustDoors()
    {
        switch (levelOfPuzzles)
        {
            case 0:
               
                break;
            case 1:
                doors[levelOfPuzzles].OpenDoor();
                break;
            case 2:
                doors[levelOfPuzzles].OpenDoor();
                break;
            case 3:
                doors[levelOfPuzzles].OpenDoor();
                break;

            default:
                break;
        }

       
    }
    public void OnTalk(InputAction.CallbackContext context)
    {
        if (context.performed)
        {


        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerInRage = false;
        }
    }
}

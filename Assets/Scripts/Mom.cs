using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class Mom : MonoBehaviour
{
    public Door[] doors;
    public Dialog[] dialogs;
    private int levelOfPuzzles;
    private int index;

    // THIRD TRY
    public GameObject dialogBox;
    public Text dialogText;
    public bool playerInRange;
    public Player player;
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
        if (context.performed && playerInRange)
        {
            player.talking = true;
            dialogBox.SetActive(true);
            PlayDialog();
        }
    }

    public void PlayDialog()
    {
        if (index < dialogs[levelOfPuzzles].lineOfDialog.Length - 1)
        {
            dialogText.text = "";
            StartCoroutine(Type());
            index++;

        }
        else if (index == dialogs[levelOfPuzzles].lineOfDialog.Length)
        {
            //check if win condittion meet or repeat last line of dialog.
            if (player.winCondittionMeet[levelOfPuzzles] == true)
            {
                if (levelOfPuzzles < 3)
                {
                    levelOfPuzzles++;
                    index = 0;
                    PlayDialog();
                }
                else if (levelOfPuzzles >= 3)
                {
                    // win condition 
                }
            }
            else
            {
                dialogText.text = "";
                StartCoroutine(Type());

            }
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in dialogs[levelOfPuzzles].lineOfDialog[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("llegue aca");
            playerInRange = true;
        }
        else { Debug.Log("Y aca"); }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerInRange = false;
            dialogBox.SetActive(false);
            player.talking = false;
        }
    }
}

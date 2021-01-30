using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Mom : MonoBehaviour
{
    public Dialogs[] dialogs;
    private int levelOfPuzzles;
    private int index;
    public float typingSpeed;
    public GameObject DialogBox;
    public TextMeshProUGUI textDisplay;
    public bool OnDialog;
    public Door[] doors;
    public GameObject starterDialogButton;
    public GameObject nextDialogButton;
    public Player player;
    private void Awake()
    {
        levelOfPuzzles = 0;
        index = 0;
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
                doors[levelOfPuzzles].isOpen = true;
                break;
            case 2:
                doors[levelOfPuzzles].isOpen = true;
                break;
            case 3:
                doors[levelOfPuzzles].isOpen = true;
                break;

            default:
                break;
        }
    }


    IEnumerator Type()
    {
        foreach(char letter in dialogs[levelOfPuzzles].lineOfDialog[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        
    }

    public void NextSentence()
    {
        if(index < dialogs[levelOfPuzzles].lineOfDialog.Length -1)
        {
            textDisplay.text = "";
            StartCoroutine(Type());
            index++;
            // Para deseleccionar y poder seleccionar botones.
            EventSystem.current.SetSelectedGameObject(null);
            // Settear el objeto seleccionado, osea un boton
            EventSystem.current.SetSelectedGameObject(nextDialogButton);
        } else if (index == dialogs[levelOfPuzzles].lineOfDialog.Length)
        {
            //check if win condittion meet or repeat last line of dialog.
            if (player.winCondittionMeet[levelOfPuzzles] == true)
            {
                if(levelOfPuzzles < 3)
                { 
                levelOfPuzzles++;
                index = 0;
                NextSentence();
                } else if (levelOfPuzzles >= 3)
                {
                    // win condition 
                } 
            } else
            {
                textDisplay.text = "";
                StartCoroutine(Type());
                // Para deseleccionar y poder seleccionar botones.
                EventSystem.current.SetSelectedGameObject(null);
                // Settear el objeto seleccionado, osea un boton
                EventSystem.current.SetSelectedGameObject(starterDialogButton);
            }
            
        }
    }

    public void ExitDialog()
    {
        DialogBox.SetActive(false);
    }

    public void StartDialog()
    {
        starterDialogButton.SetActive(false);
        DialogBox.SetActive(true);
        NextSentence();
        

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            starterDialogButton.SetActive(true);
            // Para deseleccionar y poder seleccionar botones.
            EventSystem.current.SetSelectedGameObject(null);
            // Settear el objeto seleccionado, osea un boton
            EventSystem.current.SetSelectedGameObject(starterDialogButton);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            starterDialogButton.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mom : MonoBehaviour
{
    public Dialogs[] dialogs;
    private int levelOfPuzzles;
    private int index;
    public float typingSpeed;
    public Canvas DialogBox;
    public TextMeshProUGUI textDisplay;
    public bool OnDialog;
    public Door[] doors;
    
    public Button nextDialogButton;
    public Button exitDialogButton;
    public Player player;

    public Canvas canvasInWorldSpace;

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
               

                
            }
            
        }
    }

    public void ExitDialog()
    {
        DialogBox.enabled = false;
    }

    public void StartDialog()
    {

        DialogBox.enabled = true;
        NextSentence();
        

        
    }

    
}

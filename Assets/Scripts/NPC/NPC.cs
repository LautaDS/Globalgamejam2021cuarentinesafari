using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    [SerializeField] private Dialog dialog;
  
    private Player mainPlayer;
    private int dialogTalked = 0;

    public System.Action OnTalk;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            mainPlayer = other.GetComponent<Player>();
            mainPlayer.OnDialogStart += Talk;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {


        if (other.GetComponent<Player>() != null)
        {
            mainPlayer.OnDialogStart -= Talk;
            DialogSystem.CloseText();
            mainPlayer = null;
        }
    }

    private void Talk()
    {
        if (OnTalk != null)
        {
            OnTalk();
        }
        DialogSystem.ShowText(dialog.GetDialog(dialogTalked));
        dialogTalked++;
    }
}

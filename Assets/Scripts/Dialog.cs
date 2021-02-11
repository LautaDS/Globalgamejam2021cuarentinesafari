using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog")]
public class Dialog : ScriptableObject
{
    [SerializeField] private string finalDialog;

    [SerializeField] private string[] lineOfDialog;


    public string GetDialog(int dialog)
    {
        if (dialog >= lineOfDialog.Length) return FinalDialog;

        string textToReturn = lineOfDialog[dialog];
        return textToReturn;
    }
 
    public string FinalDialog { get => finalDialog; set => finalDialog = value; }

}

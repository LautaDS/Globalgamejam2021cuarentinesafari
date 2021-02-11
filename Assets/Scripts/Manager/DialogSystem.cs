using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text textDialog;
    [SerializeField] private GameObject textBox;
    [SerializeField] private static DialogSystem dialogSystem;

    private void Awake()
    {
        dialogSystem = this;
    }

    public static void ShowText(string text)
    {
        if (dialogSystem == null) Debug.LogError("NOT DIALOG SYSTEM IN THE SCENE");

        dialogSystem.textBox.SetActive(true);
        dialogSystem.textDialog.text = text;

    }

    public static void CloseText()
    {
        dialogSystem.textBox.SetActive(false);
    }
}

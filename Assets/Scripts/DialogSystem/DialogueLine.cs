using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{ 
public class DialogueLine : DialogueBaseClass
{
        [Header("Text options")]
        [SerializeField]private string input;
        [SerializeField]private Color textColor;
        public Text textholder;
        [SerializeField]private Font textFont;
        [SerializeField] private float dialogSpeed;
    // Start is called before the first frame update
    void Awake()
    {
            textholder = GetComponent<Text>();

           
    }

        private void Start()
        {
            StartCoroutine(WriteText(input, textholder, textColor, textFont, dialogSpeed));
        }
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem {
    public class DialogueBaseClass : MonoBehaviour
    {
       
        public bool finished { get; private set; }

        private void Awake()
        {
            
        }
        protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float dialogSpeed)
        {
            textHolder.color = textColor;
            textHolder.font = textFont;
            textHolder.text = "";
            for(int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                yield return new WaitForSeconds(dialogSpeed);

            }
            var player = FindObjectOfType<Player>();
            yield return new WaitUntil(() => player.talking);
            finished = true;
        }
    }

}
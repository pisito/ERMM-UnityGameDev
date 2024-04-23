using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ERMM.FrameworkTool.DialogueSystem
{
    public class SelfDialogueSystem : MonoBehaviour
    {
        public TextMeshProUGUI speakerNameText;
        public Image speakerImage;
        public TextMeshProUGUI dialogueText;
        public Button continueButton; // Button to go to the next dialogue line

        private Queue<string> lines; // Queue to manage the dialogue lines

        public UnityEvent onDialogueStart;
        public UnityEvent onDialogueEnd;

        // Start is called before the first frame update
        void Start()
        {
            if (lines == null)
            {
                lines = new Queue<string>();
            }
            continueButton.onClick.AddListener(DisplayNextLine);
        }

        public void StartDialogue(DialogueData dialogueData)
        {
            BeforeStartDialogue();
            if (lines == null)
            {
                lines = new Queue<string>();
            }
            else
            {
                lines.Clear();
            }
            
            speakerNameText.text = dialogueData.speakerName;
            speakerImage.sprite = dialogueData.speakerImage;

            foreach (string line in dialogueData.dialogueLines)
            {
                lines.Enqueue(line);
            }

            DisplayNextLine();
        }

        public void DisplayNextLine()
        {
            if (lines.Count == 0)
            {
                EndDialogue();
                return;
            }

            string line = lines.Dequeue();
            dialogueText.text = line;
        }

        void BeforeStartDialogue()
        {
            Debug.Log("Dialogue started.");
            // Open the dialogue box or pause game system for the dialogue UI
            onDialogueStart?.Invoke();
        }

        void EndDialogue()
        {
            Debug.Log("Dialogue ended.");
            // Close the dialogue box or clean up the dialogue UI
            onDialogueEnd?.Invoke();
        }
    }
}

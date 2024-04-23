using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ERMM.FrameworkTool.DialogueSystem
{
    public class TriggerKeyToStartDialogue : MonoBehaviour
    {
        [SerializeField]
        private DialogueData dialogueData;
        [SerializeField]
        private SelfDialogueSystem dialogueSystem;

        [SerializeField]
        private bool isInDialogueRange = false;

        public KeyCode InteractKey = KeyCode.E;

        private void Update()
        {
            if (isInDialogueRange && Input.GetKeyDown(InteractKey))
            {
                dialogueSystem.StartDialogue(dialogueData);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            isInDialogueRange = true;
        }
        private void OnTriggerExit(Collider other)
        {
            isInDialogueRange = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ERMM.FrameworkTool.DialogueSystem
{
    [CreateAssetMenu(fileName = "DialogueData", menuName = "Visual Novel/Dialogue", order = 1)]
    public class DialogueData : ScriptableObject
    {
        public string speakerName; // Name of the character speaking
        public Sprite speakerImage; // Image of the speaker
        public string[] dialogueLines; // Array of dialogue lines
    }
}

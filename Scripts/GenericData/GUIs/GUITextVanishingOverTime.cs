using ERMM.GenericData.Utility;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ERMM.GenericData.GUIs
{
    public class GUITextVanishingOverTime : MonoBehaviour
    {
        public bool isClearTextOnStart = true;
        public float cooldownTime = 5f; // Total time for cooldown in seconds
        public TextMeshProUGUI displayText; // Reference to the Text component
        private float remainingCooldown; // Remaining cooldown time

        [SerializeField]
        private bool isDisplaying = false;
        // Start is called before the first frame update
        void Start()
        {
            if(displayText == null)
                displayText = GetComponentInChildren<TextMeshProUGUI>();

            if(isClearTextOnStart)
            {
                displayText.text = "";
            }
        }

        public void StartDisplayText(string value)
        {
            displayText.text = value;
            remainingCooldown = cooldownTime;
            // Start new coroutine if and only if it is already finished,
            // otherwise simply refresh a cooldown time is enough
            if(!isDisplaying)
                StartCoroutine(UpdateCooldown());
        }

        private IEnumerator UpdateCooldown()
        {
            isDisplaying = true;
            while (remainingCooldown > 0)
            {
                remainingCooldown -= Time.deltaTime;          
                yield return null; // Wait until the next frame
            }
            displayText.text = ""; // Clear the cooldown text
            isDisplaying = false;
            OnCooldownComplete(); // Call a method when cooldown is done
        }

        protected virtual void OnCooldownComplete()
        {
            // Optional: Add any actions that need to happen after the cooldown
            Debug.Log("Display Vanishing Text Cooldown complete!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ERMM.GenericData.Detects
{
    public class InteractableTrigger : MonoBehaviour
    {
        public UnityEvent onInteractRangeEnter;
        public UnityEvent onInteractRangeExit;
        public string targetTag = "Player";
        private void OnTriggerEnter(Collider other)
        {
            // Add interaction logic
            if (other.gameObject.CompareTag(targetTag))
            {
                Debug.Log("Enter Range of interactable object: " + other.gameObject.name);
                onInteractRangeEnter?.Invoke();
            }
        }

        //private void OnTriggerStay(Collider other)
        //{
        //    // Write any code
        //}

        private void OnTriggerExit(Collider other)
        {
            // Add interaction logic
            if (other.gameObject.CompareTag(targetTag))
            {
                Debug.Log("Exit Range of interactable object: " + other.gameObject.name);
                onInteractRangeEnter?.Invoke();
            }
        }
    }
}

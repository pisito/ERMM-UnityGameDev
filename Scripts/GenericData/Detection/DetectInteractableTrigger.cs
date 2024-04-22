using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ERMM.GenericData.Detects
{
    public class DetectInteractableTrigger : MonoBehaviour
    {
        public UnityEvent<Collider> onInteractRangeEnter;
        public UnityEvent<Collider> onInteractRangeExit;
        public string targetTag = "Interactable"; // Detect item that is interactable
        private void OnTriggerEnter(Collider other)
        {
            // Add interaction logic
            if (other.gameObject.CompareTag(targetTag))
            {
                Debug.Log("Enter Range of interactable object: " + other.gameObject.name);
                onInteractRangeEnter?.Invoke(other);
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
                onInteractRangeEnter?.Invoke(other);
            }
        }
    }
}

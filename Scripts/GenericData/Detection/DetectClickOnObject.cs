using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ERMM.GenericData.Detections
{
    public class DetectClickOnObject : MonoBehaviour
    {
        public UnityEvent onClickEvent;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0)) // Detect Left Click
            {
                // Camera Main -> Ray pointing toward where you click ->
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 2D Screen of the game view
                RaycastHit hit;

                // Perform a raycast       
                if (Physics.Raycast(ray, out hit))
                {
                    // Hit something
                    // It is your object that the script attached
                    if (hit.transform == transform)
                    {
                        // Add logic to perform behaviour
                        Debug.Log("Clicked on " + gameObject.name);
                        // Invoke click Event that has been registered to the object
                        onClickEvent?.Invoke();
                    }
                }
            }
        }
    }
}

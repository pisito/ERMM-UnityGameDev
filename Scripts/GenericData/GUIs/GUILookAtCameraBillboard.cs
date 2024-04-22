using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ERMM.GenericData.GUIs
{
    public class GUILookAtCameraBillboard : MonoBehaviour
    {
        [Tooltip("Auto-Assume main camera reference")]
        public Transform cameraTransform;
        // Start is called before the first frame update
        void Start()
        {
            if (cameraTransform == null)
                cameraTransform = Camera.main.transform;
        }

        // Update is called once per frame
        void Update()
        {
            // Make the health bar face the camera
            transform.LookAt(transform.position + cameraTransform.rotation * Vector3.forward, cameraTransform.rotation * Vector3.up);
        }
    }
}

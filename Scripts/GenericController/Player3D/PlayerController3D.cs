using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/**
 * Generic module to create a platformer 3d controller
 * Aim to work with rigidbody and custom camera oriented movement
 * Author: Pisit Praiwattana
 * email: pisit.pra@mahidol.edu
 */
namespace ERMM.GenericController.Player3D
{
    public class PlayerController3D : MonoBehaviour
    {
        [Header("Debug Flags")]
        // Movement Flags
        [SerializeField]
        Vector3 inputDirection;
        [SerializeField]
        Vector3 moveDirection;
        [SerializeField]
        bool isMoving;
        [SerializeField]
        float moveAmount;
        [SerializeField]
        Vector3 gravity;    // Gravity as a vector representing -up direction
        [SerializeField]
        bool isGrounded;
        [SerializeField]
        bool isJumping;
        [SerializeField]
        bool canDoubleJump;
        [SerializeField]
        bool isWalkMode;
        [SerializeField]
        bool isSprinting;
        [SerializeField]
        bool isCameraRotating;

        // Header Render Section Label in the inspector
        // It might prolong rebuilding time if you have mutilple public variable/ FYI
        [Header("Rotation")]
        public Transform cameraFollowTarget;
        public Transform visualTransform;   // Visual empty Game Object that serves as a root of all graphical visuals


        // Header Render Section Label in the inspector
        // It might prolong rebuilding time if you have mutilple public variable/ FYI
        [Header("Rotation")]
        public bool enableRotateCamera = false;
        public bool useCameraKey = false;
        public KeyCode cameraRotationKey = KeyCode.Mouse1;
        public float cameraLookAngle;  // Camera Look Left/Right
        public float cameraPivotAngle; // Camera Look Up/Down
        public float cameraLookSpeed = 150f;
        public float cameraPivotSpeed = 35f;
        public float minimumPivotAngle = -15f;
        public float maximumPivotAngle = 55f;
        // Option to invert mouse X movement
        public bool invertX = false;
        public bool invertY = true;

        // Configurations
        [Header("Movement Configs")]
        public LayerMask groundCheckLayer;
        public KeyCode sprintKey = KeyCode.LeftShift;
        public KeyCode walkToggleKey = KeyCode.CapsLock;
        public float walkSpeed = 2.0f;
        public float runSpeed = 4.0f;
        public float sprintSpeed = 6.0f;

        public float bodyRotationSpeed = 15.0f;
        public bool isInstantBodyRotate = false;

        public float fallMultiplier = 1.0f;
        public float jumpHeight = 7.0f;

        public float floorOffsetY = 0f;

        [Tooltip("Distance to check for the floor")]
        public float floorRaycastLength = 1.1f;
        public float floorRayAverageOffset = 0.25f;

        // Components
        public Rigidbody rb;
        public Camera mainCamera; // The camera is reference here


        // for floor correction
        Vector3 floorMovement;
        Vector3 combinedRaycast;

        

        #region Unity MonoBehaviour Loops
        // Start is called before the first frame update
        void Start()
        {
            if(rb == null)
                rb = GetComponent<Rigidbody>(); // default reference is the main camera in the scipt
            if(mainCamera == null)
                mainCamera = Camera.main; // default reference is the main camera in the scene
            if (visualTransform == null)
            {
                // Use self object instead if none is referenced
                visualTransform = transform;
            }
        }

        void Update()
        {
            HandleInputs();
            HandleBodyRotation();
            HandleCameraRotation();
        }

        // Fixed update is called during physical frame, it is less frequent than update
        void FixedUpdate()
        {
            // Calculate Gravity
            if (!isGrounded)
            {
                gravity += Vector3.up * Physics.gravity.y * Time.fixedDeltaTime * fallMultiplier;
            }

            // Handle Jump
            if (isJumping)
            {
                if (isGrounded)
                {
                    gravity = Vector3.up * jumpHeight;
                    isJumping = false;
                    // if jumping, explicity define that the character is not on the ground
                    isGrounded = false;
                }
                else if (canDoubleJump)
                {
                    gravity = Vector3.up * jumpHeight;
                    isJumping = false;
                    canDoubleJump = false;
                }
            }

            // Handle Walk Run Sprint, by default the value is run speed
            float speedFactor = 0f;
            if (isWalkMode)
            {
                speedFactor = walkSpeed;
            }
            else if (isSprinting)
            {
                speedFactor = sprintSpeed;
            }
            else
            {
                speedFactor = runSpeed;
            }

            // Handle body's final velocity
            // actual movement of the rigidbody + extra down force 
            rb.velocity = (moveDirection * speedFactor * moveAmount) + gravity;

            // When reaching the ground
            if (isGrounded)
            {
                gravity.y = 0f;
                isJumping = false;
                canDoubleJump = true;
            }
        }
        #endregion

        #region Movement Handlers
        void HandleInputs()
        {

            // Handle Look Input (Mouse)
            if(isCameraRotating && enableRotateCamera)
            {
                // Left / Right
                cameraLookAngle += (invertX) ? -Input.GetAxis("Mouse X") : Input.GetAxis("Mouse X") * cameraLookSpeed * Time.deltaTime;
                // Up / Down
                cameraPivotAngle += (invertY) ? -Input.GetAxis("Mouse Y") : Input.GetAxis("Mouse Y") * cameraPivotSpeed * Time.deltaTime;

                cameraPivotAngle = Mathf.Clamp(cameraPivotAngle, minimumPivotAngle, maximumPivotAngle);
            }

            // Use GetAxisRaw to prevent interpolation of the input by Unity
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            isMoving = horizontalInput > 0.1f || horizontalInput < -0.1f
                || verticalInput > 0.1f || verticalInput < -0.1f;

            // Find move magnitude from vertical and horizontal input
            float moveMagniture = Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput);
            moveAmount = Mathf.Clamp01(moveMagniture);

            inputDirection = new Vector3(horizontalInput, 0f, verticalInput);

            // Calibrate input with Camera
            Vector3 correctHorizontalInput = mainCamera.transform.right * horizontalInput;
            Vector3 correctVerticalInput = mainCamera.transform.forward * verticalInput;

            // Combined result into final moveDirection 
            moveDirection = correctHorizontalInput + correctVerticalInput;

            // Reduced y to zero to prevent sky walking
            moveDirection.y = 0f;

            // Normalized to prevent diagonal double speed
            moveDirection.Normalize();

            // Handle jump signal
            if (Input.GetButtonDown("Jump"))
            {
                if(isGrounded || canDoubleJump)
                    isJumping = true;
            }

            // Handle Walk Mode Toggle
            if(Input.GetKeyDown(walkToggleKey))
            {
                isWalkMode = !isWalkMode;
            }

            // Handle Sprint Key flags
            if(Input.GetKey(sprintKey))
            {
                isSprinting = true;
            }
            else
            {
                isSprinting = false;
            }

            // Handle Camera Rotation Key
            // Usually Fire 2 refer to Mouse 1 // Right Mouse Button
            if(enableRotateCamera)
            {
                if(useCameraKey)
                {
                    // Use Key hold to control rotation
                    if (Input.GetKey(cameraRotationKey) && enableRotateCamera)
                    {
                        isCameraRotating = true;
                    }
                    else
                    {
                        isCameraRotating = false;
                    }
                }
                else
                {
                    // Free Rotation
                    isCameraRotating = true;
                }
            }         
        }

        private void HandleBodyRotation()
        {
            if (moveDirection == Vector3.zero) return;
            //{
            //    moveDirection = visualTransform.forward;
            //}

            // Unit Rotation that look toward the vector3's direction
            Quaternion lookRotation = Quaternion.LookRotation(moveDirection);

            if (isInstantBodyRotate)
            {
                visualTransform.rotation = lookRotation; // Instant
            }
            else
            {
                // Rotate visual reference instead of the Player-Empty Game Object
                visualTransform.rotation = Quaternion.Slerp(
                            visualTransform.rotation,
                            lookRotation,
                            bodyRotationSpeed * Time.deltaTime);
            }
        }

        void HandleCameraRotation()
        {
            if(cameraFollowTarget == null) return;

            if (!isCameraRotating) return;

            Vector3 rotation = Vector3.zero;
            rotation.y = cameraLookAngle;
            rotation.x = cameraPivotAngle;
            // Convert Look Angle to Quaternion representation
            Quaternion targetRotation = Quaternion.Euler(rotation);
            // Assign it to main camera / camera target transform
            cameraFollowTarget.rotation = targetRotation;
        }
        #endregion

        #region GroundCheck Logic
        void OnCollisionEnter(Collision collision)
        {
            if (groundCheckLayer == (groundCheckLayer | (1 << collision.gameObject.layer)))
            {
                isGrounded = true;
            }
        }

        void OnCollisionExit(Collision collision)
        {
            if (groundCheckLayer == (groundCheckLayer | (1 << collision.gameObject.layer)))
            {
                isGrounded = false;
            }
        }
        #endregion


    }
}

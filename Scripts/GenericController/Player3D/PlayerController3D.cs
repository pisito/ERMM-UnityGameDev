using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace ERMM.GenericController.Player3D
{
    public class PlayerController3D : MonoBehaviour
    {
        public float walkSpeed = 2f;
        public float runSpeed = 3f;
        public float dashSpeed = 4f;
        public float rotationSpeed = 360f; //Speed that player turns toward the movement
        public float jumpForce = 7f;
        public LayerMask groundCheckLayer;

        public Transform myCameraTransform; // Assign the camera transform as a reference here
        public bool useCameraDirection = false; // Toggle to use camera to determine the right and forward instead of player's transform

        public Rigidbody rb;
        public Animator animator;
        public bool isGrounded = false;
        public bool canDoubleJump = true;

        [Header("Animator Config")]
        public string animSpeedParam = "Speed";


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            Jump();

            if(animator)
            {
                // XZ Movement animation
                animator.SetFloat(animSpeedParam, rb.velocity.magnitude);
                
            }
        }

        private void Move()
        {
            float horizontalInput = Input.GetAxis("Horizontal"); // -1 or 1 ; A or D
            float verticalInput = Input.GetAxis("Vertical"); // -1 or 1 ; W or S

            Vector3 movement = Vector3.zero;

            if (useCameraDirection && myCameraTransform != null)
            {
                // USe Forward and Right of the camera
                Vector3 forward = myCameraTransform.forward;
                Vector3 right = myCameraTransform.right;
                forward.y = 0f; // No need for Y value
                right.y = 0f;

                movement = (forward * verticalInput) + (right * horizontalInput);
            }
            else
            {
                movement = (transform.forward * verticalInput) + (transform.right * horizontalInput);
            }

            movement.Normalize();

            Vector3 moveDirection = new Vector3(movement.x, 0f, movement.z);

            // Body Rotation?
            if (moveDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    toRotation,
                    rotationSpeed * Time.deltaTime
                    );
            }

            ApplyMovement(moveDirection);
        }

        void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    isGrounded = false;
                    canDoubleJump = true;
                }
                else if (canDoubleJump)
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset y velocity
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    canDoubleJump = false;
                }
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (groundCheckLayer == (groundCheckLayer | (1 << collision.gameObject.layer)))
            {
                isGrounded = true;
                canDoubleJump = true;
            }
        }

        void OnCollisionExit(Collision collision)
        {
            if (groundCheckLayer == (groundCheckLayer | (1 << collision.gameObject.layer)))
            {
                isGrounded = false;
            }
        }

        void ApplyMovement(Vector3 movement)
        {
            if (movement.magnitude <= 0) return;
            //Walk
            rb.velocity = new Vector3(movement.x * walkSpeed, rb.velocity.y, movement.z * walkSpeed);
        }
    }
}

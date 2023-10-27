using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <author>
/// Authored & Written by @mattordev
/// 
/// for external use, please contact the author directly
/// </author>
namespace Necropanda.Player
{
    /// <summary>
    /// PlayerController class
    /// 
    /// This class is what drives the player, using unitys default horizontal and vertical input methods
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        public CharacterController controller; // Ref to the Character Controller Component.

        bool sprinting = false;
        float speed;
        public float walkSpeed = 6f; // The speed at which the player moves.
        public float sprintSpeed = 12f;
        public float gravity = -9.81f; // The amount of gravity that the is applied.
        public float fallMultiplyer = 1.25f;

        public Transform groundCheck; // Transform for checking whether the player is grounded.
        public float groundDistance = 0.4f; // The distance of the player to the ground.
        public LayerMask groundMask; // Used for telling the controller what ground is.
        public bool paused = false; // Defines whether the game is paused, this might not be needed.
        public bool canMove = true;

        Vector3 velocity; // The velocity(speed) of the player.
        public bool isGrounded; // Tells us whether the player is grounded.

        Vector3 right;
        Vector3 forward;
        RaycastHit hit;

        private void Start()
        {
            paused = true;
            canMove = true;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;

            SetupMovement();
        }

        void SetupMovement()
        {
            speed = walkSpeed;

            paused = false;
        }

        /// <summary>
        /// Update here, ran each frome. Here we call for the inputs.
        /// </summary>
        void Update()
        {
            controller.Move(velocity);

            if (!paused && canMove)
            {
                GetInput();
                RotateToMouse(GetWorldPhyicsMousePosition());
            }
            else
            {
                // do animations
            }

        }

        /// <summary>
        /// This function gets all of the KEYBOARD updates and converts those inputs into movement within
        /// the world space.
        /// </summary>
        void GetInput()
        {
            if (!isGrounded)
            {
                //Debug.Log(velocity.y);
                velocity.y = gravity * (fallMultiplyer - 1) * Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                sprinting = true;
                speed = sprintSpeed;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                sprinting = false;
                speed = walkSpeed;
            }

            // Check to see if the player is grounded
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


            // Get the movement axis
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            right = Camera.main.transform.right;
            right = right.normalized;
            forward = Camera.main.transform.forward;
            forward = forward.normalized;

            // Combine into one variable which gets used later
            Vector3 moveVector = right * x + forward * z;

            moveVector.Normalize();
            moveVector.y = 0;
            // Move using the controller component
            controller.Move(moveVector * speed * Time.deltaTime);

            // Calculate and apply gravity
            // velocity.y += gravity;


            bool moving = moveVector != new Vector3(0, 0, 0);

            Vector3 inputVector = new Vector3(x, 0, z);
        }

        //Rotation to mouse stuff
        public Vector3 GetWorldPhyicsMousePosition(float range = 100)
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(camRay, out hit, range);

            if (!hit.collider)
            {
                return Vector3.zero;
            }

            return hit.point;
        }

        public void RotateToMouse(Vector3 pos)
        {
            transform.LookAt(pos);
        }
    }
}
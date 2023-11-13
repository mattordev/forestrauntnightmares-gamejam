using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <author>
/// Authored & Written by @mattordev
/// 
/// for external use, please contact the author directly
/// </author>
namespace Mattordev.player
{
    public class PickupManager : MonoBehaviour
    {
        [SerializeField]
        private Vector3 pickupOffset;
        [SerializeField]
        private float pickupPointRadius = 3f;
        [SerializeField]
        private GameObject pickupPoint;
        public KeyCode pickupKey;

        public LayerMask pickupMask;
        public bool canPickup;
        [SerializeField]
        private Collider pickupable;
        public bool holding;
        Rigidbody pickupableRB;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            SetPickupPointPosition();
            GetInput();

            if (holding)
            {
                pickupable.transform.parent = pickupPoint.transform;
                pickupable.transform.position = pickupPoint.transform.position;

                // freeze the rotation
                pickupableRB = pickupable.GetComponent<Rigidbody>();
                pickupableRB.freezeRotation = true;
            }
            else
            {
                // unparent, enable phyics, clear the array
                pickupableRB.freezeRotation = false;
                pickupable.transform.parent = null;
            }
        }


        /// <summary>
        /// Sets the position of the pickup point based on the offset
        /// </summary>
        public void SetPickupPointPosition()
        {
            pickupPoint.transform.localPosition = pickupOffset;
        }

        public void GetInput()
        {
            if (Input.GetKeyDown(pickupKey))
            {
                Debug.Log("key pressed");
                CheckForPickup();
            }
        }

        private void CheckForPickup()
        {
            // Might be worth to skip the canPickup check and directly get the array on input, but that seems bad
            // Might also be a good idea to define the array size as 1, so we're not getting more than we need.
            canPickup = Physics.CheckSphere(pickupOffset, pickupPointRadius, pickupMask, QueryTriggerInteraction.Collide);
            if (canPickup == false)
                return;

            pickupable = Physics.OverlapSphere(pickupOffset, pickupPointRadius, pickupMask, QueryTriggerInteraction.Collide)[0];
            if (pickupable != null)
            {
                // Now that there's an object in the array, toggle holding
                holding = !holding;
            }
        }

        void OnDrawGizmosSelected()
        {
            // Display the explosion radius when selected
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(pickupPoint.transform.position, pickupPointRadius);
        }
    }
}

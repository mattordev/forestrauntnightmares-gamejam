using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <author>
/// Authored & Written by @mattordev
/// 
/// for external use, please contact the author directly
/// </author>
namespace Mattordev.crafting
{
    public class Slot : MonoBehaviour
    {
        public Item item;
        public int index;

        /// <summary>
        /// Check for any of the ingredients, if so, parent them and set the item?? maybe?
        /// </summary>
        /// <param name="other"></param>
        public void OnTriggerEnter(Collider other)
        {
            switch (other.gameObject.tag)
            {
                case "Water":
                    SetItem(other);
                    break;
                case "Meat":
                    SetItem(other);
                    break;
                case "Vegetable":
                    SetItem(other);
                    break;
            }
        }

        private void SetItem(Collider other)
        {
            item = other.gameObject.GetComponent<Item>();
            other.transform.parent = this.transform;
            // reset the transform
            other.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}

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
    public class CraftingManager : MonoBehaviour
    {
        private Item currentItem;
        public string currentRecipeString;
        public Slot[] craftingSlots;
        public List<Item> itemList;
        public string[] recipes;
        public GameObject[] recipeItems;
        public Item[] recipeResults;
        public Slot resultSlot;

        private void Update()
        {
            CheckForItemInSlot();
            CheckForCreatedRecipe();
        }

        public void CheckForItemInSlot()
        {
            for (int i = 0; i < craftingSlots.Length; i++)
            {
                itemList[i] = craftingSlots[i].item;
            }
        }


        /// <summary>
        /// TODO: create item on keypress, not automatically
        /// </summary>
        void CheckForCreatedRecipe()
        {
            // resultSlot.gameObject.SetActive(false);
            resultSlot.item = null;

            currentRecipeString = "";
            // forms recipe string
            foreach (Item item in itemList)
            {
                if (item != null)
                {
                    currentRecipeString += item.itemName;
                }
                else
                {
                    currentRecipeString += "null";
                }
            }

            // loops through the recipies
            for (int i = 0; i < recipes.Length; i++)
            {
                if (recipes[i] == currentRecipeString)
                {
                    resultSlot.gameObject.SetActive(true);
                    // spawn item at result slot location
                    resultSlot.item = recipeResults[i];
                    GameObject createdItem = Instantiate(recipeItems[i], resultSlot.transform.position, Quaternion.identity);
                    ClearCraftingSlots();
                }
            }
        }

        private void ClearCraftingSlots()
        {
            foreach (Slot slot in craftingSlots)
            {
                Destroy(slot.item.gameObject);
                itemList.Clear();
            }
        }
    }
}

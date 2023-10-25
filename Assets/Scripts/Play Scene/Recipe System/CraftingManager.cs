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
        public Slot[] craftingSlots;
        public List<Item> itemList;
        public string[] recipes;
        public GameObject[] recipeItems;
        public Item[] recipeResults;
        public Slot resultSlot;

        void CheckForCreatedRecipe()
        {
            resultSlot.gameObject.SetActive(false);
            resultSlot.item = null;

            string currentRecipeString = "";
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

            for (int i = 0; i < recipes.Length; i++)
            {
                if (recipes[i] == currentRecipeString)
                {
                    resultSlot.gameObject.SetActive(true);
                    // spawn item at result slot location

                    resultSlot.item = recipeResults[i];

                }
            }
        }
    }
}

using ERMM.GenericData.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

namespace ERMM.GenericData
{
    public class Inventory : MonoBehaviour
    {
        // The inventory is a list of Item objects
        public List<Item> items = new List<Item>();

        // Method to add an item to the inventory
        public void AddItem(Item item)
        {
            items.Add(item);
            Debug.Log(item.itemName + " has been added to the inventory.");
        }

        // Method to remove an item from the inventory
        public bool RemoveItem(Item item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                Debug.Log(item.itemName + " has been removed from the inventory.");
                return true;
            }
            else
            {
                Debug.Log("The item was not found in the inventory.");
                return false;
            }
        }

        public bool ContainItemName(string itemName, out Item theItem)
        {
            foreach (Item item in items)
            {
                if (item.itemName == itemName)
                {
                    theItem = item;
                    return true;
                }
            }
            theItem = null;
            return false;
        }

        // Method to display all items in the inventory
        public void DisplayInventory()
        {
            foreach (Item item in items)
            {
                item.DisplayInfo();
            }
        }

        #region Advance Features - TODO -
        /**
         * Inventory Limits: Implement a maximum size or weight limit for the inventory, requiring players to manage their items more carefully.
        Item Stacks:
            Allow certain items to stack within a single inventory slot, which is common for consumables like potions.
        Sorting and Filtering: 
            Add methods to sort items by type, name, or other properties, and to filter items to easily find what the player is looking for.
        Equipment Slots: 
            You might have specific slots for equipped items (weapons, armor, etc.), separate from the general inventory.
        **/
        #endregion

        #region Examples
        public void ExampleBasicInventory()
        {
            // Assuming these are called within a gameplay manager or similar context
            Inventory playerInventory = new Inventory();

            Item sword = new Item("Sword", "A sharp blade.", ENUM_ItemType.Equipment);
            Item healthPotion = new Consumable("Health Potion", "Restores 50 health.", 50 , 0, 0 );

            playerInventory.AddItem(sword);
            playerInventory.AddItem(healthPotion);

            playerInventory.DisplayInventory();

        }
        #endregion
    }
}

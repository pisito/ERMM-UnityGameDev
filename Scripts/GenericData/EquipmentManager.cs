using ERMM.GenericData.Items;
using ERMM.GenericData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ERMM.GenericData
{
    /**
     * EquipmentManager class responsible for equipping and unequipping items,
     * including checks for slot availability and any conditions that might prevent an action
    **/
    public class EquipmentManager : MonoBehaviour
    {
        public Dictionary<EquipmentSlot, EquipmentItem> equippedItems = new Dictionary<EquipmentSlot, EquipmentItem>();

        public UnityEvent<EquipmentItem> onEquipItem;
        public UnityEvent<EquipmentItem> onRemoveItem;

        public bool EquipItem(EquipmentItem item)
        {
            if (equippedItems.ContainsKey(item.slot))
            {
                Debug.Log("Slot already equipped. Please unequip before equipping a new item.");
                return false;
            }
            else
            {
                equippedItems[item.slot] = item;
                onEquipItem?.Invoke(item);
                ApplyStatModifiers(item);
                Debug.Log(item.itemName + " has been equipped.");
                return true;
            }
        }

        public bool UnequipItem(EquipmentSlot slot)
        {
            if (equippedItems.ContainsKey(slot))
            {
                EquipmentItem item = equippedItems[slot];
                onRemoveItem?.Invoke(item);
                RemoveStatModifiers(item);
                equippedItems.Remove(slot);
                Debug.Log(item.itemName + " has been unequipped.");
                return true;
            }
            else
            {
                Debug.Log("No item to unequip in this slot.");
                return false;
            }
        }

        private void ApplyStatModifiers(EquipmentItem item)
        {
            // Apply stat modifications to character stats here
            // Example: this.hp += item.statModifiers["hp"];
            // TODO:
        }

        private void RemoveStatModifiers(EquipmentItem item)
        {
            // Revert stat modifications to character stats here
            // Example: this.hp -= item.statModifiers["hp"];
            // TODO:
        }

        #region Advance Features - TODO -
        /**
         * You can extend it with features like checking for conditions that block equipping/unequipping actions, 
         * managing special identity tags more comprehensively, 
         * or integrating it more deeply with your game's character stat system.
        **/
        #endregion

        #region Examples
        public void ExampleBasicEquipment()
        {
            EquipmentItem sword = new EquipmentItem(
                "Excalibur",
                "The legendary sword of King Arthur",
                EquipmentSlot.Weapon,
                new Dictionary<string, int> { { "str", 5 } },
                "legendary");

            EquipmentManager playerEquipment = new EquipmentManager();
            playerEquipment.EquipItem(sword);
            // This will output: "Excalibur has been equipped."

            playerEquipment.UnequipItem(EquipmentSlot.Weapon);
            // This will output: "Excalibur has been unequipped."

        }
        #endregion
    }
}

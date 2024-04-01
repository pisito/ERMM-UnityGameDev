using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ERMM.GenericData
{
    [System.Serializable]
    public class Item : MonoBehaviour
    {
        public string itemName;
        public string description;
        public Sprite icon; // For UI representation
        public ENUM_ItemType itemType;

        // Constructor to set up an item easily
        public Item(string name, string desc, ENUM_ItemType type)
        {
            itemName = name;
            description = desc;
            itemType = type;
        }

        // This method would be overridden by subclasses to implement specific behaviors
        public virtual void Use()
        {
            Debug.Log(itemName + " used.");
        }

        // Example of a method to display the item's information
        public void DisplayInfo()
        {
            Debug.Log("Name: " + itemName + "\nDescription: " + description);
        }
    }
}

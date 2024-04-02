using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ERMM.GenericData.Items
{
    // Define Equipment Slots: Specify different types of equipment slots a character can have
    [System.Serializable]
    public class EquipmentItem : Item
    {
        public EquipmentSlot slot;
        public Dictionary<string, int> statModifiers; // Key: stat name, Value: modification amount
        public string identityTag;

        public EquipmentItem(string name, string desc, EquipmentSlot targetSlot, Dictionary<string, int> modifiers, string tag = "")
            : base(name, desc, ENUM_ItemType.Equipment) 
        {
            this.slot = targetSlot;
            this.statModifiers = modifiers;
            this.identityTag = tag;
        }
    }
}

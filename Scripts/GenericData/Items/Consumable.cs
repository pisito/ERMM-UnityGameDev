using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ERMM.GenericData.Items
{
    public class Consumable : Item
    {
        public int hpRestored;
        public int mpRestored;
        public int spRestored;
        public Character target;

        public UnityEvent onConsumableUsed;

        // Constructor
        public Consumable(string name, string desc, int health, int mana, int stamina) : base(name, desc, ENUM_ItemType.Consumable)
        {
            hpRestored = health;
            mpRestored = mana;
            spRestored = stamina;
        }

        public void SetTargetAndUse(GameObject targetObject)
        {
            target = targetObject.GetComponent<Character>();
            Use();
        }

        // Override the Use method
        public override void Use()
        {
            base.Use();
            Debug.Log(
                string.Format(
                    "Restored: {0} health, {1} mana, {2} stamina", hpRestored, mpRestored, spRestored));
            
            // Implement health restoration logic here
            target.ModifyHP(hpRestored);
            target.ModifyMP(mpRestored);
            target.ModifySP(spRestored);

            onConsumableUsed?.Invoke();
        }
    }
}

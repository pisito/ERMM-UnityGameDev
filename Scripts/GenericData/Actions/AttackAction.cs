using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ERMM.GenericData.Actions
{
    public class AttackAction : Action
    {
        public int damage;

        public AttackAction(GameObject actor, GameObject target, int damage, string requirement, UnityAction<Action> callback)
            : base(actor, target, requirement, callback)
        {
            this.damage = damage;
        }

        public override void Perform()
        {
            if (CanPerform())
            {
                Debug.Log(actor.name + " attacks " + target.name + " for " + damage + " damage.");
                // Here, you would include logic for applying damage to the target
                Character targetCharacter = target.GetComponent<Character>();
                targetCharacter.ModifyHP(damage);

                // TODO: Invove a formula to update final damage from your static game system instance

                // Call the callback method if it exists
                onActionPerformed?.Invoke(this);
                callback?.Invoke(this);
            }
            else
            {
                Debug.Log("Attack cannot be performed due to unmet requirement: " + requirement);
            }
        }
    }
}

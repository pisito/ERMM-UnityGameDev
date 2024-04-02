using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ERMM.GenericData
{
    /**
     * This class will represent any action that a character can perform in the game world.
     * Actions will include an actor (the character performing the action), 
     * an optional target (which could be another character, an item, or a location)
     * requirements (conditions that must be met to perform the action), 
     * and a callback (a method that's called after the action is executed).
     * Note that this class is not an equivalent to UnityAction:https://docs.unity3d.com/ScriptReference/Events.UnityAction.html
     **/
    public class Action : MonoBehaviour
    {
        public GameObject actor; // The character performing the action
        public GameObject target; // The optional target of the action
        public string requirement; // A conditional requirement to perform the action
        public UnityEvent<Action> onActionPerformed; // The unity Event method to be called after action execution
        public UnityAction<Action> callback; // The callback method to be called after action execution (Delegate)

        public Action(GameObject actor, GameObject target, string requirement, UnityAction<Action> callback)
        {
            this.actor = actor;
            this.target = target;
            this.requirement = requirement;
            this.callback = callback;
        }

        // Method to check if the action can be performed
        public bool CanPerform()
        {
            // No requirement
            if (string.IsNullOrEmpty(requirement)) return true;

            // Example requirement check (could be expanded based on game's mechanics)
            return actor.GetComponent<Character>().HasRequirement(requirement);
        }

        // Method to perform the action
        public virtual void Perform()
        {
            if (CanPerform())
            {
                Debug.Log(actor.name + " performs an action.");

                // Perform the action here (details depend on the action type)

                // Call the callback method if it exists
                onActionPerformed?.Invoke(this);
                callback?.Invoke(this);
            }
            else
            {
                Debug.Log("Action cannot be performed due to unmet requirement: " + requirement);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ERMM.GenericData
{
    public class Level : MonoBehaviour
    {
        public int level = 1;
        public int experience = 0;
        public int experienceForNextLevel = 10;

        public int experienceModifierForNextLevel = 2;

        // Events
        public UnityEvent<int> onLevelUp;

        // Functions
        /*
         * Return true if level up, otherwise return false;
         */
        public bool gainExperience(int amount)
        {
            experience += amount;
            if (experience >= experienceForNextLevel)
            {
                // Level up
                LevelUp();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void LevelUp()
        {
            level++;
            experience = 0;
            experienceForNextLevel = experienceForNextLevel * experienceModifierForNextLevel;
            HandleCharacerLevelUp();
        }

        public void HandleCharacerLevelUp()
        {
            onLevelUp?.Invoke(level);
        }

    }
}
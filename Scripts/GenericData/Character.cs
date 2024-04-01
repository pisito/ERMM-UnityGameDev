using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ERMM.GenericData
{
    public class Character : MonoBehaviour
    {
        public string characterName = "Default Name";
        public ENUM_CharacterRace race = ENUM_CharacterRace.Human;

        public int hp = 10;
        public int mp = 10;
        public int sp = 10;

        public int maxHp = 10;
        public int maxMP = 10;
        public int maxSP = 10;

        public UnityEvent onDeath;

        #region Modifications

        // Method to modify HP within its bounds (0 to maxHp)
        public void ModifyHP(int amount)
        {
            hp = Mathf.Clamp(hp + amount, 0, maxHp);
            if(IsDead)
            {
                handleDeath();
            }
            
        }

        // Method to modify MP within its bounds (0 to maxMP)
        public void ModifyMP(int amount)
        {
            mp = Mathf.Clamp(mp + amount, 0, maxMP);
        }

        // Method to modify SP within its bounds (0 to maxSP)
        public void ModifySP(int amount)
        {
            sp = Mathf.Clamp(sp + amount, 0, maxSP);
        }

        // Method to modify maxHp
        public void ModifyMaxHP(int amount)
        {
            maxHp += amount;
            if (maxHp < 0) maxHp = 0; // Ensure maxHp does not go below 0
            if (hp > maxHp) hp = maxHp; // Adjust current HP if it exceeds the new max
        }

        // Method to modify maxMP
        public void ModifyMaxMP(int amount)
        {
            maxMP += amount;
            if (maxMP < 0) maxMP = 0; // Ensure maxMP does not go below 0
            if (mp > maxMP) mp = maxMP; // Adjust current MP if it exceeds the new max
        }

        // Method to modify maxSP
        public void ModifyMaxSP(int amount)
        {
            maxSP += amount;
            if (maxSP < 0) maxSP = 0; // Ensure maxSP does not go below 0
            if (sp > maxSP) sp = maxSP; // Adjust current SP if it exceeds the new max
        }

        #endregion

        #region Flags
        // Method to check if the character is dead
        public bool IsDead
        {
            get { return hp <= 0; }
        }
        #endregion

        #region Events
        void handleDeath()
        {
            onDeath?.Invoke();
        }
        #endregion
    }
}
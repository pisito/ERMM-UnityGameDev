using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

        #region Optional Components
        public Sprite avatarImage;
        public Stats stats;
        public Inventory inventory;
        public EquipmentManager equipmentManager;
        public Level level;
        #endregion

        #region Events
        public UnityEvent onDeath;
        public UnityEvent<int> onHPUpdated;
        public UnityEvent<int> onMPUpdated;
        public UnityEvent<int> onSPUpdated;
        #endregion

        #region Inspector Utility 
        // - via Menu Item : https://docs.unity3d.com/ScriptReference/MenuItem.html
        [MenuItem("ERMM/Character/Link-RelatedComponents (%g)")]
        public static void LinkOptionalComponents()
        {
            Character myCharacter = Selection.activeTransform.gameObject.GetComponent<Character>() ;
            myCharacter.TryGetComponent<Stats>(out myCharacter.stats);
            myCharacter.TryGetComponent<Inventory>(out myCharacter.inventory);
            myCharacter.TryGetComponent<EquipmentManager>(out myCharacter.equipmentManager);
            myCharacter.TryGetComponent<Level>(out myCharacter.level);
        }
        [MenuItem("ERMM/Character/Link-RelatedInChildren (%h)")]
        public static void LinkOptionalComponentsInChildren()
        {
            Character myCharacter = Selection.activeTransform.gameObject.GetComponent<Character>();
            myCharacter.stats = myCharacter.GetComponentInChildren<Stats>();
            myCharacter.inventory = myCharacter.GetComponentInChildren<Inventory>();
            myCharacter.equipmentManager = myCharacter.GetComponentInChildren<EquipmentManager>();
            myCharacter.level = myCharacter.GetComponentInChildren<Level>();
        }
        #endregion

        #region Modifications

        // Method to modify HP within its bounds (0 to maxHp)
        public void ModifyHP(int amount)
        {
            hp = Mathf.Clamp(hp + amount, 0, maxHp);
            HandleHPUpdated(amount);
            if (IsDead)
            {
                HandleDeath();
            }
            
        }

        // Method to modify MP within its bounds (0 to maxMP)
        public void ModifyMP(int amount)
        {
            mp = Mathf.Clamp(mp + amount, 0, maxMP);
            HandleMPUpdated(amount);
        }

        // Method to modify SP within its bounds (0 to maxSP)
        public void ModifySP(int amount)
        {
            sp = Mathf.Clamp(sp + amount, 0, maxSP);
            HandleSPUpdated(amount); 
        }

        // Method to modify maxHp
        public void ModifyMaxHP(int amount)
        {
            maxHp += amount;
            if (maxHp < 0) maxHp = 0; // Ensure maxHp does not go below 0
            if (hp > maxHp) hp = maxHp; // Adjust current HP if it exceeds the new max
            HandleHPUpdated(amount);
        }

        // Method to modify maxMP
        public void ModifyMaxMP(int amount)
        {
            maxMP += amount;
            if (maxMP < 0) maxMP = 0; // Ensure maxMP does not go below 0
            if (mp > maxMP) mp = maxMP; // Adjust current MP if it exceeds the new max
            HandleMPUpdated(amount);
        }

        // Method to modify maxSP
        public void ModifyMaxSP(int amount)
        {
            maxSP += amount;
            if (maxSP < 0) maxSP = 0; // Ensure maxSP does not go below 0
            if (sp > maxSP) sp = maxSP; // Adjust current SP if it exceeds the new max
            HandleSPUpdated(amount);
        }

        #endregion

        #region Flags
        // Method to check if the character is dead
        public bool IsDead
        {
            get { return hp <= 0; }
        }

        // Method to check if the character meets a specific requirement
        public bool HasRequirement(string requirement)
        {
            // Example: requirement could be a stat name like "str" with a minimum value, such as "str:5"
            // Note that the name must be the string wording of enum not the display Text in the attribute
            var parts = requirement.Split(':');
            int possibleStatValue;
            Item possibleItem;
            if (parts.Length == 2 && stats.GetStatAttribute(out possibleStatValue, parts[0]))
            {
                // Checking if the character's stat meets or exceeds the required value
                return possibleStatValue >= int.Parse(parts[1]);
            }
            else if (inventory.ContainItemName(requirement, out possibleItem))
            {
                // Checking if the character has a specific item
                return true;
            }
            // Add more condition checks as needed based on your game's mechanics

            // TODO:
            // Conditional Check for multiple requirement using a { } and comma in JSON Style
            // HasRequirement currently checks both for stat-based requirements (formatted as "StatName:RequiredValue", e.g., "Strength:5")
            // and for simpler tag-based requirements (e.g., "KeyItem").
            // You can expand this to include more complex checks, such as combinations of requirements, skill levels,
            // quest states, and more, depending on your game design.

            return false; // Requirement not met or not recognized
        }
        #endregion

        #region Event Invoke
        void HandleDeath()
        {
            onDeath?.Invoke();
        }
        void HandleHPUpdated(int amount)
        {
            // Amount represent a changed value for modification
            // useful for creating a floating text
            onHPUpdated?.Invoke(amount);
        }
        void HandleMPUpdated(int amount)
        {
            // Amount represent a changed value for modification
            // useful for creating a floating text
            onMPUpdated?.Invoke(amount);
        }
        void HandleSPUpdated(int amount)
        {
            // Amount represent a changed value for modification
            // useful for creating a floating text
            onSPUpdated?.Invoke(amount);
        }
        #endregion
    }
}
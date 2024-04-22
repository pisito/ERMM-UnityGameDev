using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

namespace ERMM.GenericData.GUIs.HUDs
{
    public class GUIHPBarPanel : GUIPanelRoot
    {
        public Character myCharacter;

        public GUITextVanishingOverTime amountText;

        public bool isShowAmountText = false;

        [Tooltip("Auto-Assuming fill object is the first child of this GameObject")]
        public RectTransform healthBarFill; // The fillable part of the health bar
        public float maxHealth = 100f;
        public float currentHealth;

        public bool removeCharOnDisable = false;


        // Start is called before the first frame update
        protected override void OnStart()
        {
            currentHealth = maxHealth;

            // Assuming the health bar fill object is the first child of this GameObject
            if(healthBarFill == null)
                healthBarFill = transform.GetChild(0).GetComponent<RectTransform>();
           
            UpdateHealthBar(0);
        }

        protected override void OnShow()
        {
            // Additional behavior specific to this panel when it's shown
            Debug.Log("GUIHPBarPanel is now shown!");
            RegisterCharacter(myCharacter);
            UpdateHealthBar(0);
        }

        protected override void OnHide()
        {
            // Additional behavior specific to this panel when it's hidden
            Debug.Log("GUIHPBarPanel Panel is now hidden!");
            DeregisterCharacter();
        }

        public void RegisterCharacter(Character newCharacter)
        {
            myCharacter = newCharacter;
            if (myCharacter != null)
            {
                maxHealth = myCharacter.maxHp;
                currentHealth = myCharacter.hp;
                myCharacter.onHPUpdated.AddListener(UpdateHealthBar);
            }
        }
        public void DeregisterCharacter()
        {
            if (myCharacter != null)
            {
                myCharacter.onHPUpdated.RemoveListener(UpdateHealthBar);
            }
            if (removeCharOnDisable) myCharacter = null;
        }

        private void UpdateHealthBar(int amount )
        {
            if (myCharacter == null) return;
            maxHealth = myCharacter.maxHp;
            currentHealth = myCharacter.hp;
            // Assuming the width of the health bar's parent is 100 (for easy percentage calculation),
            // adjust the width of the fill image
            healthBarFill.sizeDelta = new Vector2(healthBarFill.sizeDelta.x * (currentHealth / maxHealth), healthBarFill.sizeDelta.y);
        
            if(isShowAmountText && amountText != null)
            {
                amountText.StartDisplayText("" + amount);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ERMM.GenericData.GUIs.HUDs
{
    public class GUICharacterPanel : GUIPanelRoot
    {
        [SerializeField]
        private Character myCharacter;
        [Tooltip("Remove reference of character on disable or not")]
        public bool removeCharOnDisable = false;
        #region GUI Components
        public Image avatarImage;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI hpText;
        public TextMeshProUGUI mpText;
        public TextMeshProUGUI spText;
        #endregion

        #region Enable DisableHook
        private void OnEnable()
        {
            Show();
        }
        private void OnDisable()
        {
            Hide();
        }
        #endregion

        public void RegisterCharacter(Character newCharacter)
        {
            myCharacter = newCharacter;
            if(myCharacter != null)
            {
                myCharacter.onHPUpdated.AddListener(UpdateHP);
                myCharacter.onMPUpdated.AddListener(UpdateMP);
                myCharacter.onSPUpdated.AddListener(UpdateSP);
            }
        }
        public void DeregisterCharacter()
        {
            if (myCharacter != null)
            {
                myCharacter.onHPUpdated.RemoveListener(UpdateHP);
                myCharacter.onMPUpdated.RemoveListener(UpdateMP);
                myCharacter.onSPUpdated.RemoveListener(UpdateSP);
            }
            if (removeCharOnDisable) myCharacter = null;
        }

        protected override void OnShow()
        {
            // Additional behavior specific to this panel when it's shown
            Debug.Log("GUICharacter Panel is now shown!");
            RegisterCharacter(myCharacter);
            RefreshGUI();
        }

        protected override void OnHide()
        {
            // Additional behavior specific to this panel when it's hidden
            Debug.Log("GUICharacter Panel is now hidden!");
            DeregisterCharacter();
        }

        #region update GUI Components
        public void RefreshGUI()
        {
            if (myCharacter != null)
            {
                avatarImage.sprite = myCharacter.avatarImage;
                nameText.text = myCharacter.name;
                hpText.text = "HP: " + myCharacter.hp + " / " + myCharacter.maxHp;
                mpText.text = "MP: " + myCharacter.mp + " / " + myCharacter.maxMP;
                spText.text = "SP: " + myCharacter.sp + " / " + myCharacter.maxSP;
            }
        }
        public void UpdateName()
        {
            if (myCharacter != null)
            {
                nameText.text = myCharacter.name;
            }
        }
        public void UpdateHP(int amount)
        {
            if (myCharacter != null)
            {
                hpText.text = "HP: " + myCharacter.hp + " / " + myCharacter.maxHp;
            }
            // TODO: Create floating text with amount
        }
        public void UpdateMP(int amount)
        {
            if (myCharacter != null)
            {
                mpText.text = "MP: " + myCharacter.mp + " / " + myCharacter.maxMP;
            }
            // TODO: Create floating text with amount
        }
        public void UpdateSP(int amount)
        {
            if (myCharacter != null)
            {
                spText.text = "SP: " + myCharacter.sp + " / " + myCharacter.maxSP;
            }
            // TODO: Create floating text with amount
        }
        public void UpdateAvatarImage()
        {
            if (myCharacter != null)
            {
                avatarImage.sprite = myCharacter.avatarImage;
            }
        }
        #endregion
    }
}

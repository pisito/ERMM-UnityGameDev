using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

namespace ERMM.GenericData.GUIs.HUDs
{
    public class GUIStatPanel : GUIPanelRoot
    {
        [SerializeField]
        private Stats myStats;
        [Tooltip("Remove reference of character on disable or not")]
        public bool removeStatsOnDisable = false;
        #region GUI Components
        public TextMeshProUGUI strText;
        public TextMeshProUGUI intText;
        public TextMeshProUGUI agiText;
        public TextMeshProUGUI vitText;
        public TextMeshProUGUI magText;
        #endregion

        public void RegisterCharacter(Stats newStats)
        {
            myStats = newStats;
            if (myStats != null)
            {
                myStats.onStatUpdated.AddListener(UpdateStat);
            }
        }
        public void DeregisterCharacter()
        {
            if (myStats != null)
            {
                myStats.onStatUpdated.RemoveListener(UpdateStat);
            }
            if (removeStatsOnDisable) myStats = null;
        }

        protected override void OnShow()
        {
            // Additional behavior specific to this panel when it's shown
            Debug.Log("GUIStatPanel  is now shown!");
            RegisterCharacter(myStats);
            RefreshGUI();
        }

        protected override void OnHide()
        {
            // Additional behavior specific to this panel when it's hidden
            Debug.Log("GUIStatPanel Panel is now hidden!");
            DeregisterCharacter();
        }

        #region update GUI Components
        public void RefreshGUI()
        {
            if (myStats != null)
            {
                UpdateStat();
            }
        }
        public void UpdateStat()
        {
            if (myStats != null)
            {
                strText.text = "Strength: " + myStats.str;
                intText.text = "Intelligent: " + myStats.intg;
                agiText.text = "Agility: " + myStats.agi;
                vitText.text = "Vitality: " + myStats.vit;
                magText.text = "Magic: " + myStats.mag;
            }
        }
        #endregion
    }
}

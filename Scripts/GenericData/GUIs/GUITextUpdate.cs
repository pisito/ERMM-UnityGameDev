using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace ERMM.GenericData.GUIs
{
    public class GUITextUpdate : MonoBehaviour
    {
        public TextMeshProUGUI textMeshProUGUI;

        public void SetText(string value)
        {
            textMeshProUGUI.SetText(value);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TowerDefence.Towers;

namespace TowerDefence.Managers
{
    [ExecuteInEditMode()]
    public class Tooltip : MonoBehaviour
    {
        public TextMeshProUGUI tooltipText;
        public LayoutElement layoutElement;

        public int characterWrapLimit;

        public void SetText(string content)
        {
            if(string.IsNullOrEmpty(content))
            { tooltipText.gameObject.SetActive(false); }
            else
            { tooltipText.gameObject.SetActive(true); }
            tooltipText.text = content;

            int tipLength = tooltipText.text.Length;

            //check the tooltip string length and see if the layout element should be enabled or not.
            layoutElement.enabled = (tipLength > characterWrapLimit) ? true : false;
        }

    }
}
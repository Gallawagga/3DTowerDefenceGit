using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TowerDefence.Towers;

namespace TowerDefence.Managers
{
    public class TooltipSystem : MonoBehaviour
    {
        private static TooltipSystem instance;
        public Tooltip tooltip;

        private void Awake()
        {
                instance = this;
        }

        public static void ShowTooltip(string _content)
        {
            instance.tooltip.SetText(_content);
            instance.tooltip.gameObject.SetActive(true);
        }

        public static void HideTooltip()
        {
            instance.tooltip.gameObject.SetActive(false);
        }

    }
}
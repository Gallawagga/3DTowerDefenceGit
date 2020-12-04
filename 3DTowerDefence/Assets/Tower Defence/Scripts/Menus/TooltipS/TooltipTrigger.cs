using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TowerDefence.Towers;
using UnityEngine.EventSystems;

namespace TowerDefence.Managers
{

    public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public string toolTipBody;
        TowerManager towerManager;
        public int towerNo;

        public void Start()
        {
            //retrieve the stored information from the assosciated spawn tower
            towerManager = TowerManager.instance;
            toolTipBody = towerManager.spawnableTowers[towerNo].UiDisplayText;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            TooltipSystem.ShowTooltip(toolTipBody);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            TooltipSystem.HideTooltip();
        }
    }
}
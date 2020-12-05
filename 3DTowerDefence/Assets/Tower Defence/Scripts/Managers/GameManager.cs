using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TowerDefence;

namespace TowerDefence.Managers
{

    public class GameManager : MonoBehaviour
    {
        [Header("UI Elements")]
        public TextMeshProUGUI playerMoneyDisplay;
        public TextMeshProUGUI playerBaseHealth;
        public GameObject valueBoxes;               //the GUI elements that show the player's base health and money

        Player player;

        void Start()
        {
            player = Player.instance;
            Cursor.visible = true;
        }
        void Update()
        {
            if (Time.timeScale == 1) //If the game is NOT paused
            {
                valueBoxes.SetActive(true);
                playerMoneyDisplay.text = player.Money + "";
                playerBaseHealth.text = player.BaseHealth + "";
            }
            else
            {
                valueBoxes.SetActive(false);       
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TowerDefence.Enemies;
using TowerDefence.Towers;

namespace TowerDefence
{
    public class Player : MonoBehaviour
    {
        public int Money { get => money; set { money = value; } }
        public int BaseHealth { get => baseHealth; set { baseHealth = value; } }

        /// <summary>
        /// The reference to the only player gameObject in the game.
        /// </summary>
        public static Player instance = null;

        [SerializeField, Tooltip("This sets the initial amount of money the player has.")]
        private int money = 100;
        [SerializeField, Tooltip("Current health of the player's base")]
        private int baseHealth = 100;

        void Awake()
        {
            // If the instance doesn't already exist, make it me.
            if (instance == null)
            {
                instance = this;
            }
            // Is the instance already set? and not me?
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }

            // This should only happen to the instance
            DontDestroyOnLoad(gameObject);
        }
        /// <summary>
        /// Gives the player the passed amount of money.
        /// </summary>
        public void AddMoney(int _money)
        {
            money += _money;
        }

        /// <summary>
        /// Gives the player the passed amount of money from the dead enemy. 
        /// </summary>
        public void AddMoney(Enemies.Enemy _enemy) //referencing dead enemy when called. 
        {
            money += _enemy.Money;              
        }

        /// <summary>
        /// Handles the removal of money when purchasing a tower and 
        /// notifies the TowerManager to place the tower
        /// </summary>
        /// <param name="_tower">The tower being purchased.</param>
        public void PurchaseTower(Tower _tower)
        {
            money -= _tower.Cost;
        }
    }
}
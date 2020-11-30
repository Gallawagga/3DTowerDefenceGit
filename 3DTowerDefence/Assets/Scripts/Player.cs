using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Towers;

namespace TowerDefence
{
    public class Player : MonoBehaviour
    {
        /// <summary>
        /// The reference to the only player gameObject in the game.
        /// </summary>
        public static Player instance = null;

        [SerializeField, Tooltip("This sets the initial amount of money the player has.")]
        private int money = 100;

        /// <summary>
        /// Gives the player the passed amount of money.
        /// </summary>
        public void AddMoney(int moneyToAdd)
        {
            money = moneyToAdd;
        }

        /// <summary>
        /// Handles the removal of money when purchasing a tower and notifies the TowerManager to place the tower.
        /// </summary>
        /// <param name="tower">The tower being purchased.</param>
        public void PurchaseTower(Tower tower)
        {
            money -= tower.Cost;
        }

        void Awake()
        {
            // if instance doesn't already exist, make it me
            if (instance == null)
            {
                instance = this;
            }
            // is the instance already set? and it's not me?
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }

            // this should only happen to the instance 
            DontDestroyOnLoad(gameObject);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

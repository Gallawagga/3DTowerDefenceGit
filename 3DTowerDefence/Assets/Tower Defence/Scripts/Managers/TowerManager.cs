using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Towers;

namespace TowerDefence.Managers
{
    public class TowerManager : MonoBehaviour
    {
        public static TowerManager instance = null; //making sure there is only one instance in the game, defined logically in the Awake Function.

        public List<Tower> spawnableTowers = new List<Tower>();
        private List<Tower> aliveTowers = new List<Tower>();
        [HideInInspector] public Tower towerToPurchase;


        public void PurchaseTower(TowerPlatform _platform)
        {
            Player.instance.PurchaseTower(towerToPurchase);
            Tower newTower = Instantiate(towerToPurchase);
            _platform.AddTower(newTower);
            aliveTowers.Add(newTower);

        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            towerToPurchase = spawnableTowers[0];
        }

    }
}
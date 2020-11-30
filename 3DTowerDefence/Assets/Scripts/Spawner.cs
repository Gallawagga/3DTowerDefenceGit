using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Managers;

namespace TowerDefence.Enemies
{

    public class Spawner : MonoBehaviour
    {
        public float SpawnRate
        {
            get
            {
                return SpawnRate;
            }
        }

        [SerializeField]
        private float spawnRate = 1;
        private float currentTime = 0;
        private EnemyManager enemyManager;
        
        
        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //increment the time by deltaTime if the current time is less than the spawn Rate
            if (currentTime < SpawnRate)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                currentTime = 0;
                //attempt to spawn the enemy via Enemymanager Singleton
                if (enemyManager != null)
                {
                    //enemyManager.SpawnEnemy(transform);
                }

            }
        }
    }
}

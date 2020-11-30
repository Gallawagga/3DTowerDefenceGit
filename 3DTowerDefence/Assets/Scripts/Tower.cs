using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Enemies;
using TowerDefence.Managers;


namespace TowerDefence.Towers
{
    public class Tower : MonoBehaviour
    {
        #region PROPERTIES
        public string TowerName
        {
            get => towerName;
        }

        public string Description
        {
            get => description;
        }

        public int Cost
        {
            get => cost;
        }

        public string UiDisplayText
        {
            get
            {

                string display = string.Format("Name: {0} Cost: {1}\n", TowerName, Cost.ToString());
                display += Description + "\n";
                //don't need the .ToString's, just there to remind us that the {0}, {1}, and {2} are all values connected to variables (listed in stats below) that will be shown as strings
                display += string.Format("Min Range: {0}, Max Range: {1}, Damage: {2}", minimumRange.ToString(), maximumRange.ToString(), damage.ToString());
                return display;
            }
        }
        private float RequiredXP
        {
            get
            {
                if (level == 1)
                {
                    return baseRequiredXp;
                }
                return baseRequiredXp * (level * experienceScaler);
            }
        }

        private float MinimumRange
        {
            get
            {
                //multiplying is faster than dividing
                return minimumRange * (level * 0.5f + 0.5f);
            }
        }
        private float MaximumRange
        {
            get
            {
                //multiplying is faster than dividing
                return maximumRange * (level * 0.5f + 0.5f);
            }
        }
        public float Damage
        {
            get
            {
                //multiplying is faster than dividing
                return damage * (level * 0.5f + 0.5f);
            }
        }
        #endregion



        [Header("General Stats")]
        [SerializeField]
        private string towerName = "";
        [SerializeField, TextArea]
        private string description = "";
        [SerializeField, Range(1, 10)]
        private int cost = 1;

        [Header("Attack Stats")]
        [SerializeField, Min(0.1f)]
        private float damage = 1;
        [SerializeField, Min(0.1f)]
        private float minimumRange = 1;
        [SerializeField]
        private float maximumRange = 5;
        [SerializeField, Min(0.1f)]
        private float fireRate = 0.1f;

        [Header("Experience Stats")]
        [SerializeField, Range(2, 5)]
        private int maxLevel = 3;
        [SerializeField, Min(1)]
        private int baseRequiredXp = 5;
        [SerializeField, Min(1)]
        private float experienceScaler = 1;

        private int level = 1;
        private int xp = 0;
        private Enemy target = null;

        private float currentTime = 0;

#if UNITY_EDITOR
        //OnValidate runs whenever a variable is changed within the inspector of this class
        private void OnValidate()
        {
            maximumRange = Mathf.Clamp(maximumRange, minimumRange + 1, float.MaxValue);
        }

        //OnDrawGizmosSelected draws helpful visuals only when the object is selected
        private void OnDrawGizmosSelected()
        {
            //Draw a mostly transparent red sphere indicating the minimum range
            Gizmos.color = new Color(1, 0, 0, 0.25f);
            Gizmos.DrawSphere(transform.position, minimumRange);

            //Draw a mostly transparent red sphere indicating the minimum range
            Gizmos.color = new Color(0, 0, 1, 0.25f);
            Gizmos.DrawSphere(transform.position, maximumRange);
        }
#endif


        public void LevelUp()
        {
            level++;
            xp = 0;

        }


        private void Fire()
        {
            if (target != null)
            {
                target.Damage(this);

                //Render attack visuals
            }
        }

        private void FireWhenReady()
        {
            if (target != null)
            {
                if (currentTime < fireRate)
                {
                    currentTime += Time.deltaTime;
                }
                else
                {
                    currentTime = 0;
                    Fire();
                }
            }
        }

        private void Target()
        {
            //get enemies within range
            Enemy[] closeEnemies = EnemyManager.instance.GetClosestEnemies(transform, maximumRange, minimumRange);
            {

                //call get closest enemy
                target = GetClosestEnemy(closeEnemies);

            }



        }

        //_enemies is the array of enemies within range
        private Enemy GetClosestEnemy(Enemy[] _enemies)
        {
            float closestDist = 0;
            Enemy closest = null;

            foreach (Enemy enemy in _enemies)
            {
                //Distance between us and the enemy
                float distToEnemy = Vector3.Distance(enemy.transform.position, transform.position);

                if (distToEnemy < closestDist)
                {
                    closestDist = distToEnemy;
                    closest = enemy;
                }
            }

            return closest;
        }

        void Update()
        {
            FireWhenReady();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence;


namespace TowerDefence.Enemies
{
    public class EnemyGoal : MonoBehaviour
    {
        /// <summary>
        /// The objective all enemies spawned are going to move toward via navmesh navigation.
        /// </summary>
        public static GameObject enemyGoalObject;

        public delegate void BaseAttackDelegate();
        public static BaseAttackDelegate attackPlayerBase;


        void Awake()
        {
            enemyGoalObject = gameObject;
        }
        /// <summary>
        /// When the enemy reaches the player base, it explodes!
        /// Was going to use a delegate and trigger multiple functions, but its total overkill, Enemy handles all the functions (in one: AttackBase) anyway!
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            Enemy _enemy = other.gameObject.GetComponent<Enemy>();
            if (_enemy != null)
            {
                _enemy.AttackBase();
            }
        }
    }
}
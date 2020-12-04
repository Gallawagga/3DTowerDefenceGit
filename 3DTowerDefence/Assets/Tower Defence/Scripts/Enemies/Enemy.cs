using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using TowerDefence.Towers;
using TowerDefence.Managers;

namespace TowerDefence.Enemies
{
    public class Enemy : MonoBehaviour
    {

        [System.Serializable]
        public class DeathEvent : UnityEvent<Enemy> { } //inherits from UnityEvents and takes in <Enemy> as a parameter
        public float XP { get => xp; }
        //all hail the lambda.
        public float Health { get => health; }       //this..
        public int Money { get { return money; } }  //...and this have the same property getter/accessor, just laid out differently
       

        [Header("General Stats")]
        [SerializeField, Tooltip("How fast the enemy will move within the game.")]
        private float speed = 1;
        [SerializeField, Tooltip("How much damage the enemy can take before dying.")]
        private float health = 1;
        [SerializeField, Tooltip("How much damage the enemy will do to the player's base's health.")]
        private int baseDamage = 1;
        // RESISTANCE HERE

        [Header("Rewards")]
        [SerializeField, Tooltip("The amount of experience the killing tower will gain from killing this enemy.")]
        private int xp = 1;
        [SerializeField, Tooltip("The amount of money the player will gain upon killing this enemy.")]
        private int money = 1; 

        [Space]

        [SerializeField]
        private DeathEvent onDeath = new DeathEvent();
        [SerializeField]
        private NavMeshAgent agent;
        [SerializeField]
        public GameObject goal;

        private EnemyManager manager;
        private Player player; // The reference to the player gameObject within the scene.


        void Start()
        {
            //Accessing the only enemy manager in the game
            manager = EnemyManager.instance;
            // Accessing the only player in the game.
            player = Player.instance;
            //setting movement goal!
            goal = EnemyGoal.enemyGoalObject;
            agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(goal.transform.position); //using navmesh - super handy!

            onDeath.AddListener(player.AddMoney); //subscribing to the even 'onDeath' - Add listener will mean that that method (onDeath) is going to get called from the event you give it.
        }

        /// <summary>
        /// Handles damage of the enemy and if below or equal to 0, calls Die
        /// </summary>
        /// <param name="_tower">The tower doing the damage to the enemy.</param>
        public void Damage(float _damage)
        {
            health -= _damage;
            if (health <= 0)
            {
                Die();
                DeathVisuals(Color.blue);
            }
        }

        /// <summary>
        /// the enemy explodes, damaging the player's base. 
        /// </summary>
        public void AttackBase () 
        {
            player.BaseHealth -= baseDamage;
            DeathVisuals(Color.red);
            manager.KillEnemy(this);
            Destroy(gameObject);
        }

        /// <summary>
        /// Handles the visual, and technical features of dying, such as giving the tower experience.
        /// </summary>
        private void Die()
        {
            onDeath.Invoke(this); //anything subscribed to 'onDeath' will fire when invoked. 
            player.AddMoney(money);
            manager.KillEnemy(this);
            // Visuals
        }

        private void DeathVisuals (Color color)
        {
            //explosion of a certain colour! Blue = good, red = bad!
        }
    }
}
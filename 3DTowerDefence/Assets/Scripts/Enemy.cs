using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;
using TowerDefence.Towers;


namespace TowerDefence.Enemies
{

    public class Enemy : MonoBehaviour
    {
        // Start is called before the first frame update

        /**
         * speed
         * health
         * damage
         * xp given
         * size
         * money given
         * resistance?
         */

        [Header("General Stats")]
        [SerializeField]
        private float speed = 1;
        [SerializeField]
        private float health = 1;
        [SerializeField]
        private float damage = 1;
        [SerializeField]
        private float size = 1;

        [Header("Rewards")]
        [SerializeField]
        private float money = 1;
        [SerializeField]
        private float xp = 1;

        public void Damage(Tower _tower)
        {
            health -= _tower.Damage;
            if (health <= 0)
            {
                Die(_tower);
            }
        }

        private void Die(Tower _tower)
        {
            //_tower.AddExperience(xp);
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace TowerDefence.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        private NavMeshAgent agent;
        public GameObject goal;

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            goal = EnemyGoal.enemyGoalObject;
            agent.SetDestination(goal.transform.position);
        }
    }
}
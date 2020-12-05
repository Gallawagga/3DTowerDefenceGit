using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Utilities;

namespace TowerDefence.Towers
{
    public class BasicTower : Tower
    {
        [Header("Basic Tower Specifics")]
        [SerializeField] private Transform turret;
        [SerializeField] private LineRenderer bulletLine;
        [SerializeField] private Transform firePoint;
        //[SerializeField] private;

        private float resetTime = 0;
        private float visualRate = 0.1f;
        private bool hasResetVisuals = false;

        protected override void RenderAttackVisuals()
        {
            MathsUtils.DistanceAndDirection(out float _distance, out Vector3 direction, turret, TargetedEnemy.transform);
            turret.rotation = Quaternion.LookRotation(direction);
            RenderBulletLine(firePoint);
            hasResetVisuals = false;
        }

        protected override void RenderLevelUpVisuals()
        {
            
        }



        protected override void Update()
        {
            base.Update();

            // Detect if we have no enemy AND that we haven't already reset the visuals
            if (TargetedEnemy == null && !hasResetVisuals)
            {
                // Check if the current time is less than the fire rate
                if (resetTime < visualRate)
                {
                    // Add to the currentTime
                    resetTime += Time.deltaTime;
                }
                else
                {
                    // Disable line renderer
                    // Reset timer to 0
                    // Set reset visuals flag to true
                    bulletLine.positionCount = 0;
                    resetTime = 0;
                    hasResetVisuals = true;
                }
            }
        }

        private void RenderBulletLine(Transform _start)
        {
            // Spawns a line with two points from the start to the targeted enemy
            bulletLine.positionCount = 2;
            bulletLine.SetPosition(0, _start.position);
            bulletLine.SetPosition(1, TargetedEnemy.transform.position);

        }
    }
}
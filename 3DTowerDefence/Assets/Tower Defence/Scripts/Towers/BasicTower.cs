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
        protected override void RenderAttackVisuals()
        {
            MathsUtils.DistanceAndDirection(out float _distance, out Vector3 direction, turret, TargetedEnemy.transform);
            turret.rotation = Quaternion.LookRotation(direction);
        }

        protected override void RenderLevelUpVisuals()
        {

        }

        private void RenderBulletLine(Transform _start)
        {
            // Spawns a line with two points from the start to the targeted enemy
            bulletLine.SetPosition(0, _start.position);
            bulletLine.SetPosition(1, TargetedEnemy.transform.position);
        }
    }
}
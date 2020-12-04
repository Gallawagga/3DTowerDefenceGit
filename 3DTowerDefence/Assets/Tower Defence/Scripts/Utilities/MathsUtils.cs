using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Utilities
{
    public class MathsUtils
    {
        public static void DistanceAndDirection(out float _distance, out Vector3 _direction, Transform _from, Transform _to)
        {
            Vector3 heading = _to.position - _from.position;
            _distance = heading.magnitude;
            _direction = heading.normalized;
        }
        // these two functions have the same name and return types/accessors BUT they take different parameters and therefore whichever parameters you use the compiler will know which function to call. 
        public static void DistanceAndDirection(out float _distance, out Vector3 _direction, Vector3 _from, Vector3 _to)
        {
            Vector3 heading = _to - _from;
            _distance = heading.magnitude;
            _direction = heading.normalized;
        }
    }
}

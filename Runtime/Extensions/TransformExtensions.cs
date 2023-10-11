using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class TransformExtensions
    {
        public static bool IsNear(this Transform from, Transform to, in float distance)
        {
            return (from.position - to.position).sqrMagnitude <= distance * distance;
        }

        public static bool IsNear(this Transform from, in Vector3 to, in float distance)
        {
            return (from.position - to).sqrMagnitude <= distance * distance;
        }

        public static bool IsNear2D(this Transform from, Transform to, in float distance)
        {
            var p1 = from.position;
            p1.z = 0;
            var p2 = to.position;
            p2.z = 0;
            return (p2 - p1).sqrMagnitude <= distance * distance;
        }

        public static bool IsNear2D(this Transform from, Vector3 to, in float distance)
        {
            to.z = from.position.z;
            return (to - from.position).sqrMagnitude <= distance * distance;
        }

        public static void DestroyChildren(this Transform t)
        {
            for (var i = t.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(t.GetChild(i).gameObject);
           }
        }

        public static void LookAt2D(this Transform t, Transform target)
        {
            t.LookAt2D(target.position);
        }

        public static void LookAt2D(this Transform t, Vector3 target)
        {
            Vector2 dir = (target - t.position).normalized;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; 
            var offset = 90f;
            t.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
        }

        public static bool IsForward(this Transform t, Transform target, float degrees)
        {
            return IsForward(t, target.position, degrees);
        }

        public static bool IsForward(this Transform t, Vector3 target, float degrees)
        {
            var dir = target - t.position;
            return Vector3.Angle(t.forward, dir) < degrees * 0.5f;
        }

        public static bool IsForward2D(this Transform t, Transform target, float degrees)
        {
            return IsForward2D(t, target.position, degrees);
        }

        public static bool IsForward2D(this Transform t, Vector3 target, float degrees)
        {
            var forward = t.forward;
            var dir = target - t.position;
            dir.z = forward.z;
            return Vector3.Angle(forward, dir) < degrees * 0.5f;
        }
    }
}
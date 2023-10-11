using UnityEngine;

namespace Extensions
{
    public static class GizmosUtils
    {
        public static void DrawCircle(Vector3 position, float radius, Vector3 direction = default, int vertexCount = 16)
        {
            if(direction.Equals(default))
            {
                direction = Vector3.up;
            }

            vertexCount = Mathf.Max(vertexCount, 4);
            var rotation = Quaternion.LookRotation(direction);
            Vector3 previousPosition = Vector3.zero;
            float step = 2f * Mathf.PI / vertexCount;
            float offset = Mathf.PI * 0.5f + ((vertexCount % 2 == 0) ? step * 0.5f : 0f);

            for (int i = 0; i <= vertexCount; i++)
            {
                float theta = step * i + offset;

                float x = radius * Mathf.Cos(theta);
                float y = radius * Mathf.Sin(theta);

                Vector3 nextPosition = position + rotation * new Vector3(x, y, 0f);

                if (i == 0)
                {
                    previousPosition = nextPosition;
                }
                else
                {
                    Gizmos.DrawLine(previousPosition, nextPosition);
                }

                previousPosition = nextPosition;
            }
        }

        public static void DrawArrow(Vector3 from, Vector3 to, float headSize = 0.25f, float headAngle = 25f)
        {
            var direction = to - from;
            Gizmos.DrawRay(from, direction);
       
            Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0,180+headAngle,0) * new Vector3(0,0,1);
            Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0,180-headAngle,0) * new Vector3(0,0,1);
            Gizmos.DrawRay(from + direction, right * headSize);
            Gizmos.DrawRay(from + direction, left * headSize);
        }
    }
}
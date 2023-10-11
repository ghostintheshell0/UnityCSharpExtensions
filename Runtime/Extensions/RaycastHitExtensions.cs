using UnityEngine;

namespace Extensions
{
    public static class RaycastHitExtensions
    {
        private static readonly RaycastHit[] results = new RaycastHit[8];

        public static bool TryGetInRaycast<T>(in Ray ray, float maxDistance, LayerMask layerMask, out T result) where T : Component
        {
            var count = Physics.RaycastNonAlloc(ray, results, maxDistance, layerMask);
            return TryGetInResults(count, out result);
        }

        public static bool TryGetInRaycast<T>(in Ray ray, LayerMask layerMask, out T result) where T : Component
        {
            var count = Physics.RaycastNonAlloc(ray, results, layerMask);
            return TryGetInResults(count, out result);
        }

        public static bool TryGetInRaycast<T>(in Ray ray, out T result) where T : Component
        {
            var count = Physics.RaycastNonAlloc(ray, results);
            return TryGetInResults(count, out result);
            
        }

        private static bool TryGetInResults<T>(int count, out T result) where T : Component
        {
            for(var i = 0; i < count; i++)
            {
                if(results[i].collider.TryGetComponent(out result))
                {
                    return true;
                }
            }

            result = default;
            return false;
        }
    }
}
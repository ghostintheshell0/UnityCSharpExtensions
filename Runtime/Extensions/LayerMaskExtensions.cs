using UnityEngine;

namespace Extensions
{
    public static class LayerMaskExtensions
    {
		public static bool HasLayer(this in LayerMask mask, in int layer)
		{
			return mask == (mask | (1 << layer));
		}
    }
}
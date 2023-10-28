using UnityEngine;

namespace Extensions
{
    public static class LayerMaskExtensions
    {
		public static bool HasLayer(this in LayerMask mask, in LayerMask layer)
		{
			return mask == (mask | (1 << layer));
		}
		
		public static void AddLayer(this ref LayerMask mask, in LayerMask layer)
		{
			int result = mask | layer;
			mask = result;
		}
		
		public static void RemoveLayer(this ref LayerMask mask, in LayerMask layer)
		{
			int result = mask & ~layer;
			mask = result;
		}
	}
}
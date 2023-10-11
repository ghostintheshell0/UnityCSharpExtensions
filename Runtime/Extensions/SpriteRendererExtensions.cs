using UnityEngine;

namespace Extensions
{
    public static class SpriteRendererExtensions
    {
        public static void SetAlpha(this SpriteRenderer sprite, float alpha)
        {
            var color = sprite.color;
            color.a = alpha;
            sprite.color = color;
        }

        public static void ScaleMin(this SpriteRenderer sprite, Rect bounds)
        {
            ScaleMin(sprite, bounds.size);
        }

        public static void ScaleMin(this SpriteRenderer sprite, Vector2 size)
        {
            var spriteSize = sprite.bounds.size;
            var w = spriteSize.x / size.x;
            var h = spriteSize.y / size.y;
            var scale = Mathf.Min(w, h);
            sprite.transform.localScale = new Vector3(scale, scale, scale);
        }

        public static void ScaleMax(this SpriteRenderer sprite, Rect bounds)
        {
            ScaleMax(sprite, bounds.size);
        }

        public static void ScaleMax(this SpriteRenderer sprite, Vector2 size)
        {
            var spriteSize = sprite.bounds.size;
            var w = spriteSize.x / size.x;
            var h = spriteSize.y / size.y;
            var scale = Mathf.Max(w, h);
            sprite.transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
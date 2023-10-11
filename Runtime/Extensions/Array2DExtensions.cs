using System;
using UnityEngine;

namespace Extensions
{
    public static class Array2DExtensions
    {
        public static bool IsOutOfRange<T>(this T[,] arr, in Vector2Int pos)
        {
            return pos.x < 0 || pos.x >= arr.GetLength(0) || pos.y < 0 || pos.y >= arr.GetLength(1);
        }

        public static T Get<T>(this T[,] arr, in Vector2Int pos)
        {
            return arr[pos.x, pos.y];
        }

        public static void Set<T>(this T[,] arr, in Vector2Int pos, in T value)
        {
            arr[pos.x, pos.y] = value;
        }

        public static void Clear<T>(this T[,] arr)
        {
            arr.Fill(default);
        }

        public static void Fill<T>(this T[,] arr, T value)
        {
            var w = arr.GetLength(0);
            var h = arr.GetLength(1);

            for(var ix = 0; ix < w; ix++)
            {
                for(var iy = 0; iy < h; iy++)
                {
                    arr[ix, iy] = value;
                }
            }
        }

        public static void Clear<T>(this T[,] arr, in Vector2Int pos)
        {
            arr[pos.x, pos.y] = default;
        }
    }
}

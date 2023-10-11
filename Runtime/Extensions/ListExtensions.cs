using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class ListExtensions
    {
        public static T GetRandom<T>(this IList<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        public static void Swap<T>(this IList<T> list, int a, int b)
        {
            var refA = list[a];
            list[a] = list[b];
            list[b] = refA;
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            for(var i = 0; i < list.Count; i++)
            {
                var r = Random.Range(0, list.Count);
                list.Swap(i, r);
            }
        }

        public static T Extract<T>(this IList<T> list, int index)
        {
            var item = list[index];
            list.RemoveAt(index);
            return item;
        }
        
        public static T ExtractLast<T>(this IList<T> list)
        {
            return Extract(list, list.Count - 1);
        }

        public static T ExtractRandom<T>(this IList<T> list)
        {
            return Extract(list, Random.Range(0, list.Count));
        }
    }
}
using Leopotam.Ecs;

namespace Extensions
{
    public static class EcsFilterExtensions
    {
        public static void Clear<T>(this EcsFilter<T> filter) where T : struct
        {
            foreach(var i in filter)
            {
                ref var ent = ref filter.GetEntity(i);
                ent.Del<T>();
            }
        }

        public static void DestroyEntities<T>(this EcsFilter<T> filter) where T : struct
        {
            foreach(var i in filter)
            {
                ref var ent = ref filter.GetEntity(i);
                ent.Destroy();
            }
        }
    }
}
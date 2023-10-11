using System.Collections.Generic;
using UnityEngine;


namespace Extensions
{
    public abstract class ListView<V, T> : MonoBehaviour where V : IView<T>
    {
        private readonly Dictionary<T, V> _views = new();
        private readonly List<V> _pool = new();

        public void Add(in T item)
        {
            var view = GetOrCreateItem();
            _views.Add(item, view);
            InitView(view);
            view.Item = item;
        }

        public void Remove(in T item)
        {
            var view = _views[item];
            _views.Remove(item);
            _pool.Add(view);
        }

        public void Clear()
        {
            foreach(var view in _views.Values)
            {
                _pool.Add(view);
            }
            _views.Clear();
        }

        public virtual V GetView(T item)
        {
            return _views[item];
        }

        protected abstract void InitView(V view);

        private V GetOrCreateItem()
        {
            return _pool.Count > 0 ? _pool.ExtractLast() : InstantiateView();
        }

        protected abstract V InstantiateView();

        protected abstract void Enable(V view);

        protected abstract void Disable(V view);
    }
}
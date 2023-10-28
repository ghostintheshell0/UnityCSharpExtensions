using System;
using UnityEngine;


namespace Extensions
{
    /// Example
    /// 
    ///public class ExampleListView : MonoListView<ExampleView, Data> { }
 
    public class MonoListView<V, T> : ListView<V, T> where V : MonoView<T>
    {
        public event Action<T> SelectionChanged;

        public V Prefab;
        public Transform Container;


        protected override V InstantiateView()
        {
            var result = Instantiate(Prefab, Container);
            result.Button.onClick.AddListener(()=>OnClick(result));
            return result;
        }

        private void OnClick(V view)
        {
            SelectionChanged?.Invoke(view.Item);
        }

        protected override void Enable(V view)
        {
            view.transform.SetAsLastSibling();
            view.gameObject.SetActive(true);
        }

        protected override void Disable(V view)
        {
            view.gameObject.SetActive(false);
        }
    }
}
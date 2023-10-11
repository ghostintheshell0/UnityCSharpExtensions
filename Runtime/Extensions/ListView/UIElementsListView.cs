using System;
using UnityEngine.UIElements;


namespace Extensions
{
    /// Example
    /// public class ExampleViewList : UIElementsListView<ExampleView, Data> { }
    
    public class UIElementsListView<V, T> : ListView<V, T> where V : UIEView<T>, new()
    {
        public event Action<T> SelectionChanged;

        public UIDocument Document;
        public string ContainerSelector;
        private VisualElement _container;

        protected override void Disable(V view)
        {
            view.style.display = DisplayStyle.None;
            view.parent.Insert(view.parent.childCount-1, view);
        }

        protected override void Enable(V view)
        {
            view.style.display = DisplayStyle.Flex;
        }

        protected override void InitView(V view)
        {
        }

        protected override V InstantiateView()
        {
            var result = new V();
            _container.Add(result);
            result.RegisterCallback<PointerDownEvent>(OnClick);
            return result;
        }

        private void OnEnable()
        {
            var root = Document.rootVisualElement;

            _container = root.Q<VisualElement>(ContainerSelector);
        }

        protected virtual void OnClick(PointerDownEvent evt)
        {
            var v = evt.currentTarget as V;
            if(v != default)
            {
                SelectionChanged?.Invoke(v.Item);
            }
        }
    }
}
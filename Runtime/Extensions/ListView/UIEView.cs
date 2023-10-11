using UnityEngine.UIElements;


namespace Extensions
{
    /// Example
    ///public class ExampleView : UIEView<Data>
    ///{
    ///    public Label Text;
    ///
    ///    public ExampleView()
    ///    {
    ///        Text = new Label();
    ///        Add(Text);
    ///    }
    ///
    ///    protected override void Refresh()
    ///    {
    ///        base.Refresh();
    ///        Text.text = _item.Value.ToString();
    ///    }
    ///}
    public class UIEView<T> : VisualElement, IView<T>
    {
        public new class UxmlFactory : UxmlFactory<UIEView<T>, UxmlTraits> { }

        protected T _item = default;

        protected virtual void Refresh()
        {

        }

        public T Item
        {
            get => _item;
            set
            {
                _item = value;
                Refresh();
            }
        }
    }
}
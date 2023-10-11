using UnityEngine;
using UnityEngine.UI;

namespace Extensions
{
    ///
    ///Example
    ///
    ///public class ExampleView : MonoView<Data>
    ///{
    ///    public Text Text;
    ///
    ///    protected override void Refresh()
    ///    {
    ///        base.Refresh();
    ///        Text.text = _value.Value.ToString();
    ///    }
    ///}
    public class MonoView<T> : MonoBehaviour, IView<T>
    {
        protected T _value;
        public Button Button;

        protected virtual void Refresh()
        {
        }

        public virtual T Item
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
                Refresh();
            }
        }
    }
}
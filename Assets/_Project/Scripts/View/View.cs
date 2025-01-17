using _Project.Scripts.Configs;
using _Project.Scripts.Presenters;

namespace _Project.Scripts.Views
{
    public abstract class View
    {
        private ItemConfig _itemConfig;

        protected Presenter Presenter;

        public View(ItemConfig itemConfig, Presenter presenter)
        {
            _itemConfig = itemConfig;
            Presenter = presenter;
        }
    }
}
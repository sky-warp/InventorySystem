using System.Collections.Generic;
using _Project.Scripts.Configs;
using _Project.Scripts.Views;

namespace _Project.Scripts.Models
{
    public abstract class Model
    {
        private View view;
        private List<ItemConfig> _items;
    }
}
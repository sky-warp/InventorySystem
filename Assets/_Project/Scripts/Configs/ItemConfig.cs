using _Project.Scripts.Character.Model;
using _Project.Scripts.Inventory.Model;
using UnityEngine;

namespace _Project.Scripts.Configs
{
    public abstract class ItemConfig : ScriptableObject
    {
        [field: SerializeField] public string Type { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Weight { get; private set; }
        [field: SerializeField] public int MaxStackValue { get; private set; }
        [field: SerializeField] public bool IsUsable { get; private set; }
        [field: SerializeField] public bool IsUsableOnCharacter { get; private set; }
        [field: SerializeField] public bool IsShouldBeUseOnce { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }

        public virtual void UseItem(Item item)
        {
        }
        
        public virtual void UseItemOnCharacter(CharacterModel characterModel)
        {
        }
    }
}
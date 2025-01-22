using UnityEngine;

namespace _Project.Scripts.Configs
{
    public abstract class ItemConfig : ScriptableObject
    {
        [field: SerializeField] public int Weight { get; private set; }
    }
}
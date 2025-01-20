using System;
using UnityEngine;

namespace _Project.Scripts.Configs
{
    public class ItemConfig : ScriptableObject
    {
        [field: SerializeField] public  int Weight { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}
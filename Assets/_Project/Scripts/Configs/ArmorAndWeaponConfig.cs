using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu (fileName = "ArmorAndWeaponConfig", menuName = "Create new item config/ ArmorAndWeaponConfig")]
    public class ArmorAndWeaponConfig : ItemConfig
    {
        [field: SerializeField] public int Damage { get; private set; }
    }
}
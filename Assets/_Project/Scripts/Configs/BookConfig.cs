using _Project.Scripts.Inventory.Model;
using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "BookData", menuName = "Create New Item/Book")]
    public class BookConfig : ItemConfig
    {
        public override void UseItem(Item item)
        {
            if (!item.IsUsingForOnce)
            {
                item.ItemWasUsedOnce();
                Debug.Log("Book Item was used Once");
            }
            else
            {
                Debug.Log($"{"You already read this book"}");
            }
        }
    }
}
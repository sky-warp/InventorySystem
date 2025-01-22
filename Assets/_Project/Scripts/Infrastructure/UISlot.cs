using System;
using _Project.Scripts.Infrastructure;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour, IDropHandler
{
    private Inventory _mainInventory;
    

    public void OnDrop(PointerEventData eventData)
    {
        var itemTransform = eventData.pointerDrag.transform;
        itemTransform.SetParent(transform);
        itemTransform.localPosition = Vector3.zero;
    }
}
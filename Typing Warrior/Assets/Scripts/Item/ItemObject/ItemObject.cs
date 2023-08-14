using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemObject : MonoBehaviour, IPointerClickHandler
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private ItemObjectDragger itemObjectDragger;

    private ItemDetailsSO itemDetails;

    public event Action<ItemDetailsSO> OnItemDetailsSetted;

    public ItemDetailsSO GetItemDetails()
    {
        return itemDetails;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!itemObjectDragger.IsDragging)
        {
            ItemObjectPopupMenuController.Instance.ShowItemObjectPopupMenu(itemDetails);
        }
    }

    public void SetItemDetails(ItemDetailsSO itemDetails)
    {
        this.itemDetails = itemDetails;
        OnItemDetailsSetted?.Invoke(this.itemDetails);
    }
}
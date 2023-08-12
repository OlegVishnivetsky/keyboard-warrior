using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemObject : MonoBehaviour, IPointerClickHandler
{
    private ItemDetailsSO itemDetails;

    public event Action<ItemDetailsSO> OnItemDetailsSetted;

    public string GetItemDetails()
    {
        return itemDetails.name;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemObjectPopupMenuController.Instance.ShowItemObjectPopupMenu(itemDetails);
    }

    public void SetItemDetails(ItemDetailsSO itemDetails)
    {
        this.itemDetails = itemDetails;
        OnItemDetailsSetted?.Invoke(this.itemDetails);
    }
}
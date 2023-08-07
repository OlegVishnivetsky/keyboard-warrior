using System;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private ItemDetailsSO itemDetails;

    public event Action<ItemDetailsSO> OnItemDetailsSetted;

    public void SetItemDetails(ItemDetailsSO itemDetails)
    {
        this.itemDetails = itemDetails;
        OnItemDetailsSetted?.Invoke(this.itemDetails);
    }
}
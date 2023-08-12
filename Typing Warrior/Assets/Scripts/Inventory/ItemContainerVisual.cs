using System.Collections.Generic;
using UnityEngine;

public class ItemContainerVisual : MonoBehaviour
{
    [SerializeField] private ItemContainer itemContainer;
    [SerializeField] private ItemObject itemObjectPrefab;
    [SerializeField] private Transform itemContainerTransform;

    private void OnEnable()
    {
        itemContainer.OnItemsLoaded += ItemContainer_OnItemsLoaded;
    }

    private void OnDisable()
    {
        itemContainer.OnItemsLoaded -= ItemContainer_OnItemsLoaded;
    }

    private void ItemContainer_OnItemsLoaded()
    {
        List<ItemDetailsSO> loadedItems = itemContainer.GetItems();

        if (loadedItems == null)
        {
            return;
        }

        foreach (ItemDetailsSO itemDetails in loadedItems)
        {
            ItemObject itemObject = Instantiate(itemObjectPrefab, itemContainerTransform);
            itemObject.SetItemDetails(itemDetails);
        }
    }
}
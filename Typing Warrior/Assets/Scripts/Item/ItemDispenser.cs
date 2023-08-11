using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDispenser : MonoBehaviour
{
    [SerializeField] private ItemsCollectionSO allItemsCollection;

    [SerializeField] private List<ItemDetailsSO> inventoryItems;

    public event Action<ItemDetailsSO> OnItemDispensed;

    public void DispenseItem()
    {
        inventoryItems = SaveSystem.Instance.Load<List<ItemDetailsSO>>(Settings.playerInventoryKey);

        int randomItemNumber = UnityEngine.Random.Range(0, allItemsCollection.items.Count);

        ItemDetailsSO itemToDispense = allItemsCollection.items[randomItemNumber];

        OnItemDispensed?.Invoke(itemToDispense);

        inventoryItems.Add(itemToDispense);

        SaveSystem.Instance.Save(inventoryItems, Settings.playerInventoryKey);
    }
}
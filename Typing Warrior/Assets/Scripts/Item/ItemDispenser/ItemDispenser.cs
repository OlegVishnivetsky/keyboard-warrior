using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDispenser : MonoBehaviour
{
    [SerializeField] private ItemsCollectionSO allItemsCollection;

    private List<ItemDetailsSO> inventoryItems;

    public event Action<ItemDetailsSO> OnItemDispensed;
    public event Action<bool> OnItemDispenseSuccessful;

    private void OnEnable()
    {
        StaticEventHandler.OnLevelCompleted += StaticEventHandler_OnLevelCompleted;
    }

    private void OnDisable()
    {
        StaticEventHandler.OnLevelCompleted -= StaticEventHandler_OnLevelCompleted;
    }

    private void StaticEventHandler_OnLevelCompleted()
    {
        if (ProbabilitiesController.CheckProbability(35))
        {
            DispenseItem();
            OnItemDispenseSuccessful?.Invoke(true);
        }
        else
        {
            OnItemDispenseSuccessful?.Invoke(false);
        }
    }

    public void DispenseItem()
    {
        if (SaveSystem.Instance.Load<List<ItemDetailsSO>>(Settings.playerInventoryKey) == null)
        {
            inventoryItems = new List<ItemDetailsSO>();
        }
        else
        {
            inventoryItems = SaveSystem.Instance.Load<List<ItemDetailsSO>>(Settings.playerInventoryKey);
        }

        int randomItemNumber = UnityEngine.Random.Range(0, allItemsCollection.items.Count);

        ItemDetailsSO itemToDispense = allItemsCollection.items[randomItemNumber];

        OnItemDispensed?.Invoke(itemToDispense);

        inventoryItems.Add(itemToDispense);

        SaveSystem.Instance.Save(inventoryItems, Settings.playerInventoryKey);
    }
}
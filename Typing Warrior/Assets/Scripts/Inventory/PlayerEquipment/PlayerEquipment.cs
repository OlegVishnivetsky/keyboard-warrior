using System;
using UnityEngine;

public class PlayerEquipment : ItemContainer
{
    [SerializeField] private int maxNumberOfEquippedItems;

    private int currentNumberOfEquippedItems;

    public event Action<int> OnCurrentNumberOfItemsChanged;

    private void Start()
    {
        LoadPlayerItems(Settings.playerEquipmentKey);

        currentNumberOfEquippedItems = items.Count;
        OnCurrentNumberOfItemsChanged?.Invoke(currentNumberOfEquippedItems);
    }

    public int GetMaxNumberOfEquippedItems()
    {
        return maxNumberOfEquippedItems;
    }

    public override bool AddItem(ItemDetailsSO itemToAdd)
    {
        if (items.Count < maxNumberOfEquippedItems)
        {
            base.AddItem(itemToAdd);

            currentNumberOfEquippedItems++;
            OnCurrentNumberOfItemsChanged?.Invoke(currentNumberOfEquippedItems);
        }
        else
        {
            return false;
        }

        return true;
    }

    public override bool RemoveItem(ItemDetailsSO itemToRemove)
    {
        currentNumberOfEquippedItems--;
        OnCurrentNumberOfItemsChanged?.Invoke(currentNumberOfEquippedItems);

        return base.RemoveItem(itemToRemove);
    }

    private void OnApplicationQuit()
    {
        SavePlayerItems(Settings.playerEquipmentKey);
    }
}
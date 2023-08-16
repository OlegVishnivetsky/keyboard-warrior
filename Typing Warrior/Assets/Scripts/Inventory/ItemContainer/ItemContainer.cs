using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemContainer : MonoBehaviour
{
    protected List<ItemDetailsSO> items = new List<ItemDetailsSO>();

    public event Action OnItemsLoaded;

    public virtual List<ItemDetailsSO> GetItems()
    {
        return items;
    }

    public virtual bool AddItem(ItemDetailsSO itemToAdd)
    {
        items.Add(itemToAdd);
        return true;
    }

    public virtual bool RemoveItem(ItemDetailsSO itemToRemove)
    {
        items.Remove(itemToRemove);
        return true;
    }

    public virtual void LoadPlayerItems(string key)
    {
        if (SaveSystem.Instance.Load<List<ItemDetailsSO>>(key) == null)
        {
            items = new List<ItemDetailsSO>();
        }
        else
        {
            items = SaveSystem.Instance.Load<List<ItemDetailsSO>>(key);
        }

        OnItemsLoaded?.Invoke();
    }

    public virtual void SavePlayerItems(string key)
    {
        SaveSystem.Instance.Save<List<ItemDetailsSO>>(items, key);
    }
}
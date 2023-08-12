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

    public virtual void AddItem(ItemDetailsSO itemToAdd)
    {
        items.Add(itemToAdd);
    }

    public virtual void RemoveItem(ItemDetailsSO itemToRemove)
    {
        items.Remove(itemToRemove);
    }

    public virtual void LoadPlayerItems(string key)
    {
        items = SaveSystem.Instance.Load<List<ItemDetailsSO>>(key);
        OnItemsLoaded?.Invoke();
    }
}
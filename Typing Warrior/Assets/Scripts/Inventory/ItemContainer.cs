using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    [SerializeField] protected List<ItemDetailsSO> items = new List<ItemDetailsSO>();
    [SerializeField] protected SaveSystem saveSystem;

    public event Action OnItemContainerLoaded;

    private void Start()
    {
        items = saveSystem.LoadItemContainer("items");
        OnItemContainerLoaded?.Invoke();
    }

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
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private List<Item> items = new List<Item>();

    private IEnumerator Start()
    {
        UpdateItemsStatModification();

        yield return new WaitForSeconds(4);

        RemoveItem(items[0]);
    }

    public void AddItem(Item itemToAdd)
    {
        items.Add(itemToAdd);
        UpdateItemsStatModification();
    }

    public void RemoveItem(Item itemToRemove)
    {
        items.Remove(itemToRemove);
        UpdateItemsStatModification();
    }

    public void UpdateItemsStatModification()
    {
        player.ResetPlayerStats();

        foreach (Item item in items)
        {
            foreach (ItemStatModification itemStatModification in item.GetItemDetails().itemStatModifications)
            {
                switch (itemStatModification.statToModify)
                {
                    case StatToModify.Health:
                        player.Health.ModifyValue(itemStatModification.value,
                            itemStatModification.modificationType);
                        break;
                    case StatToModify.Damage:
                        player.Damage.ModifyValue(itemStatModification.value,
                            itemStatModification.modificationType);
                        break;
                    case StatToModify.Armor:
                        player.Armor.ModifyValue(itemStatModification.value,
                            itemStatModification.modificationType);
                        break;
                }
            }
        }
    }
}
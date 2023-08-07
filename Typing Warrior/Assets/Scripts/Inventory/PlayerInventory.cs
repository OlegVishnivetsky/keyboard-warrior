using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInventory : ItemContainer
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        UpdateItemsStatModifications();
    }

    public override void AddItem(ItemDetailsSO itemToAdd)
    {
        base.AddItem(itemToAdd);
        UpdateItemsStatModifications();
    }

    public override void RemoveItem(ItemDetailsSO itemToRemove)
    {
        base.RemoveItem(itemToRemove);
        UpdateItemsStatModifications();
    }

    public void UpdateItemsStatModifications()
    {
        player.ResetPlayerStats();

        foreach (ItemDetailsSO item in items)
        {
            foreach (ItemStatModification itemStatModification in item.itemStatModifications)
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
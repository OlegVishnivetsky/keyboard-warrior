using UnityEngine;

public class PlayerEquipment : ItemContainer
{
    [SerializeField] private int max�umberOfEquippedItems;

    private void Start()
    {
        LoadPlayerInventoryItems(Settings.playerEquipmentKey);
    }

    public override void AddItem(ItemDetailsSO itemToAdd)
    {
        if (items.Count < max�umberOfEquippedItems)
        {
            base.AddItem(itemToAdd);
        }
    }
}
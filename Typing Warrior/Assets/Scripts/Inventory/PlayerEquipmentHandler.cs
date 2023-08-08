using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentHandler : MonoBehaviour
{
    [SerializeField] private Player player;

    private List<ItemDetailsSO> items = new List<ItemDetailsSO>();

    private void Start()
    {
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
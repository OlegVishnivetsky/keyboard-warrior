using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentHandler : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private Player player;

    private List<ItemDetailsSO> items = new List<ItemDetailsSO>();

    public event Action OnItemsStatModificationsUpdated;

    private void OnEnable()
    {
        player.OnBeforePlayerInitialised += Player_OnBeforePlayerInitialised;
    }

    private void OnDisable()
    {
        player.OnBeforePlayerInitialised -= Player_OnBeforePlayerInitialised;
    }

    private void Player_OnBeforePlayerInitialised()
    {
        UpdateItemsStatModifications();
    }

    public void UpdateItemsStatModifications()
    {
        items = SaveSystem.Instance.Load<List<ItemDetailsSO>>(Settings.playerEquipmentKey);

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

                    default:
                        break;
                }
            }
        }

        OnItemsStatModificationsUpdated?.Invoke();
    }
}
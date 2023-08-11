using UnityEngine;

public class ItemDispenserUI : MonoBehaviour
{
    [SerializeField] private ItemObject itemObject;
    [SerializeField] private ItemDispenser itemDispenser;

    private void OnEnable()
    {
        itemDispenser.OnItemDispensed += ItemDispenser_OnItemDispensed;
    }

    private void OnDisable()
    {
        itemDispenser.OnItemDispensed -= ItemDispenser_OnItemDispensed;
    }

    private void ItemDispenser_OnItemDispensed(ItemDetailsSO item)
    {
        itemObject.SetItemDetails(item);
    }
}
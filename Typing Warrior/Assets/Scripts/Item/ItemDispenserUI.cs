using UnityEngine;

public class ItemDispenserUI : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private ItemObjectUI itemObjectUI;
    [SerializeField] private ItemDispenser itemDispenser;
    [SerializeField] private ScaleUITween scaleTween;

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
        itemObjectUI.UpdateItemObjectUI(item);
        scaleTween.ScaleIn();
    }
}
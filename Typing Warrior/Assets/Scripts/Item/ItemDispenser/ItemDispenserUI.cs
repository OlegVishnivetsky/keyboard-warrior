using UnityEngine;

public class ItemDispenserUI : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private ItemObjectUI itemObjectUI;
    [SerializeField] private ItemDispenser itemDispenser;
    [SerializeField] private ScaleUITween scaleTween;
    [SerializeField] private ScaleUITween levelCompletePanelScaleTween;

    private void OnEnable()
    {
        itemDispenser.OnItemDispensed += ItemDispenser_OnItemDispensed;
        itemDispenser.OnItemDispenseSuccessful += ItemDispenser_OnItemDispenseSuccessful;
    }

    private void OnDisable()
    {
        itemDispenser.OnItemDispensed -= ItemDispenser_OnItemDispensed;
        itemDispenser.OnItemDispenseSuccessful -= ItemDispenser_OnItemDispenseSuccessful;
    }

    private void ItemDispenser_OnItemDispenseSuccessful(bool isSuccessful)
    {
        if (!isSuccessful)
        {
            levelCompletePanelScaleTween.ScaleIn();
        }
    }

    private void ItemDispenser_OnItemDispensed(ItemDetailsSO item)
    {
        itemObjectUI.UpdateItemObjectUI(item);
        scaleTween.ScaleIn();
    }

    public void ScaleOutAndScaleInLevelCompletePanel()
    {
        scaleTween.ScaleOut(() =>
        {
            levelCompletePanelScaleTween.ScaleIn();
        });
    }
}
using UnityEngine;

public class ItemContainerUI : MonoBehaviour
{
    [SerializeField] private ItemContainer itemContainer;
    [SerializeField] private RectTransform parentTransform;
    [SerializeField] private ItemObject itemPrefab;

    private void OnEnable()
    {
        itemContainer.OnItemContainerLoaded += ItemContainer_OnItemContainerLoaded;
    }

    private void OnDisable()
    {
        itemContainer.OnItemContainerLoaded -= ItemContainer_OnItemContainerLoaded;
    }

    private void ItemContainer_OnItemContainerLoaded()
    {
        UpdateItems();
    }

    public void UpdateItems()
    {
        foreach (ItemDetailsSO itemDetails in itemContainer.GetItems())
        {
            ItemObject itemObject = Instantiate(itemPrefab, parentTransform);
            itemObject.SetItemDetails(itemDetails);
        }
    }
}
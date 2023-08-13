using UnityEngine;
using UnityEngine.EventSystems;

public class ItemContainerZone : MonoBehaviour, IDropHandler
{
    [Header("ITEM CONTAINER COMPONENTS")]
    [SerializeField] private ItemContainer itemContainerToAddItem;
    [SerializeField] private ItemContainer itemContainerToRemoveItem;

    [Header("TRANSFORM COMPONENT")]
    [SerializeField] private Transform contentTransform;

    public void OnDrop(PointerEventData eventData)
    {
        ItemObject dropedItem = eventData.pointerDrag.GetComponent<ItemObject>();

        if (dropedItem != null)
        {
            dropedItem.gameObject.transform.SetParent(contentTransform);

            if (itemContainerToAddItem.GetItems().Contains(dropedItem.GetItemDetails()))
            {
                return;
            }

            itemContainerToAddItem.AddItem(dropedItem.GetItemDetails());
            itemContainerToRemoveItem.RemoveItem(dropedItem.GetItemDetails());
        }
    }
}
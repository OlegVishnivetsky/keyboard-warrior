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
            if (itemContainerToAddItem.GetItems().Contains(dropedItem.GetItemDetails()))
            {
                return;
            }

            if (!itemContainerToAddItem.AddItem(dropedItem.GetItemDetails()))
            {
                return;
            }

            dropedItem.gameObject.transform.SetParent(contentTransform);

            itemContainerToRemoveItem.RemoveItem(dropedItem.GetItemDetails());
        }
    }
}
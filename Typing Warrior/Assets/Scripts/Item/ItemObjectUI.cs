using UnityEngine;
using UnityEngine.UI;

public class ItemObjectUI : MonoBehaviour
{
    [SerializeField] private ItemObject itemObject;
    [SerializeField] private Image itemImage;

    private void OnEnable()
    {
        itemObject.OnItemDetailsSetted += ItemObject_OnItemDetailsSetted;
    }

    private void OnDisable()
    {
        itemObject.OnItemDetailsSetted -= ItemObject_OnItemDetailsSetted;
    }

    private void ItemObject_OnItemDetailsSetted(ItemDetailsSO itemDetails)
    {
        UpdateItemObjectUI(itemDetails);
    }

    public void UpdateItemObjectUI(ItemDetailsSO itemDetails)
    {
        itemImage.sprite = Resources.Load<Sprite>(itemDetails.iconPath);
    }
}
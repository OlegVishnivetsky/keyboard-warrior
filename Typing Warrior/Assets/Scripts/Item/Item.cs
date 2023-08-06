using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemDetailsSO itemDetails;

    public ItemDetailsSO GetItemDetails()
    {
        return itemDetails;
    }
}
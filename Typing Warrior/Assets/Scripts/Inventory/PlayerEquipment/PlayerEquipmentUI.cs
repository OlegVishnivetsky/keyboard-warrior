using TMPro;
using UnityEngine;

public class PlayerEquipmentUI : MonoBehaviour
{
    [Header("TEXT COMPONENTS")]
    [SerializeField] private TextMeshProUGUI playerEquipmentText;

    [Header("OTHER COMPONENTS")]
    [SerializeField] private PlayerEquipment playerEquipment;

    private void OnEnable()
    {
        playerEquipment.OnCurrentNumberOfItemsChanged += PlayerEquipment_OnItemAdded;
    }

    private void OnDisable()
    {
        playerEquipment.OnCurrentNumberOfItemsChanged -= PlayerEquipment_OnItemAdded;
    }

    private void PlayerEquipment_OnItemAdded(int currentNumberOfItems)
    {
        UpdatePlayerEquipmentText(currentNumberOfItems);
    }

    private void UpdatePlayerEquipmentText(int currentNumberOfItems)
    {
        playerEquipmentText.text = $"Player Equipment " +
                    $"{currentNumberOfItems}/{playerEquipment.GetMaxNumberOfEquippedItems()}";
    }
}
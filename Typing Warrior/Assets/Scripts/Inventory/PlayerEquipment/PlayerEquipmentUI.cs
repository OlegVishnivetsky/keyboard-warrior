using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipmentUI : MonoBehaviour
{
    [Header("UI COMPONENTS")]
    [SerializeField] private TextMeshProUGUI playerEquipmentText;
    [SerializeField] private Button backToMenuButton;

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

    private void Start()
    {
        backToMenuButton.onClick.AddListener(() =>
        {
            playerEquipment.SavePlayerItems(Settings.playerEquipmentKey);
        });
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
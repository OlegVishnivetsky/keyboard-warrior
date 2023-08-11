using TMPro;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    [Header("UI COMPONENTS")]
    [SerializeField] private TextMeshProUGUI damageText;

    [Header("MAIN COMPONENTS")]
    [SerializeField] private Player player;
    [SerializeField] private PlayerEquipmentHandler playerEquipmentHandler;

    private void OnEnable()
    {
        playerEquipmentHandler.OnItemsStatModificationsUpdated += PlayerEquipmentHandler_OnItemsStatModificationsUpdated;
    }

    private void OnDisable()
    {
        playerEquipmentHandler.OnItemsStatModificationsUpdated -= PlayerEquipmentHandler_OnItemsStatModificationsUpdated;
    }

    private void PlayerEquipmentHandler_OnItemsStatModificationsUpdated()
    {
        UpdateDamageText();
    }

    private void UpdateDamageText()
    {
        damageText.text = player.Damage.GetValue().ToString();
    }
}
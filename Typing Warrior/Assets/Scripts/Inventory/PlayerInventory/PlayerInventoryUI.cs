using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryUI : MonoBehaviour
{
    [Header("UI COMPONENTS")]
    [SerializeField] private Button backToMenuButton;

    [Header("OTHER COMPONENTS")]
    [SerializeField] private PlayerInventory playerInventory;

    private void Start()
    {
        backToMenuButton.onClick.AddListener(() =>
        {
            playerInventory.SavePlayerItems(Settings.playerInventoryKey);
        });
    }
}
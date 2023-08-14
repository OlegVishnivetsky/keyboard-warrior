using UnityEngine;

public class ItemObjectPopupMenuController : SingletonMonobehaviour<ItemObjectPopupMenuController>
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private ItemObjectPopupMenuUI popupMenuUI;

    public void ShowItemObjectPopupMenu(ItemDetailsSO itemDetails)
    {
        popupMenuUI.SetUpItemPopupMenu(itemDetails);
        popupMenuUI.Show();
    }
}
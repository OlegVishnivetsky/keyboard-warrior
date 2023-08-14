using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemObjectPopupMenuUI : MonoBehaviour
{
    [Header("UI COMPONENTS")]
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private Image itemIconImage;

    [Header("OTHER COMPONENTS")]
    [SerializeField] private ScaleUITween scaleTween;

    public void Show()
    {
        scaleTween.ScaleIn();
    }

    public void Hide()
    {
        scaleTween.ScaleOut();
    }

    public void SetUpItemPopupMenu(ItemDetailsSO itemDetails)
    {
        itemNameText.text = itemDetails.name;
        itemDescriptionText.text = itemDetails.description;
        itemIconImage.sprite = Resources.Load<Sprite>(itemDetails.iconPath);
    }
}
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Items/ItemDetails", fileName = "_ItemDetails")]
public class ItemDetailsSO : ScriptableObject
{
    [Header("MAIN PARAMETERS")]
    public string itemName;
    [TextArea] public string description;
    public string iconPath;

    [Header("STAT MODIFICATIONS")]
    public List<ItemStatModification> itemStatModifications = new List<ItemStatModification>();
}
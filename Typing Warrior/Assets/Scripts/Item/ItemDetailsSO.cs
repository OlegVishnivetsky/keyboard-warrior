using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/ItemDetails", fileName = "_ItemDetails")]
public class ItemDetailsSO : ScriptableObject
{
    [Header("MAIN PARAMETERS")]
    public string itemName;
    [TextArea(1, 3)] public string description;
    public Sprite icon;

    [Header("STAT MODIFICATIONS")]
    public List<ItemStatModification> itemStatModifications = new List<ItemStatModification>();
}
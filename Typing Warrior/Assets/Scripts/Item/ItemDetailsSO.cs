using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/ItemDetails")]
public class ItemDetailsSO : ScriptableObject
{
    public List<ItemStatModification> itemStatModifications = new List<ItemStatModification>();
}
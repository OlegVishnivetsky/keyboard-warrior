using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Items/ItemsCollection", fileName = "_ItemsCollection")]
public class ItemsCollectionSO : ScriptableObject
{
    public List<ItemDetailsSO> items;
}
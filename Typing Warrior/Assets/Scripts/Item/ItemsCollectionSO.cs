using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/ItemsCollection", fileName = "_ItemsCollection")]
public class ItemsCollectionSO : ScriptableObject
{
    public List<ItemDetailsSO> items = new List<ItemDetailsSO>();
}
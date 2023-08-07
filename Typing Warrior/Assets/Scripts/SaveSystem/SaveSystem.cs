using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private ItemsCollectionSO allItemsCollection;

    [SerializeField] private List<string> savedItemsNames = new List<string>();

    public void SaveItemContainer(ItemContainer itemContainer, string key)
    {
        savedItemsNames.Clear();

        foreach (ItemDetailsSO item in itemContainer.GetItems())
        {
            savedItemsNames.Add(item.itemName);
        }

        string path = Application.persistentDataPath + "/" + key;
        string json = JsonConvert.SerializeObject(savedItemsNames, Formatting.Indented);

        File.WriteAllText(path, json);
    }

    public List<ItemDetailsSO> LoadItemContainer(string key)
    {
        List<ItemDetailsSO> loadedItemDetailsList = new List<ItemDetailsSO>();

        string path = Application.persistentDataPath + "/" + key;

        if (!File.Exists(path))
        {
            return null;
        }

        string json = File.ReadAllText(path);

        savedItemsNames = JsonConvert.DeserializeObject<List<string>>(json);

        foreach (string itemName in savedItemsNames)
        {
            foreach (ItemDetailsSO itemDetails in allItemsCollection.items)
            {
                if (itemName == itemDetails.itemName)
                {
                    loadedItemDetailsList.Add(itemDetails);
                }
            }
        }

        Debug.Log(loadedItemDetailsList.Count);

        return loadedItemDetailsList;
    }
}
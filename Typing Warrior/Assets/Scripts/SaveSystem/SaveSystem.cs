using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class SaveSystem : SingletonMonobehaviour<SaveSystem>
{
    public void Save<T>(T objectToSave, string key)
    {
        string path = Application.persistentDataPath + "/" + key;
        string json = JsonConvert.SerializeObject(objectToSave, Formatting.Indented);

        File.WriteAllText(path, json);
    }

    public T Load<T>(string key)
    {
        T objectToLoad;

        string path = Application.persistentDataPath + "/" + key;

        if (!File.Exists(path))
        {
            return default;
        }

        string json = File.ReadAllText(path);

        objectToLoad = JsonConvert.DeserializeObject<T>(json);

        return objectToLoad;
    }
}
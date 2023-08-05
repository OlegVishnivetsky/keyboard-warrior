using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class WordCollection : SingletonMonobehaviour<WordCollection>
{
    private List<string> words = new List<string>();

    private void Start()
    {
        words = File.ReadAllLines(Application.streamingAssetsPath + "/Words.txt").ToList<string>();
    }

    public string GetRandomWordFromCollection()
    {
        string randomWord = words[Random.Range(0, words.Count)];

        return randomWord;
    }
}
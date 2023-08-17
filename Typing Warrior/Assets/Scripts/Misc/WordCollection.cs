using System.Collections.Generic;
using UnityEngine;

public class WordCollection : SingletonMonobehaviour<WordCollection>
{
    [SerializeField] private List<string> words = new List<string>();

    public string GetRandomWordFromCollection()
    {
        string randomWord = words[Random.Range(0, words.Count)];

        return randomWord;
    }
}
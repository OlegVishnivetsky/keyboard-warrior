using System;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Keyboard : MonoBehaviour
{
    [SerializeField] private List<Key> keys = new List<Key>();

    private string input;

    public event Action<string> OnKeyboardInputChanged;

    private void Start()
    {
        SetUpKeysCharacter();
    }

    public void AddKeyCharacterToInput(char character)
    {
        input += character;
        OnKeyboardInputChanged?.Invoke(input);
    }

    private void SetUpKeysCharacter()
    {
        for (int i = 0; i < keys.Count; i++)
        {
            keys[i].SetKeyCharacter(KeyboardLayout.qwertyLayoutDictionary[i]);
        }
    }
}
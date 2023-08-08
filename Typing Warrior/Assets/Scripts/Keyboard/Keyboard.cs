using System;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Keyboard : SingletonMonobehaviour<Keyboard>
{
    [Header("LIST OF LETTER KEYS")]
    [SerializeField] private List<Key> keys = new List<Key>();

    public bool IsActive { get; set; } 

    private string input;

    public event Action<string, char> OnKeyboardInputChanged;

    private void Start()
    {
        IsActive = true;
        SetUpKeysCharacter();
    }

    public void AddKeyCharacterToInput(char character)
    {
        if (!IsActive)
        {
            return;
        }

        input += character;
        OnKeyboardInputChanged?.Invoke(input, input[input.Length - 1]);
    }

    public void ResetKeyboardInput()
    {
        input = string.Empty;
    }

    public void RemoveLastLetterFromInput()
    {
        input = input.Remove(input.Length - 1);
    }

    private void SetUpKeysCharacter()
    {
        for (int i = 0; i < keys.Count; i++)
        {
            keys[i].SetKeyCharacter(KeyboardLayout.qwertyLayoutDictionary[i]);
        }
    }
}
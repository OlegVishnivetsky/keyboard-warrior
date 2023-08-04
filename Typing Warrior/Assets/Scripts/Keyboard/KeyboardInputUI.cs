using TMPro;
using UnityEngine;

public class KeyboardInputUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputText;
    [SerializeField] private Keyboard keyboard;

    private void OnEnable()
    {
        keyboard.OnKeyboardInputChanged += Keyboard_OnKeyboardInputChanged;
    }

    private void OnDisable()
    {
        keyboard.OnKeyboardInputChanged -= Keyboard_OnKeyboardInputChanged;
    }

    private void Keyboard_OnKeyboardInputChanged(string input)
    {
        inputText.text = input;
    }
}
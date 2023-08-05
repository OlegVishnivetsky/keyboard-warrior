using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private Keyboard keyboard;
    [SerializeField] private QueueOfEnemies queueOfEnemies;

    private Enemy currentEnemy;

    private string playerWord;

    private int currentCorrectCharIndex = 0;

    public event Action<string, int> OnPlayerTypedCorrectChar;

    private void OnEnable()
    {
        keyboard.OnKeyboardInputChanged += Keyboard_OnKeyboardInputChanged;

        queueOfEnemies.OnNextEnemyChanged += QueueOfEnemies_OnNextEnemyChanged;
    }

    private void OnDisable()
    {
        keyboard.OnKeyboardInputChanged -= Keyboard_OnKeyboardInputChanged;

        queueOfEnemies.OnNextEnemyChanged -= QueueOfEnemies_OnNextEnemyChanged;
    }

    private void QueueOfEnemies_OnNextEnemyChanged(Enemy nextEnemy)
    {
        currentEnemy = nextEnemy;
    }

    private void Keyboard_OnKeyboardInputChanged(string keyboardInput, char lastInputChar)
    {
        if (IsLastInputCharCorrect(lastInputChar))
        {
            playerWord += lastInputChar;
            currentCorrectCharIndex++;

            OnPlayerTypedCorrectChar?.Invoke(playerWord, currentCorrectCharIndex);
        }

        if (IsPlayerWordCorrect())
        {
            currentCorrectCharIndex = 0;
            playerWord = string.Empty;

            return;
        }
    }

    private bool IsLastInputCharCorrect(char lastInputChar)
    {
        return lastInputChar == currentEnemy.GetEnemyWord()[currentCorrectCharIndex];
    }

    public bool IsPlayerWordCorrect()
    {
        return playerWord == currentEnemy.GetEnemyWord();
    }
}
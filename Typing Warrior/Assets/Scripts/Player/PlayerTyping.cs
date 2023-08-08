using System;
using UnityEngine;

public class PlayerTyping : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private Player player;
    [SerializeField] private QueueOfEnemies queueOfEnemies;

    private Enemy currentEnemy;

    private string playerWord;

    private int currentCorrectCharIndex = 0;

    public event Action<string, int> OnPlayerTypedCorrectChar;

    private void OnEnable()
    {
        Keyboard.Instance.OnKeyboardInputChanged += Keyboard_OnKeyboardInputChanged;

        queueOfEnemies.OnNextEnemyActivated += QueueOfEnemies_OnNextEnemyActivated;
    }

    private void OnDisable()
    {
        Keyboard.Instance.OnKeyboardInputChanged -= Keyboard_OnKeyboardInputChanged;

        queueOfEnemies.OnNextEnemyActivated -= QueueOfEnemies_OnNextEnemyActivated;
    }

    private void QueueOfEnemies_OnNextEnemyActivated()
    {
        currentEnemy = queueOfEnemies.GetCurrentEnemy();
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

            currentEnemy.GetComponent<Health>().TakeDamage(player.Damage.GetValue());
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
using System;
using System.Transactions;
using UnityEngine;

public class PlayerTyping : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private Player player;
    [SerializeField] private PlayerAttackEffect attackEffect;
    [SerializeField] private QueueOfEnemies queueOfEnemies;

    private Enemy currentEnemy;

    private string playerWord;

    private int currentCorrectCharIndex = 0;

    public event Action<string, int> OnPlayerTypedCorrectChar;

    private void OnEnable()
    {
        Keyboard.Instance.OnKeyboardInputChanged += Keyboard_OnKeyboardInputChanged;

        queueOfEnemies.OnNextEnemyActivated += QueueOfEnemies_OnNextEnemyActivated;

        attackEffect.OnAttackEffectAnimationEnded += AttackEffect_OnAttackEffectAnimationEnded;
    }

    private void OnDisable()
    {
        Keyboard.Instance.OnKeyboardInputChanged -= Keyboard_OnKeyboardInputChanged;

        queueOfEnemies.OnNextEnemyActivated -= QueueOfEnemies_OnNextEnemyActivated;

        attackEffect.OnAttackEffectAnimationEnded -= AttackEffect_OnAttackEffectAnimationEnded;
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
        else
        {
            player.GetPlayerHealth().TakeDamage(currentEnemy.GetEnemyDetails().damage);
        }

        if (IsPlayerWordCorrect())
        {
            currentCorrectCharIndex = 0;
            playerWord = string.Empty;

            attackEffect.TriggerAttackEffectAnimation();
            currentEnemy.GetEnemyAttack().ResetDelayBeforeAttack();
        }
    }

    private void AttackEffect_OnAttackEffectAnimationEnded()
    {
        currentEnemy.GetComponent<Health>().TakeDamage(player.Damage.GetValue());
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
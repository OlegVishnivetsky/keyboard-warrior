using TMPro;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private PlayerTyping player;
    [SerializeField] private QueueOfEnemies queueOfEnemies;

    [Header("TEXT COMPONENTS")]
    [SerializeField] private TextMeshProUGUI currentWordText;

    [Space(10)]
    [SerializeField] private Color correctCharColor;

    private string currentEnemyWord;

    private void OnEnable()
    {
        player.OnPlayerTypedCorrectChar += Player_OnPlayerTypedCorrectChar;

        queueOfEnemies.OnNextEnemyChanged += QueueOfEnemies_OnNextEnemyChanged;
    }

    private void OnDisable()
    {
        player.OnPlayerTypedCorrectChar -= Player_OnPlayerTypedCorrectChar;

        queueOfEnemies.OnNextEnemyChanged -= QueueOfEnemies_OnNextEnemyChanged;
    }

    private void QueueOfEnemies_OnNextEnemyChanged(Enemy nextEnemy)
    {
        currentEnemyWord = nextEnemy.GetEnemyWord();
        currentWordText.text = currentEnemyWord;
    }

    private void Player_OnPlayerTypedCorrectChar(string currentPlayerWord, int charIndex)
    {
        currentWordText.text = $"<color=#{ColorUtility.ToHtmlStringRGBA(correctCharColor)}>{currentPlayerWord}</color>";
        currentWordText.text += currentEnemyWord.Substring(charIndex);
    }
}
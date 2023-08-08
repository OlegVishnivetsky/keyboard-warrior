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

        queueOfEnemies.OnNextEnemyActivated += QueueOfEnemies_OnNextEnemyActivated;
        queueOfEnemies.GetCurrentEnemy().OnEnemyWordGenerated += GameplayUI_OnEnemyWordGenerated;
    }

    private void OnDisable()
    {
        player.OnPlayerTypedCorrectChar -= Player_OnPlayerTypedCorrectChar;

        queueOfEnemies.OnNextEnemyActivated -= QueueOfEnemies_OnNextEnemyActivated;
        queueOfEnemies.GetCurrentEnemy().OnEnemyWordGenerated -= GameplayUI_OnEnemyWordGenerated;
    }

    private void QueueOfEnemies_OnNextEnemyActivated()
    {
        UpdateCurrentEnemyWordText();
    }

    private void GameplayUI_OnEnemyWordGenerated()
    {
        UpdateCurrentEnemyWordText();
    }

    private void Player_OnPlayerTypedCorrectChar(string currentPlayerWord, int charIndex)
    {
        currentWordText.text = $"<color=#{ColorUtility.ToHtmlStringRGBA(correctCharColor)}>{currentPlayerWord}</color>";
        currentWordText.text += currentEnemyWord.Substring(charIndex);
    }

    private void UpdateCurrentEnemyWordText()
    {
        currentEnemyWord = queueOfEnemies.GetCurrentEnemy().GetEnemyWord();
        currentWordText.text = currentEnemyWord;
    }
}
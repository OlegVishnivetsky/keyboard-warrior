using TMPro;
using UnityEngine;

public class EnemyNameUI : MonoBehaviour
{
    [Header("UI COMPONENTS")]
    [SerializeField] private TextMeshProUGUI enemyNameText;

    [Header("OTHER COMPONENTS")]
    [SerializeField] private QueueOfEnemies queueOfEnemies;

    private void OnEnable()
    {
        queueOfEnemies.OnNextEnemyActivated += QueueOfEnemies_OnNextEnemyActivated;
    }

    private void OnDisable()
    {
        queueOfEnemies.OnNextEnemyActivated -= QueueOfEnemies_OnNextEnemyActivated;
    }

    private void QueueOfEnemies_OnNextEnemyActivated()
    {
        UpdateEnemyNameText();
    }

    private void UpdateEnemyNameText()
    {
        enemyNameText.text = queueOfEnemies.GetCurrentEnemy().GetEnemyDetails().enemyName;
    }
}
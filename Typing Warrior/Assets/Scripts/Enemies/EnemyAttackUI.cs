using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttackUI : MonoBehaviour
{
    [Header("UI COMPONENTS")]
    [SerializeField] private Slider attackSlider;
    [SerializeField] private TextMeshProUGUI attackText;

    [Header("OTHER COMPONENTS")]
    [SerializeField] private EnemyAttack enemyAttack;
    [SerializeField] private QueueOfEnemies queueOfEnemies;

    private void OnEnable()
    {
        queueOfEnemies.OnNextEnemyActivated += QueueOfEnemies_OnNextEnemyActivated;

        enemyAttack.OnDelayBeforeAttackChanged += EnemyAttack_OnDelayBeforeAttackChanged;
        enemyAttack.OnDelayBeforeAttackAssigned += EnemyAttack_OnDelayBeforeAttackAssigned;
    }

    private void OnDisable()
    {
        queueOfEnemies.OnNextEnemyActivated -= QueueOfEnemies_OnNextEnemyActivated;

        enemyAttack.OnDelayBeforeAttackChanged -= EnemyAttack_OnDelayBeforeAttackChanged;
        enemyAttack.OnDelayBeforeAttackAssigned -= EnemyAttack_OnDelayBeforeAttackAssigned;
    }

    private void QueueOfEnemies_OnNextEnemyActivated()
    {
        attackText.text = queueOfEnemies.GetCurrentEnemy().GetEnemyDetails().damage.ToString();
    }

    private void EnemyAttack_OnDelayBeforeAttackAssigned(float value)
    {
        attackSlider.maxValue = value;
        attackSlider.value = value;
    }

    private void EnemyAttack_OnDelayBeforeAttackChanged(float value)
    {
        attackSlider.value = value;
    }
}
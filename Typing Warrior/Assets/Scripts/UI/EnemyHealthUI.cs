using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Health enemyHealth;
    [SerializeField] private QueueOfEnemies queueOfEnemies;

    private void OnEnable()
    {
        enemyHealth.OnHealthChanged += EnemyHealth_OnHealthChanged;
        enemyHealth.OnHealthWasOver += EnemyHealth_OnHealthWasOver;
    }

    private void OnDisable()
    {
        enemyHealth.OnHealthChanged -= EnemyHealth_OnHealthChanged;
        enemyHealth.OnHealthWasOver -= EnemyHealth_OnHealthWasOver;
    }

    private void EnemyHealth_OnHealthWasOver()
    {
        healthSlider.value = 0;
    }

    private void EnemyHealth_OnHealthChanged(int currentHealth)
    {
        healthSlider.maxValue = enemyHealth.GetMaxHealth();
        healthSlider.value = currentHealth;
    }
}
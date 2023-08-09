using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [Header("UI COMPONENTS")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI enemyHealthText;
    
    [Header("OTHER COMPONENTS")]
    [SerializeField] private Health enemyHealth;

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
        UpdateHealthSliderValues(currentHealth);
        UpdateCurrentAndMaxHealthTexts(currentHealth);
    }

    private void UpdateHealthSliderValues(int currentHealth)
    {
        healthSlider.maxValue = enemyHealth.GetMaxHealth();
        healthSlider.value = currentHealth;
    }

    private void UpdateCurrentAndMaxHealthTexts(int currentHealth)
    {
        enemyHealthText.text = $"{currentHealth}/{enemyHealth.GetMaxHealth()}";
    }
}
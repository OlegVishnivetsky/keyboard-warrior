using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderUI : MonoBehaviour
{
    [Header("UI COMPONENTS")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;
    
    [Header("OTHER COMPONENTS")]
    [SerializeField] private Health healthComponent;

    private void OnEnable()
    {
        healthComponent.OnHealthChanged += EnemyHealth_OnHealthChanged;
        healthComponent.OnHealthWasOver += EnemyHealth_OnHealthWasOver;
    }

    private void OnDisable()
    {
        healthComponent.OnHealthChanged -= EnemyHealth_OnHealthChanged;
        healthComponent.OnHealthWasOver -= EnemyHealth_OnHealthWasOver;
    }

    private void EnemyHealth_OnHealthWasOver()
    {
        healthSlider.value = 0;
        UpdateCurrentAndMaxHealthTexts(0);
    }

    private void EnemyHealth_OnHealthChanged(int currentHealth)
    {
        UpdateHealthSliderValues(currentHealth);

        if (healthText != null)
        {
            UpdateCurrentAndMaxHealthTexts(currentHealth);
        }
    }

    private void UpdateHealthSliderValues(int currentHealth)
    {
        healthSlider.maxValue = healthComponent.GetMaxHealth();
        healthSlider.value = currentHealth;
    }

    private void UpdateCurrentAndMaxHealthTexts(int currentHealth)
    {
        healthText.text = $"{currentHealth}/{healthComponent.GetMaxHealth()}";
    }
}
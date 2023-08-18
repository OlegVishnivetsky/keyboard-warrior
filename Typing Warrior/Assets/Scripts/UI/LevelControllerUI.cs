using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelControllerUI : MonoBehaviour
{
    [Header("UI COMPONENTS")]
    [SerializeField] private Slider levelProgressSlider;
    [SerializeField] private TextMeshProUGUI levelProgressText;

    [Header("OTHER COMPONENTS")]
    [SerializeField] private LevelController levelController;

    private void OnEnable()
    {
        levelController.OnNumberOfEnemiesChanged += LevelController_OnNumberOfEnemiesChanged;
    }

    private void OnDisable()
    {
        levelController.OnNumberOfEnemiesChanged -= LevelController_OnNumberOfEnemiesChanged;
    }

    private void LevelController_OnNumberOfEnemiesChanged(int currentNumberOfEnemies, int numberOfEnemiesPerLevel)
    {
        UpdateProgressSliderValues(currentNumberOfEnemies, numberOfEnemiesPerLevel);
        UpdateProgressText(currentNumberOfEnemies, numberOfEnemiesPerLevel);
    }

    private void UpdateProgressText(int currentNumberOfEnemies, int numberOfEnemiesPerLevel)
    {
        levelProgressText.text = $"{currentNumberOfEnemies}/{numberOfEnemiesPerLevel - 1}";
    }

    private void UpdateProgressSliderValues(int currentNumberOfEnemies, int numberOfEnemiesPerLevel)
    {
        levelProgressSlider.maxValue = numberOfEnemiesPerLevel - 1;
        levelProgressSlider.value = currentNumberOfEnemies;
    }
}
using System;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int currentLevel = 1;

    private int numberOfEnemiesPerLevel;
    private int currentNumberOfEnemies;

    public event Action<int, int> OnNumberOfEnemiesChanged;

    private void OnEnable()
    {
        StaticEventHandler.OnLevelCompleted += StaticEventHandler_OnLevelCompleted;
    }

    private void OnDisable()
    {
        StaticEventHandler.OnLevelCompleted -= StaticEventHandler_OnLevelCompleted;
    }

    private void Start()
    {
        if (SaveSystem.Instance.Load<int>(Settings.currentLevelKey) == 0)
        {
            currentLevel = 1;
        }
        else
        {
            currentLevel = SaveSystem.Instance.Load<int>(Settings.currentLevelKey);
        }

        CalculateNumberOfEnemiesForThisLevel();
    }

    private void StaticEventHandler_OnLevelCompleted()
    {
        currentLevel++;
        SaveSystem.Instance.Save<int>(currentLevel, Settings.currentLevelKey);
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public int GetNumberOfEnemiesPerLevel()
    {
        return numberOfEnemiesPerLevel;
    }

    public int GetCurrentNumberOfEnemies()
    {
        return currentNumberOfEnemies;
    }

    public void DecreaseCurrentNumberOfEnemies()
    {
        currentNumberOfEnemies--;
        OnNumberOfEnemiesChanged?.Invoke(currentNumberOfEnemies, numberOfEnemiesPerLevel);
    }

    private void CalculateNumberOfEnemiesForThisLevel()
    {
        numberOfEnemiesPerLevel = Settings.defaultNumberOfEnemies;
        int numberOfEnemiesToAddMultiplier = currentLevel / Settings.numberOfLevelToAddEnemies;

        numberOfEnemiesPerLevel += Settings.numberOfEnemiesToAdd * numberOfEnemiesToAddMultiplier;
        currentNumberOfEnemies = numberOfEnemiesPerLevel;
    }
}
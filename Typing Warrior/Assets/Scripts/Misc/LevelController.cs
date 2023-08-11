using System;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int currentLevel = 1;

    private int numberOfEnemiesPerLevel;
    private int currentNumberOfEnemies;

    public event Action<int, int> OnNumberOfEnemiesChanged;

    private void Start()
    {
        CalculateNumberOfEnemiesForThisLevel();
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
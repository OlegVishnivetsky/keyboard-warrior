using System;
using System.Collections.Generic;
using UnityEngine;

public class QueueOfEnemies : MonoBehaviour
{
    [Header("MAIN PARAMETERS")]
    [SerializeField] private int numberOfEnemies;
    [SerializeField] private Enemy enemyPrefab;

    private Queue<Enemy> enemies = new Queue<Enemy>();

    private Enemy currentActiveEnemy;

    public event Action<Enemy> OnNextEnemyChanged;

    private void Start()
    {
        GenerateQueueOfEnemies(numberOfEnemies);
        GetNextEnemy();
    }

    public Enemy GetNextEnemy()
    {
        if (currentActiveEnemy != null)
        {
            currentActiveEnemy.gameObject.SetActive(false);
        }

        Enemy nextEnemy = enemies.Dequeue();
        nextEnemy.gameObject.SetActive(true);
        nextEnemy.appearanceTween.Fade();

        enemies.Enqueue(nextEnemy);

        currentActiveEnemy = nextEnemy;

        OnNextEnemyChanged?.Invoke(nextEnemy);

        return nextEnemy;
    }

    public void GenerateQueueOfEnemies(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            InstantiateEnemy();
        }
    }

    public void InstantiateEnemy()
    {
        Enemy enemyObject = Instantiate(enemyPrefab, transform);
        enemyObject.gameObject.SetActive(false);

        enemies.Enqueue(enemyObject);
    }
}
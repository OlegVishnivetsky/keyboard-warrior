using System;
using System.Collections.Generic;
using UnityEngine;

public class QueueOfEnemies : MonoBehaviour
{
    [Header("MAIN PARAMETERS")]
    [SerializeField] private int numberOfEnemies;
    [SerializeField] private Enemy enemyPrefab;

    private Queue<Enemy> enemies = new Queue<Enemy>();

    public event Action<Enemy> OnNextEnemyChanged;

    private void Start()
    {
        GenerateQueueOfEnemies(numberOfEnemies);
        GetNextEnemy();
    }

    public Enemy GetNextEnemy()
    {
        Enemy nextEnemy = enemies.Dequeue();
        nextEnemy.gameObject.SetActive(true);

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
using System;
using System.Collections.Generic;
using UnityEngine;

public class QueueOfEnemies : MonoBehaviour
{
    [Header("MAIN PARAMETERS")]
    [SerializeField] private Enemy enemy;
    [SerializeField] private List<EnemyDetailsSO> enemyDetailsList;

    private Health enemyHealth;

    public event Action OnNextEnemyActivated;

    private void Awake()
    {
        enemyHealth = enemy.gameObject.GetComponent<Health>();
    }

    private void OnEnable()
    {
        enemyHealth.OnHealthWasOver += EnemyHealth_OnHealthWasOver;
    }

    private void OnDisable()
    {
        enemyHealth.OnHealthWasOver -= EnemyHealth_OnHealthWasOver;
    }

    private void Start()
    {
        enemy.gameObject.SetActive(false);
        ActivateNextEnemy();
    }

    private void EnemyHealth_OnHealthWasOver()
    {
        ActivateNextEnemy();
    }

    public Enemy GetCurrentEnemy()
    {
        return enemy;
    }

    public void ActivateNextEnemy()
    {
        if (enemy.gameObject.activeInHierarchy)
        {
            Keyboard.Instance.IsActive = false;

            enemy.appearanceTween.Hide(() =>
            {
                enemy.appearanceTween.Fade(() =>
                {
                    enemy.GenerateNewWord();
                    enemy.SetUpEnemyHealth();
                    OnNextEnemyActivated?.Invoke();

                    Keyboard.Instance.IsActive = true;
                });
            });

            return;
        }

        ActivateEnemy();
    }

    private void ActivateEnemy()
    {
        EnemyDetailsSO enemyDetails = GetRandomEnemyDetails();

        enemy.gameObject.SetActive(true);
        enemy.SetEnemyDetails(enemyDetails);
        enemy.SetUpEnemyHealth();

        OnNextEnemyActivated?.Invoke();
    }

    private EnemyDetailsSO GetRandomEnemyDetails()
    {
        int randomIndex = UnityEngine.Random.Range(0, enemyDetailsList.Count);

        return enemyDetailsList[randomIndex];
    }
}
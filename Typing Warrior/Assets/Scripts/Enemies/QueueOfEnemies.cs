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
    public event Action OnEnemyHided;

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

            OnEnemyHided?.Invoke();

            enemy.appearanceTween.Hide(() =>
            {
                SetRandomEnemyDetails();

                enemy.appearanceTween.Fade(() =>
                {
                    SetUpNextEnemy();

                    Keyboard.Instance.IsActive = true;
                });
            });

            return;
        }

        enemy.gameObject.SetActive(true);
        SetRandomEnemyDetails();
        SetUpNextEnemy();
    }

    private void SetUpNextEnemy()
    {
        enemy.GenerateNewWord();
        enemy.SetUpEnemyHealth();

        OnNextEnemyActivated?.Invoke();
    }

    private void SetRandomEnemyDetails()
    {
        int randomIndex = UnityEngine.Random.Range(0, enemyDetailsList.Count);
        EnemyDetailsSO enemyDetails = enemyDetailsList[randomIndex];

        enemy.SetEnemyDetails(enemyDetails);
    }
}
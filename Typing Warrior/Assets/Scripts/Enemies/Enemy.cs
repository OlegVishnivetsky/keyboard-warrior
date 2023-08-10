using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private EnemyDetailsSO enemyDetails;
    private Health health;

    [HideInInspector] public EnemyAppearanceTween appearanceTween;

    private string enemyWord;

    public event Action OnEnemyWordGenerated;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        health.OnHealthChanged += Health_OnHealthChanged;
    }

    private void OnDisable()
    {
        health.OnHealthChanged -= Health_OnHealthChanged;
    }

    private void Start()
    {
        SetUpEnemyHealth();
    }

    private void Health_OnHealthChanged(int currentHealth)
    {
        GenerateNewWord();
    }

    public void SetUpEnemyHealth()
    {
        health.SetMaxHeallth(enemyDetails.health);
        health.SetCurrentHealth(enemyDetails.health);
    }

    public EnemyDetailsSO GetEnemyDetails()
    {
        return enemyDetails;
    }

    public void SetEnemyDetails(EnemyDetailsSO enemyDetails)
    {
        this.enemyDetails = enemyDetails;
        SetUpEnemyAnimation(this.enemyDetails.animatorController);
    }

    public string GetEnemyWord() 
    { 
        return enemyWord; 
    }

    public void GenerateNewWord()
    {
        enemyWord = WordCollection.Instance.GetRandomWordFromCollection();
        OnEnemyWordGenerated.Invoke();
    }

    private void SetUpEnemyAnimation(RuntimeAnimatorController animatorController)
    {
        animator.runtimeAnimatorController = animatorController;
    }
}
using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(EnemyAttack))]
public class Enemy : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private EnemyDetailsSO enemyDetails;
    private EnemyAttack enemyAttack;
    private Health health;

    [HideInInspector] public EnemyAppearanceTween appearanceTween;

    private string enemyWord;

    public event Action OnEnemyWordGenerated;

    private void Awake()
    {
        health = GetComponent<Health>();
        enemyAttack = GetComponent<EnemyAttack>();
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

        SetUpEnemyAnimatorController(this.enemyDetails);
        SetUpRandomEnemyMaterial();
    }

    public string GetEnemyWord() 
    { 
        return enemyWord; 
    }

    public EnemyAttack GetEnemyAttack()
    {
        return enemyAttack;
    }

    public void GenerateNewWord()
    {
        enemyWord = WordCollection.Instance.GetRandomWordFromCollection();
        OnEnemyWordGenerated.Invoke();
    }

    private void SetUpEnemyAnimatorController(EnemyDetailsSO enemyDetails)
    {
        animator.runtimeAnimatorController = enemyDetails.animatorController;
    }

    private void SetUpRandomEnemyMaterial()
    {
        int randomMaterialNumber = UnityEngine.Random.Range(0, GameResources.Instance.enemyMaterials.Count);
        Material enemyMaterial = GameResources.Instance.enemyMaterials[randomMaterialNumber];

        spriteRenderer.material = enemyMaterial;
    }
}
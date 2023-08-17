using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(EnemyAttack))]
public class Enemy : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private LevelController levelController;

    private EnemyDetailsSO enemyDetails;
    private EnemyAttack enemyAttack;
    private Health enemyHealth;

    private int healthAmount;

    [HideInInspector] public EnemyAppearanceTween appearanceTween;

    private string enemyWord;

    public event Action OnEnemyWordGenerated;

    private void Awake()
    {
        enemyHealth = GetComponent<Health>();
        enemyAttack = GetComponent<EnemyAttack>();
    }

    private void OnEnable()
    {
        enemyHealth.OnHealthChanged += Health_OnHealthChanged;
    }

    private void OnDisable()
    {
        enemyHealth.OnHealthChanged -= Health_OnHealthChanged;
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
        healthAmount = enemyDetails.baseHealth + Mathf.FloorToInt(levelController.GetCurrentLevel() * 0.2f);

        enemyHealth.SetMaxHeallth(healthAmount);
        enemyHealth.SetCurrentHealth(healthAmount);
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
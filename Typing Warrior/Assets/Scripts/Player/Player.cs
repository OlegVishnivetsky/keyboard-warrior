using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{

    [Header("PLAYER BASE STATS")]
    [SerializeField] private int playerBaseHealth;
    [SerializeField] private int playerBaseDamage;
    [SerializeField] private int playerBaseArmor;

    private Health health;

    public PlayerStat Health { get; private set; }
    public PlayerStat Damage { get; private set; }
    public PlayerStat Armor { get; private set; }

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Start()
    {
        health.SetCurrentHealth(playerBaseHealth);
    }

    public void ResetPlayerStats()
    {
        Health = new PlayerStat(playerBaseHealth);
        Damage = new PlayerStat(playerBaseDamage);
        Armor = new PlayerStat(playerBaseArmor);
    }
}
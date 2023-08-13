using System;
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

    public event Action OnBeforePlayerInitialised;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        health.OnHealthWasOver += Health_OnHealthWasOver;
    }

    private void OnDisable()
    {
        health.OnHealthWasOver += Health_OnHealthWasOver;
    }

    private void Start()
    {
        OnBeforePlayerInitialised?.Invoke();
        health.SetMaxHeallth(Health.GetValue());
        health.SetCurrentHealth(Health.GetValue());
    }

    public Health GetPlayerHealth()
    {
        return health;
    }

    public void ResetPlayerStats()
    {
        Health = new PlayerStat(playerBaseHealth);
        Damage = new PlayerStat(playerBaseDamage);
        Armor = new PlayerStat(playerBaseArmor);
    }

    private void Health_OnHealthWasOver()
    {
        StaticEventHandler.InvokePlayerLostEvent();
    }
}
using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;

    public event Action<int> OnHealthChanged;
    public event Action OnHealthWasOver;

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetMaxHeallth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetCurrentHealth(int currentHealth)
    {
        this.currentHealth = currentHealth;
        OnHealthChanged?.Invoke(this.currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;       

        if (currentHealth <= 0)
        {
            OnHealthWasOver?.Invoke();
        }
        else
        {
            OnHealthChanged?.Invoke(currentHealth);
        }
    }
}
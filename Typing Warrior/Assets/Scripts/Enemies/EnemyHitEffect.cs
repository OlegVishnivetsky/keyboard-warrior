using System.Collections;
using UnityEngine;

public class EnemyHitEffect : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Health enemyHealth;

    [Header("MAIN PARAMTERS")]
    [SerializeField] private Color hitColor;
    [SerializeField] private float delayBetweenHit;
    [SerializeField] private int amountOfHit;

    private void OnEnable()
    {
        enemyHealth.OnHealthChanged += EnemyHealth_OnHealthChanged;
    }

    private void OnDisable()
    {
        enemyHealth.OnHealthChanged -= EnemyHealth_OnHealthChanged;
    }

    private void EnemyHealth_OnHealthChanged(int currentHealth)
    {
        if (currentHealth == enemyHealth.GetMaxHealth())
        {
            return;
        }

        HitEffect();
    }

    public void HitEffect()
    {
        StartCoroutine(HitEffectRoutine());
    }

    private IEnumerator HitEffectRoutine()
    {
        for (int i = 0; i < amountOfHit; i++)
        {
            spriteRenderer.color = hitColor;

            yield return new WaitForSeconds(delayBetweenHit);

            spriteRenderer.color = Color.white;

            yield return new WaitForSeconds(delayBetweenHit);
        }
    }
}
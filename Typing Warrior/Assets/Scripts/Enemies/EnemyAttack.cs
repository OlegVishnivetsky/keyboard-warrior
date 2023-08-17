using System;
using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private QueueOfEnemies queueOfEnemies;
    [SerializeField] private Health playerHealth;

    private float delayBeforeAttack;

    public event Action<float> OnDelayBeforeAttackChanged;
    public event Action<float> OnDelayBeforeAttackAssigned;

    private void OnEnable()
    {
        queueOfEnemies.OnNextEnemyActivated += QueueOfEnemies_OnNextEnemyActivated;
        queueOfEnemies.OnEnemyHided += QueueOfEnemies_OnEnemyHided;
    }

    private void OnDisable()
    {
        queueOfEnemies.OnNextEnemyActivated -= QueueOfEnemies_OnNextEnemyActivated;
        queueOfEnemies.OnEnemyHided -= QueueOfEnemies_OnEnemyHided;
    }

    private void QueueOfEnemies_OnEnemyHided()
    {
        StopAllCoroutines();
    }

    private void QueueOfEnemies_OnNextEnemyActivated()
    {
        Attack();
    }

    public void Attack()
    {
        StopAllCoroutines();

        delayBeforeAttack = queueOfEnemies.GetCurrentEnemy().GetEnemyDetails().delayBeforeAttack;
        OnDelayBeforeAttackAssigned?.Invoke(delayBeforeAttack);

        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        while (delayBeforeAttack > 0)
        {
            delayBeforeAttack -= Time.deltaTime;
            OnDelayBeforeAttackChanged?.Invoke(delayBeforeAttack);

            yield return null;
        }

        playerHealth.TakeDamage(queueOfEnemies.GetCurrentEnemy().GetEnemyDetails().baseDamage);

        AudioController.Instance.PlaySoundEffect(GameResources.Instance.playerTakeDamageSound);

        Attack();
    }

    public void ResetDelayBeforeAttack()
    {
        delayBeforeAttack = queueOfEnemies.GetCurrentEnemy().GetEnemyDetails().delayBeforeAttack;
        OnDelayBeforeAttackChanged?.Invoke(delayBeforeAttack);
    }
}
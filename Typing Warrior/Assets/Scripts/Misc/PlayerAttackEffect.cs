using System;
using UnityEngine;

public class PlayerAttackEffect : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private Animator animator;

    public event Action OnAttackEffectAnimationEnded;

    public void TriggerAttackEffectAnimation()
    {
        animator.SetTrigger(Settings.attackTrigger);
    }

    public void HandleAttackEffectAnimationEnding()
    {
        OnAttackEffectAnimationEnded();
    }
}
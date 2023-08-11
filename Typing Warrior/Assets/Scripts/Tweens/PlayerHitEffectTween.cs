using UnityEngine;

public class PlayerHitEffectTween : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private Health playerHealth;

    [Header("TWEEN PARAMETERS")]
    [SerializeField, Range(0f, 1f)] private float targetAlpha;
    [SerializeField] private float totalHitEffectDuration;
    [SerializeField] private LeanTweenType ease;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        playerHealth.OnHealthChanged += PlayerHealth_OnHealthChanged;
    }

    private void OnDisable()
    {
        playerHealth.OnHealthChanged -= PlayerHealth_OnHealthChanged;
    }

    private void PlayerHealth_OnHealthChanged(int currentHealth)
    {
        if (currentHealth == playerHealth.GetMaxHealth())
        {
            return;
        }

        HitEffect();
    }

    public void HitEffect()
    {
        if (LeanTween.isTweening(rectTransform))
        {
            return;
        }

        float duration = totalHitEffectDuration / 2f;

        LeanTween.alpha(rectTransform, targetAlpha, duration).setEase(ease)
            .setOnComplete(() =>
        {
            LeanTween.alpha(rectTransform, 0f, duration).setEase(ease);
        });
        ;
    }
}
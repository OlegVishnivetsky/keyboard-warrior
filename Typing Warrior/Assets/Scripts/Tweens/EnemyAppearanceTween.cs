using System;
using UnityEngine;

public class EnemyAppearanceTween : MonoBehaviour
{
    [Header("COMPONENTS")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("TWEEN PARAMETERS")]
    [SerializeField] private float duration;
    [SerializeField] private LeanTweenType alphaEase;
    [SerializeField] private LeanTweenType scaleEase;

    private void OnEnable()
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
    }

    public void Fade()
    {
        transform.localScale = new Vector3(0.8f, 0.8f, 1);

        LeanTween.scale(gameObject, Vector3.one, duration).setEase(scaleEase);
        LeanTween.alpha(spriteRenderer.gameObject, 1f, duration).setEase(alphaEase);
    }

    public void Hide()
    {
        transform.localScale = Vector3.one;

        LeanTween.scale(gameObject, new Vector3(0.8f, 0.8f, 1), duration).setEase(scaleEase);
        LeanTween.alpha(spriteRenderer.gameObject, 0f, duration).setEase(alphaEase);
    }

    public void Fade(Action onComplete)
    {
        transform.localScale = new Vector3(0.8f, 0.8f, 1);

        LeanTween.scale(gameObject, Vector3.one, duration).setEase(scaleEase);
        LeanTween.alpha(spriteRenderer.gameObject, 1f, duration).setEase(alphaEase)
            .setOnComplete(onComplete);
    }

    public void Hide(Action onComplete)
    {
        transform.localScale = Vector3.one;

        LeanTween.scale(gameObject, new Vector3(0.8f, 0.8f, 1), duration).setEase(scaleEase);
        LeanTween.alpha(spriteRenderer.gameObject, 0f, duration).setEase(alphaEase)
            .setOnComplete(onComplete);
    }
}
using System;
using UnityEngine;

public class SceneTransitionTween : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private RectTransform transitionCircleTransform;

    [Header("TWEEN PARAMETERS")]
    [SerializeField] private float duration;
    [SerializeField] private LeanTweenType ease;

    private void Start()
    {
        transitionCircleTransform.anchoredPosition = new Vector3(500f, 0f, 0f);
        transitionCircleTransform.gameObject.SetActive(true);

        transitionCircleTransform.LeanMoveLocalX(-(transitionCircleTransform.sizeDelta.x / 2), duration)
            .setEase(ease).setOnComplete(() =>
            {
                transitionCircleTransform.gameObject.SetActive(false);
            });
    }

    public void TransitionScene(Action onComplete)
    {
        transitionCircleTransform.gameObject.SetActive(true);

        transitionCircleTransform.LeanMoveLocalX(500f, duration)
            .setEase(ease).setOnComplete(() =>
        {
            onComplete?.Invoke();
        });
    }
}
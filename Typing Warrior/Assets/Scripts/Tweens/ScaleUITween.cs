using UnityEngine;

public class ScaleUITween : MonoBehaviour
{
    [Header("TWEEN PARAMETERS")]
    [SerializeField] private float duration;
    [SerializeField] private LeanTweenType ease;
    [SerializeField] private Vector3 targetScale;

    [Header("MAIN COMPONENTS")]
    [SerializeField] private RectTransform rectTransform;

    public void ScaleIn()
    {
        if (LeanTween.isTweening(rectTransform))
        {
            return;
        }

        rectTransform.LeanScale(targetScale, duration).setEase(ease);
    }

    public void ScaleOut() 
    {
        if (LeanTween.isTweening(rectTransform))
        {
            return;
        }

        rectTransform.LeanScale(Vector3.zero, duration).setEase(ease);
    }
}
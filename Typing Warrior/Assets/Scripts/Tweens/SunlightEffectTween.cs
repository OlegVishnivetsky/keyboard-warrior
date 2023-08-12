using UnityEngine;

public class SunlightEffectTween : MonoBehaviour
{
    [Header("TWEEN PARAMETERS")]
    [SerializeField] private float rotateAroundDuration;
    [SerializeField] private float scaleDuration;
    [SerializeField] private LeanTweenType ease;

    private void Start()
    {
        SunlightEffect();
    }

    private void SunlightEffect()
    {
        LeanTween.rotateAround(gameObject, Vector3.forward, 360f, rotateAroundDuration).setLoopPingPong();
        LeanTween.scale(gameObject, new Vector3(0.5f, 0.5f, 0.5f), scaleDuration).setEase(ease)
            .setLoopPingPong();
    }
}
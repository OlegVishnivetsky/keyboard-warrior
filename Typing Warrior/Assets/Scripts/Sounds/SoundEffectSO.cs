using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Sounds/SoundEffect", fileName = "_SoundEffect")]
public class SoundEffectSO : ScriptableObject
{
    [Header("AUIDIO CLIP")]
    public AudioClip soundEffectClip;

    [Header("PITCH PARAMETERS")]
    [Range(0.1f, 1.5f)]
    public float soundEffectPitchRandomVariationMin = 0.8f;
    [Range(0.1f, 1.5f)]
    public float soindEffectPitchRandomVariationMax = 1.2f;
}
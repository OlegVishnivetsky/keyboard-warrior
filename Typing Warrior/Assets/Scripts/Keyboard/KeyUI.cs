using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Key))]
public class KeyUI : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private TextMeshProUGUI keyCharacterText;
    [SerializeField] private Image imageComponent;

    [Header("KEY CLICK PARAMETERS")]
    [SerializeField] private Color normalColor;
    [SerializeField] private Color pressedColor;
    [SerializeField] private float colorChangeDuration;

    private Key key;

    private void Awake()
    {
        key = GetComponent<Key>();
    }

    private void OnEnable()
    {
        key.OnKeyPressed += Key_OnKeyPressed;
        key.OnKeyCharacterSetted += Key_OnKeyInitialized;
    }

    private void OnDisable()
    {
        key.OnKeyPressed -= Key_OnKeyPressed;
        key.OnKeyCharacterSetted -= Key_OnKeyInitialized;
    }

    private void Key_OnKeyPressed()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeKeyColorRoutine());
    }

    private void Key_OnKeyInitialized(char keyCharacter)
    {
        keyCharacterText.text = keyCharacter.ToString();
    }

    private IEnumerator ChangeKeyColorRoutine()
    {
        imageComponent.color = pressedColor;

        yield return new WaitForSeconds(colorChangeDuration);

        imageComponent.color = normalColor;
    }
}
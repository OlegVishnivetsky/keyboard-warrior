using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Key))]
public class KeyUI : MonoBehaviour
{
    [Header("TEXT COMPONENTS")]
    [SerializeField] private TextMeshProUGUI keyCharacterText;

    private Key key;

    private void Awake()
    {
        key = GetComponent<Key>();
    }

    private void OnEnable()
    {
        key.OnKeyCharacterSetted += Key_OnKeyInitialized;
    }

    private void OnDisable()
    {
        key.OnKeyCharacterSetted -= Key_OnKeyInitialized;
    }

    private void Key_OnKeyInitialized(char keyCharacter)
    {
        keyCharacterText.text = keyCharacter.ToString();
    }
}
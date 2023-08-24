using System;
using UnityEngine;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
public class Key : MonoBehaviour, IPointerClickHandler
{
    [Header("MAIN PARAMETERS")]
    [SerializeField] private char keyCharacter;
    [SerializeField] private Keyboard keyboard;

    public event Action OnKeyPressed;
    public event Action<char> OnKeyCharacterSetted;

    private void Awake()
    {
        keyboard = GetComponentInParent<Keyboard>();
    }

    private void Start()
    {
        OnKeyCharacterSetted?.Invoke(keyCharacter);
    }

    public void SetKeyCharacter(char keyCharacter)
    {
        this.keyCharacter = keyCharacter;
        OnKeyCharacterSetted?.Invoke(this.keyCharacter);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnKeyPressed?.Invoke();

        AudioController.Instance.PlaySoundEffect(GameResources.Instance.clickSound);

        keyboard.AddKeyCharacterToInput(keyCharacter);
    }
}
using UnityEngine;

public class GameOverPanelUI : MonoBehaviour
{
    [Header("MAIN CONPONENTS")]
    [SerializeField] private ScaleUITween scaleTween;
    [SerializeField] private PauseController pauseController;

    private void OnEnable()
    {
        StaticEventHandler.OnPlayerLost += StaticEventHandler_OnPlayerLost;
    }

    private void OnDisable()
    {
        StaticEventHandler.OnPlayerLost -= StaticEventHandler_OnPlayerLost;
    }

    private void StaticEventHandler_OnPlayerLost()
    {
        scaleTween.ScaleIn(() =>
        {
            pauseController.PauseGame();
        });
    }
}
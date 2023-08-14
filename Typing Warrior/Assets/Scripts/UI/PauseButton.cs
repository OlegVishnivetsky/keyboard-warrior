using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private PauseController pausedController;
    [SerializeField] private ScaleUITween scaleTween;

    public void PauseAndScaleIn()
    {
        scaleTween.ScaleIn(() =>
        {
            pausedController.PauseGame();
        });
    }

    public void UnpauseAndScaleOut()
    {
        pausedController.UnpauseGame();

        scaleTween.ScaleOut();
    }
}
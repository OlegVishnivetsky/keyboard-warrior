using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SceneTransitionTween sceneTransitionTween;

    public static event Action<string> OnSceneChanged;

    private void Start()
    {
        OnSceneChanged?.Invoke(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenuScene()
    {
        sceneTransitionTween.TransitionScene(() =>
        {
            SceneManager.LoadScene(Settings.mainMenuScene);
        });     
    }

    public void LoadInventoryScene()
    {
        sceneTransitionTween.TransitionScene(() =>
        {
            SceneManager.LoadScene(Settings.inventoryScene);
        });
    }

    public void LoadGameScene()
    {
        sceneTransitionTween.TransitionScene(() =>
        {
            SceneManager.LoadScene(Settings.gameScene);
        });
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
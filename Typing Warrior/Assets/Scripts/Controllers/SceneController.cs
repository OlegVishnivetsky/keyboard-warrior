using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static event Action<string> OnSceneChanged;

    private void Start()
    {
        OnSceneChanged?.Invoke(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(Settings.mainMenuScene);
    }

    public void LoadInventoryScene()
    {
        SceneManager.LoadScene(Settings.inventoryScene);
        OnSceneChanged?.Invoke(Settings.inventoryScene);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(Settings.gameScene);
        OnSceneChanged?.Invoke(Settings.gameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
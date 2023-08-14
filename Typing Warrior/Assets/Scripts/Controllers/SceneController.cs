using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(Settings.mainMenuScene);
    }

    public void LoadInventoryScene()
    {
        SceneManager.LoadScene(Settings.inventoryScene);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(Settings.gameScene);
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class SleepPanelInMainMenu : MonoBehaviour
{
    public void GoNextSceneOrExitGame()
    {
        if (MainMenuButtons.CanNextScene)
            SceneManager.LoadScene(1);
        else
            Application.Quit();
    }
}

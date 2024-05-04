using UnityEngine;
using UnityEngine.SceneManagement;

public class SleepPanelInGameScene : MonoBehaviour
{
    public void ToMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}

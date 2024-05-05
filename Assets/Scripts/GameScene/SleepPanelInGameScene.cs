using UnityEngine;
using UnityEngine.SceneManagement;

public class SleepPanelInGameScene : MonoBehaviour
{
    [SerializeField] public static int SceneIndex;
    public void ToMainMenuOrRestart()
    {
        SceneManager.LoadScene(SceneIndex);
    }
}

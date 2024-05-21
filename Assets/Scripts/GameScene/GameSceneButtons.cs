using UnityEngine;

public class GameSceneButtons : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _sleepPanel;

    public void PauseMenuButton()
    {
        _pauseMenu.SetActive(true);
        PlayerMovementWithSwipes.Instance.Speed = 0f;
        Score.IsPaused = true;
    }

    public void ClosePauseMenuButton()
    {
        _pauseMenu.GetComponent<Animator>().SetTrigger("Disable");
        PlayerMovementWithSwipes.Instance.Speed = 1f;
        Score.IsPaused = false;
    }

    public void Restart()
    {
        _sleepPanel.SetActive(true);
        SleepPanelInGameScene.SceneIndex = 1;
    }

    public void GoToMainMenuButton()
    {
        _sleepPanel.SetActive(true);
        SleepPanelInGameScene.SceneIndex = 0;
    }
}

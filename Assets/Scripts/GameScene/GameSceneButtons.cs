using UnityEngine;
using UnityEngine.Windows.Speech;

public class GameSceneButtons : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _sleepPanel;

    public void PauseMenuButton()
    {
        _pauseMenu.SetActive(true);
        PlayerMovementWithSwipes.Instance.Speed = 0f;
    }

    public void ClosePauseMenuButton()
    {
        _pauseMenu.GetComponent<Animator>().SetTrigger("Disable");
        PlayerMovementWithSwipes.Instance.Speed = 1f;
    }

    public void GoToMainMenuButton()
    {
        _sleepPanel.SetActive(true);
    }
}

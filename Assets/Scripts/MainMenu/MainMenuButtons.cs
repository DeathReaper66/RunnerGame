using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject _sleepPanel;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _magazineMenu;

    public static bool CanNextScene;

    public void StartGameButton()
    {
        _sleepPanel.SetActive(true);
        CanNextScene = true;
    }

    public void SettingsButton()
    {
        _settingsMenu.SetActive(true);
    }

    public void ExitSettingsButton()
    {
        _settingsMenu.GetComponent<Animator>().SetTrigger("Disable");
    }

    public void MagazineButton()
    {
        _magazineMenu.SetActive(true);
    }

    public void ExitMagazineButton()
    {
        _magazineMenu.GetComponent<Animator>().SetTrigger("Disable");
    }

    public void ExitButton()
    {
        _sleepPanel.SetActive(true);
        CanNextScene = false;
    }
}

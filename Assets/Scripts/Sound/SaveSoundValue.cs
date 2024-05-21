using UnityEngine;
using UnityEngine.UI;

public class SaveSoundValue : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    public static bool Firstable = true;

    public void ChangedSoundVolume()
    {
        Firstable = false;
        PlayerPrefs.SetFloat("SoundVolume", _slider.value);
        SoundManager.Instance.Source.volume = PlayerPrefs.GetFloat("SoundVolume");
    }
}

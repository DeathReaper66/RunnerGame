using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [NonSerialized] public static SoundManager Instance;
    [NonSerialized] public AudioSource Source;

    private void Awake()
    {
        Source = GetComponent<AudioSource>();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
            Destroy(gameObject);

        if (!SaveSoundValue.Firstable)
            Source.volume = PlayerPrefs.GetFloat("SoundVolume");
    }

    public void PlaySound(AudioClip audio)
    {
        Source.PlayOneShot(audio);
    }

}

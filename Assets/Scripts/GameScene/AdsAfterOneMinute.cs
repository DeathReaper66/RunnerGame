using System.Collections;
using UnityEngine;

public class AdsAfterOneMinute : MonoBehaviour
{
    private float _timer = 0f;
    [SerializeField] private GameObject _adsPanel;

    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;

        if (_timer >= 65f)
            StartCoroutine(Ads());
    }

    private IEnumerator Ads()
    {
        _timer = 0f;
        _adsPanel.SetActive(true);
        Score.IsPaused = true;
        PlayerMovementWithSwipes.Instance.Speed = 0f;
        yield return new WaitForSeconds(2f);
        YG.YandexGame.FullscreenShow();
        PlayerMovementWithSwipes.Instance.Speed = 1f;
        Score.IsPaused = false;
        _adsPanel.SetActive(false);
        _timer = 0f;
    }
}

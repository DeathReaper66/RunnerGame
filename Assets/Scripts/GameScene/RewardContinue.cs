using YG;
using UnityEngine;

public class RewardContinue : MonoBehaviour
{
    [SerializeField] private YandexGame _yg;
    [SerializeField] private GameObject _deadMenu;
    [SerializeField] private PlayerHealthSystem _playerHP;

    public void AddButton()
    {
        _yg._RewardedShow(1);
    }

    public void Reward()
    {
        Score.IsPaused = false;
        PlayerMovementWithSwipes.Instance.Speed = 1f;
        _playerHP.Revive();
        Destroy(gameObject);
        _deadMenu.SetActive(false);
    }
}

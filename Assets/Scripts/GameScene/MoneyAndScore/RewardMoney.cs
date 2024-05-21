using YG;
using UnityEngine;
using TMPro;

public class RewardMoney : MonoBehaviour
{
    [SerializeField] private YandexGame _yg;
    [SerializeField] private TMP_Text _moneyText;

    public void AddButton()
    {
        _yg._RewardedShow(1);
    }

    public void Reward()
    {
        PlayerPrefs.SetInt("CoinValue", PlayerPrefs.GetInt("CoinValue") + 20);
        _moneyText.text = PlayerPrefs.GetInt("CoinValue").ToString();
    }
}

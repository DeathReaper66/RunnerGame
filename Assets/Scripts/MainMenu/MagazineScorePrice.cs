using TMPro;
using UnityEngine;

public class MagazineScorePrice : MonoBehaviour
{
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _coinText;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("ScorePrice") == 0)
            PlayerPrefs.SetInt("ScorePrice", 20);

        _priceText.text = PlayerPrefs.GetInt("ScorePrice").ToString();
    }

    public void Cell()
    {
        if (PlayerPrefs.GetInt("CoinValue") >= PlayerPrefs.GetInt("ScorePrice"))
        {
            PlayerPrefs.SetInt("CoinValue", PlayerPrefs.GetInt("CoinValue") - PlayerPrefs.GetInt("ScorePrice"));
            PlayerPrefs.SetInt("ScorePrice", PlayerPrefs.GetInt("ScorePrice") + 20);
            PlayerPrefs.SetInt("ScoreScale", PlayerPrefs.GetInt("ScoreScale") + 1);
            _priceText.text = PlayerPrefs.GetInt("ScorePrice").ToString();
            _coinText.text = PlayerPrefs.GetInt("CoinValue").ToString();
        }
    }
}

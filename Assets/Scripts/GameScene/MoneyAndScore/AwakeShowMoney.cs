using TMPro;
using UnityEngine;

public class AwakeShowMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;

    private void Awake()
    {
        _moneyText.text = PlayerPrefs.GetInt("CoinValue").ToString();
    }
}

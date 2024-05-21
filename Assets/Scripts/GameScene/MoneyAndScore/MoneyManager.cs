using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private AudioClip _pickUpAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            SoundManager.Instance.PlaySound(_pickUpAudio);
            PlayerPrefs.SetInt("CoinValue", PlayerPrefs.GetInt("CoinValue") + 1);
            _moneyText.text = PlayerPrefs.GetInt("CoinValue").ToString();
            collision.gameObject.SetActive(false);
        }
    }
}

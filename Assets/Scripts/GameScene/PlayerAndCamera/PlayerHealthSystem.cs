using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private Image _currentHealthImage;
    [SerializeField] private Image _maxHealthImage;
    [SerializeField] private GameObject _deadMenu;
    private float _healthValue;

    [SerializeField] private AudioClip _takeDamageAudio;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _healthValue = 5f;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "EnemyBullet")
            StartCoroutine(TakeDamage());

        if (collision.tag == "Heal")
        {
            _healthValue = Mathf.Clamp(_healthValue + 1f, 0f, 5f);
            _currentHealthImage.fillAmount = _healthValue / 5f;
            collision.gameObject.SetActive(false);
        }
    }

    private IEnumerator TakeDamage()
    {
        SoundManager.Instance.PlaySound(_takeDamageAudio);

        Physics2D.IgnoreLayerCollision(6, 7, true);
        Physics2D.IgnoreLayerCollision(6, 9, true);

        _healthValue -= 1f;
        _currentHealthImage.fillAmount = _healthValue / 5f;

        if (_healthValue <= 0)
        {
            GetComponent<Score>().ShowScore();
            Score.IsPaused = true;
            PlayerMovementWithSwipes.Instance.Speed = 0f;
            _deadMenu.SetActive(true);
        }


        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.2f);
            _spriteRenderer.color = new Color(255, 0, 0, 255);
            yield return new WaitForSeconds(0.2f);
            _spriteRenderer.color = new Color(255, 255, 255, 255);
        }

        Physics2D.IgnoreLayerCollision(6, 9, false);
        Physics2D.IgnoreLayerCollision(6, 7, false);

    }

    public void Revive()
    {
        _healthValue = 6f;
        _currentHealthImage.fillAmount = _healthValue / 5f;
    }
}

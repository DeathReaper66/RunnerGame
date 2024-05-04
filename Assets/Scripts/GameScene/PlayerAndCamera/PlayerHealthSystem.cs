using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private Image _currentHealthImage;
    [SerializeField] private Image _maxHealthImage;
    [SerializeField] private GameObject _deadMenu;
    private float _healthValue;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _healthValue = 3f;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
            StartCoroutine(TakeDamage());
    }

    private IEnumerator TakeDamage()
    {
        _healthValue -= 1f;
        _currentHealthImage.fillAmount = _healthValue / 3f;

        if (_healthValue > 0)
        {
            Physics2D.IgnoreLayerCollision(6, 7, true);

            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(0.2f);
                _spriteRenderer.color = new Color(255, 0, 0, 255);
                yield return new WaitForSeconds(0.2f);
                _spriteRenderer.color = new Color(0, 255, 157, 255);
            }

            Physics2D.IgnoreLayerCollision(6, 7, false);
        }
        else
        {
            PlayerMovementWithSwipes.Instance.Speed = 0f;
            _deadMenu.SetActive(true);
        }
    }
}

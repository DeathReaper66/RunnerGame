using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _health;

    [Header("Attack")]
    [SerializeField] private GameObject _enemyBullet;
    private float _attackCooldown = 1.5f;
    private float _attackCooldownTimer = 0f;

    [SerializeField] private AudioClip _dieAudio;

    private Animator _anim;


    private void Awake()
    {
        _health = Random.Range(1, 3);

        _anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!Score.IsPaused)
        {
            _attackCooldownTimer += Time.fixedDeltaTime;

            if (_attackCooldownTimer > _attackCooldown)
            {
                _anim.SetTrigger("Attack");
                _attackCooldownTimer = 0f;
                Instantiate(_enemyBullet, transform.position - transform.up, transform.rotation);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            _health--;

            if (_health == 0)
            {
                SoundManager.Instance.PlaySound(_dieAudio);
                Score.KillEnemy();
                Destroy(gameObject);
            }
        }
    }
}

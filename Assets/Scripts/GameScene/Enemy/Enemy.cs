using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _health;
    private float _maxX = 1.5f;
    private float _speed;
    private bool _moveLeft = true;

    [Header("Attack")]
    [SerializeField] private GameObject _enemyBullet;
    [SerializeField] private float _attackCooldown = 3f;
    private float _attackCooldownTimer = 0f;


    private void Awake()
    {
        _health = Random.Range(1, 4);
        _speed = (Random.Range(2, 5) * Time.fixedDeltaTime) / 2f;
    }

    private void FixedUpdate()
    {
        Move();

        _attackCooldownTimer += Time.fixedDeltaTime;

        if (_attackCooldownTimer > _attackCooldown)
        {
            _attackCooldownTimer = 0f;
            Instantiate(_enemyBullet, transform.position - transform.up, transform.rotation);
        }
    }

    private void Move()
    {
        if (transform.position.x >= 1.5f)
            _moveLeft = true;
        else if (transform.position.x <= -1.5f)
            _moveLeft = false;

        if (_moveLeft)
            transform.Translate(-_speed, 0f, 0f);
        else
            transform.Translate(_speed, 0f, 0f);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_maxX, _maxX), transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            _health--;

            if (_health == 0)
                Destroy(gameObject);
        }
    }
}

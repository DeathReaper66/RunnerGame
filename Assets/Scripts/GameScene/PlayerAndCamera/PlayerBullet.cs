using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float _lifeTimer = 0f;

    private void FixedUpdate()
    {
        float speed = PlayerMovementWithSwipes.Instance.Speed * PlayerMovementWithSwipes.Instance.SpeedScale * Time.fixedDeltaTime * 4f;
        transform.Translate(0f, speed, 0f);

        _lifeTimer += Time.fixedDeltaTime;

        if (_lifeTimer > 3f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "EnemyBullet")
            Destroy(gameObject);
    }
}

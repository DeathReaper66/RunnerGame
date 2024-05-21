using UnityEngine;

public class ForEverySpawnable : MonoBehaviour
{
    private float _lifeTimeTimer = 0f;

    private void Awake()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.5f, 1.5f), transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (!Score.IsPaused)
        {
            _lifeTimeTimer += Time.fixedDeltaTime;
            if (_lifeTimeTimer > 8f)
                Destroy(gameObject);
        }

        float speed = PlayerMovementWithSwipes.Instance.Speed * PlayerMovementWithSwipes.Instance.SpeedScale * Time.fixedDeltaTime * 2f;
        transform.Translate(0f, -speed, 0f);
    }
}

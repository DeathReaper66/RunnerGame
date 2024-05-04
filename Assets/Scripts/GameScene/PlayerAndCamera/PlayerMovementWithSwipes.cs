using UnityEngine;

public class PlayerMovementWithSwipes : MonoBehaviour
{
    public static PlayerMovementWithSwipes Instance { get; private set; }
    [SerializeField] public float Speed;
    [SerializeField] private float _maxX;

    private float _moveCooldown = 0.3f;
    private float _moveCooldownTimer = 0f;
    private Rigidbody2D _rb;

    private void Awake()
    {
        Instance = this;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _moveCooldownTimer += Time.fixedDeltaTime;

        _rb.velocity = new Vector3(_rb.velocity.x, Speed);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved && _moveCooldownTimer > _moveCooldown)
            {
                _moveCooldownTimer = 0f;

                if (touch.deltaPosition.x > 0)
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x + 1.5f, -_maxX, _maxX), transform.position.y, transform.position.z);
                else
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x - 1.5f, -_maxX, _maxX), transform.position.y, transform.position.z);
            }
        }
    }
}

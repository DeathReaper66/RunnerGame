using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _attackCooldown = 0.3f;
    private float _attackCooldownTimer = 0f;

    private void FixedUpdate()
    {
        _attackCooldownTimer += Time.fixedDeltaTime;

        if (_attackCooldownTimer > _attackCooldown && Input.touchCount > 0)
        {
            _attackCooldownTimer = 0f;
            Instantiate(_bullet, transform.position + transform.up, transform.rotation);
        }
    }
}

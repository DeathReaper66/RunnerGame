using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _attackCooldown = 1f;
    private float _attackCooldownTimer = 0f;

    [SerializeField] private AudioClip _attackAudio;

    private void FixedUpdate()
    {
        if (!Score.IsPaused)
            _attackCooldownTimer += Time.fixedDeltaTime;

        if (_attackCooldownTimer > _attackCooldown && Input.touchCount > 0)
        {
            SoundManager.Instance.PlaySound(_attackAudio);
            _attackCooldownTimer = 0f;
            Instantiate(_bullet, transform.position + transform.up, transform.rotation);
        }
    }
}

using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private void FixedUpdate()
    {
        float speed = PlayerMovementWithSwipes.Instance.Speed;

        transform.Translate(0f, speed * Time.fixedDeltaTime, 0f);
    }
}

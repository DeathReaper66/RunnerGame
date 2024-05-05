using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private void FixedUpdate()
    {
        float speed = PlayerMovementWithSwipes.Instance.Speed * PlayerMovementWithSwipes.Instance.SpeedScale * Time.fixedDeltaTime;

        transform.Translate(0f, speed, 0f);
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class Camera_move : MonoBehaviour
{
    public float speed = 10f;
    public float sensitivity = 0.2f;
    public float minPitch = -90f;
    public float maxPitch = 80f;

    private float yaw = 0f;
    private float pitch = 0f;
    void Start()
    {
        Vector3 e = transform.eulerAngles;
        yaw = e.y;
        pitch = e.x;
        if (pitch > 180f) pitch -= 360f;
    }

    void Update()
    {
        if (Mouse.current != null)
        {
            if (Mouse.current.rightButton.isPressed)
            {
                Vector2 delta = Mouse.current.delta.ReadValue();

                yaw += delta.x * sensitivity;
                pitch -= delta.y * sensitivity;
                pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

                transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
            }
        }

        if (Keyboard.current == null) return;
        float h = 0f;
        float v = 0f;
        float up = 0f;
        speed = 10f;

        if (Keyboard.current.dKey.isPressed) h += 1f;
        if (Keyboard.current.aKey.isPressed) h -= 1f;

        Vector3 forward = transform.forward;
        forward.y = 0f;
        forward.Normalize();

        if (Keyboard.current.wKey.isPressed) v += 1f;
        if (Keyboard.current.sKey.isPressed) v -= 1f;

        Vector3 right = transform.right;
        right.y = 0f;
        right.Normalize();

        if (Keyboard.current.qKey.isPressed) up += 1f;
        if (Keyboard.current.eKey.isPressed) up -= 1f;
        Vector3 down = transform.up;
        down.x = 0f;
        down.z = 0f;
        down.Normalize();

        if (Keyboard.current.shiftKey.isPressed) speed = 30f;

        Vector3 move = (right * h + down * up + forward * v) * speed * Time.deltaTime;
        transform.position += move;
    }
}

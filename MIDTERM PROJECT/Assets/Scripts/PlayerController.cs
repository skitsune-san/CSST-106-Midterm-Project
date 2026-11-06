using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Transform cam;
    public float speed = 4f;
    public float sensitivity = 2f;
    public float gravity = -20f;

    CharacterController controller;
    float pitch;
    float verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Cursor.lockState != CursorLockMode.Locked) return;

        transform.Rotate(0f, Input.GetAxis("Mouse X") * sensitivity, 0f);
        pitch = Mathf.Clamp(pitch - Input.GetAxis("Mouse Y") * sensitivity, -80f, 80f);
        cam.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        Vector3 move = transform.right * Input.GetAxis("Horizontal")
                     + transform.forward * Input.GetAxis("Vertical");

        verticalVelocity = controller.isGrounded ? -2f : verticalVelocity + gravity * Time.deltaTime;
        move = move * speed + Vector3.up * verticalVelocity;
        controller.Move(move * Time.deltaTime);
    }
}
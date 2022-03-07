using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // controls mouse speed.
    public float mouseSensitivity = 100f;
    // reference to player to match camera movement.
    public Transform playerBody;
    // rotates camera on X axis with mouse Y movement.
    float xRotation = 0f;

    private void Start()
    {
        // hide and lock cursor to make it invisible while clicking around in game mode.
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // records mouse side to side movement 

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // decreases cam X rotation every frame with mouse Y movement.
        xRotation -= mouseY;
        // limits player rotation so they don't look behind.
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        // keeps track of xRotation so it can be clamped.
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // player rotates around Y axis along with mouseX.
        playerBody.Rotate(Vector3.up * mouseX);
    }

}

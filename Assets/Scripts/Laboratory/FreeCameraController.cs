using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;
    public float rotateKeySpeed = 30f;

    private float yaw = 0f;
    private float pitch = 0f;

    void Update()
    {
        // 🚫 No mover la cámara si estás manipulando el vaso
        if (WaterPour.IsDraggingGlassCup)
            return;

        // 🔁 Rotar con mouse (clic derecho)
        if (Input.GetMouseButton(1))
        {
            yaw += lookSpeed * Input.GetAxis("Mouse X");
            pitch -= lookSpeed * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }

        // 🔁 Rotar con teclas X (mirar abajo) y Z (mirar arriba)
        if (Input.GetKey(KeyCode.X))
        {
            pitch += rotateKeySpeed * Time.deltaTime;
            pitch = Mathf.Clamp(pitch, -89f, 89f);
            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            pitch -= rotateKeySpeed * Time.deltaTime;
            pitch = Mathf.Clamp(pitch, -89f, 89f);
            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }

        // 🎮 Movimiento con teclas
        float horizontal = Input.GetAxis("Horizontal"); // A/D
        float vertical = Input.GetAxis("Vertical");     // W/S
        float upDown = 0f;

        if (Input.GetKey(KeyCode.E)) upDown = 1f;
        if (Input.GetKey(KeyCode.Q)) upDown = -1f;

        Vector3 direction = new Vector3(horizontal, upDown, vertical);
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.Self);
    }
}

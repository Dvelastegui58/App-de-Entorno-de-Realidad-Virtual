using UnityEngine;

public class PotMover : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;
    public float rotationSpeed = 50f;
    public float zoomSpeed = 2f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Clic para comenzar a arrastrar
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                isDragging = true;
                offset = transform.position - hit.point;
            }
        }

        // Soltar al dejar de hacer clic
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            // Movimiento con mouse
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePosition);
            transform.position = new Vector3(worldPos.x, worldPos.y, transform.position.z);

            // Rotación con teclas A/D
            if (Input.GetKey(KeyCode.A))
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.D))
                transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);

            // Zoom con scroll
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (Mathf.Abs(scroll) > 0.01f)
                transform.position += new Vector3(0, 0, scroll * zoomSpeed);
        }
    }
}

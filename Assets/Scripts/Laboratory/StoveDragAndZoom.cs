using UnityEngine;

public class StoveDragAndZoom : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;
    public float scrollSpeed = 2f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        HandleMouseDrag();
        HandleMouseScroll();
    }

    void HandleMouseDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Verifica si se hizo clic sobre este objeto
            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                isDragging = true;
                offset = transform.position - hit.point;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = mainCamera.WorldToScreenPoint(transform.position).z;

            Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
            transform.position = new Vector3(worldPos.x + offset.x, worldPos.y + offset.y, transform.position.z);
        }
    }

    void HandleMouseScroll()
    {
        if (isDragging)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (Mathf.Abs(scroll) > 0.01f)
            {
                transform.position += new Vector3(0, 0, scroll * scrollSpeed);
            }
        }
    }
}

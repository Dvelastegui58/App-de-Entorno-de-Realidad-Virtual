using UnityEngine;

public class WaterPour : MonoBehaviour
{
    public Transform potTransform;        // Referencia al objeto "Pot"
    public float pourDistance = 2.5f;     // Distancia para verter
    public Transform water;               // Agua del vaso
    public Transform potWater;            // Agua de la olla (nombre corregido aquí)
    public float pourAngle = 30f;
    public float pourSpeed = 0.2f;
    public float rotationSpeed = 50f;
    public float zoomSpeed = 2f;
    public float maxPotWaterYScale = 0.5f;

    public static bool IsDraggingGlassCup = false;

    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                isDragging = true;
                IsDraggingGlassCup = true;
                offset = transform.position - hit.point;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            IsDraggingGlassCup = false;
        }

        if (isDragging)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePosition);
            transform.position = new Vector3(worldPos.x, worldPos.y, transform.position.z);

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
            }

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (Mathf.Abs(scroll) > 0.01f)
            {
                transform.position += new Vector3(0, 0, scroll * zoomSpeed);
            }
        }

        float inclinationZ = Mathf.Abs(transform.localEulerAngles.z);
        if (inclinationZ > 180f) inclinationZ = 360f - inclinationZ;

        if (inclinationZ > pourAngle)
        {
            Vector3 glassScale = water.localScale;

            if (glassScale.y > 0.05f && Vector3.Distance(transform.position, potTransform.position) < pourDistance)
            {
                glassScale.y -= pourSpeed * Time.deltaTime;
                water.localScale = glassScale;

                Vector3 waterPos = water.localPosition;
                waterPos.y -= (pourSpeed * Time.deltaTime) / 2;
                water.localPosition = waterPos;

                Vector3 potScale = potWater.localScale;
                Vector3 potPos = potWater.localPosition;

                if (potScale.y < maxPotWaterYScale)
                {
                    potScale.y += pourSpeed * Time.deltaTime;
                    potPos.y += (pourSpeed * Time.deltaTime) / 2;

                    potWater.localScale = potScale;
                    potWater.localPosition = potPos;
                }
            }
        }
    }
}

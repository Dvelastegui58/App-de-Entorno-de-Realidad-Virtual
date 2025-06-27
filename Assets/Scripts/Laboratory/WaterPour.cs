using UnityEngine;

public class WaterPour : MonoBehaviour
{
    public Transform water;               // Agua del vaso
    public Transform potWater;            // Agua de la olla
    public float pourAngle = 30f;         // Ángulo mínimo para verter
    public float pourSpeed = 0.2f;        // Velocidad de vertido
    public float rotationSpeed = 50f;     // Velocidad de rotación con teclas
    public float zoomSpeed = 2f;          // Velocidad de acercamiento con scroll
    public float maxPotWaterYScale = 0.5f;// Escala máxima de agua en la olla

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
        // 🎯 Detectar clic sobre el vaso para empezar a arrastrar
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

        // 🛑 Soltar al dejar de presionar click
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            IsDraggingGlassCup = false;
        }

        if (isDragging)
        {
            // 🖱️ Mover el vaso con el mouse
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePosition);
            transform.position = new Vector3(worldPos.x, worldPos.y, transform.position.z);

            // 🔁 Rotar con teclas A y D
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
            }

            // 🔍 Zoom con scroll
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (Mathf.Abs(scroll) > 0.01f)
            {
                transform.position += new Vector3(0, 0, scroll * zoomSpeed);
            }
        }

        // 💧 Verter agua si está inclinado y cerca de la olla
        float inclinationZ = Mathf.Abs(transform.localEulerAngles.z);
        if (inclinationZ > 180f) inclinationZ = 360f - inclinationZ;

        if (inclinationZ > pourAngle)
        {
            Vector3 glassScale = water.localScale;

            // Verificamos si aún queda agua y si está lo suficientemente cerca
            if (glassScale.y > 0.05f && Mathf.Abs(transform.position.z - (-6f)) < 1f)
            {
                // ⬇️ Reducir agua en el vaso
                glassScale.y -= pourSpeed * Time.deltaTime;
                water.localScale = glassScale;

                Vector3 waterPos = water.localPosition;
                waterPos.y -= (pourSpeed * Time.deltaTime) / 2;
                water.localPosition = waterPos;

                // ⬆️ Aumentar agua en la olla
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

using UnityEngine;

public class FlaskMouseController : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    public float liftHeight = 1.5f;
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rotar con teclas A / D
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        Vector3 targetPos = GetMouseWorldPos() + offset;
        // Levantamos el vaso automáticamente para que no colisione con el suelo
        targetPos.y = liftHeight;
        transform.position = targetPos;
    }

    private Vector3 GetMouseWorldPos()
    {
        // Convertimos posición del mouse a coordenadas del mundo
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}

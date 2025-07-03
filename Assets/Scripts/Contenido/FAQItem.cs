using UnityEngine;

public class FAQItem : MonoBehaviour
{
    public GameObject respuesta;

    public void ToggleRespuesta()
    {
        respuesta.SetActive(!respuesta.activeSelf);
    }
}

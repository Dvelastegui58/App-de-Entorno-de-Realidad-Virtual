using UnityEngine;

public class EstufaController : MonoBehaviour
{
    public ParticleSystem fuego;
    private bool encendida = false;

    public bool EstaEncendida => encendida;  // ← Propiedad pública de solo lectura

    public void EncenderEstufa()
    {
        if (!encendida)
        {
            fuego.Play();
            encendida = true;
        }
        else
        {
            fuego.Stop();
            encendida = false;
        }
    }
}

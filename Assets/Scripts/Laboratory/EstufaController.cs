using UnityEngine;

public class EstufaController : MonoBehaviour
{
    public ParticleSystem fuego;

    private bool encendida = false;

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

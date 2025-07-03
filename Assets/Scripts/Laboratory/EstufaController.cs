using UnityEngine;

public class EstufaController : MonoBehaviour
{
    public ParticleSystem fuego;
    public static bool EstaEncendida = false;

    public void EncenderEstufa()
    {
        if (!EstaEncendida)
        {
            fuego.Play();
            EstaEncendida = true;
        }
        else
        {
            fuego.Stop();
            EstaEncendida = false;
        }
    }
}

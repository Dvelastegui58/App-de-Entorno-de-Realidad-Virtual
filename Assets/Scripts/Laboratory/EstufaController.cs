using UnityEngine;

public class EstufaController : MonoBehaviour
{
    public ParticleSystem fuego;

    public static bool EstaEncendida { get; private set; } = false;

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

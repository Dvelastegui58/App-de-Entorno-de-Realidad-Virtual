using UnityEngine;

public class EstufaController : MonoBehaviour
{
    public ParticleSystem fuego;
<<<<<<< HEAD

    public static bool EstaEncendida { get; private set; } = false;

    public void EncenderEstufa()
    {
        if (!EstaEncendida)
        {
            fuego.Play();
            EstaEncendida = true;
=======
    private bool encendida = false;

    public bool EstaEncendida => encendida;  // ← Propiedad pública de solo lectura

    public void EncenderEstufa()
    {
        if (!encendida)
        {
            fuego.Play();
            encendida = true;
>>>>>>> 39379a79ab95a8f032dedfeb8be0bdffc7eac9f6
        }
        else
        {
            fuego.Stop();
<<<<<<< HEAD
            EstaEncendida = false;
=======
            encendida = false;
>>>>>>> 39379a79ab95a8f032dedfeb8be0bdffc7eac9f6
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlPanel : MonoBehaviour
{
    [Header("UI")]
    public Slider temperatureSlider;
    public TextMeshProUGUI temperatureLabel;
    public Slider pressureSlider;
    public TextMeshProUGUI pressureLabel;
    public TextMeshProUGUI estadoAguaText;

    [Header("Objetos")]
    public GameObject steamEffect;
    public ParticleSystem burbujeoEffect;
    public Transform potWater;

    [Header("Evaporación")]
    public float evaporationRate = 0.01f;
    public float evaporationThreshold = 0.05f;

    [Header("Condiciones de Ebullición")]
    public float tiempoParaVapor = 2f;
<<<<<<< HEAD
    public float minPressureToBoil = 1.0f;
=======
    public float minPressureToBoil = 1.0f; // Presión mínima para hervir
>>>>>>> 39379a79ab95a8f032dedfeb8be0bdffc7eac9f6

    private bool huboAgua = false;
    private bool burbujeando = false;
    private float tiempoEbullicion = 0f;

    void Update()
    {
        float temperature = temperatureSlider.value;
        float pressure = pressureSlider.value;
        float waterLevel = potWater.localScale.y;

<<<<<<< HEAD
        temperatureLabel.text = "Temperatura: " + temperature.ToString("0") + " °C";
        pressureLabel.text = "Presión: " + pressure.ToString("0.00") + " atm";

        bool estufaEncendida = EstufaController.EstaEncendida;

        // Verifica si alguna vez hubo agua
=======
        // Mostrar en UI
        temperatureLabel.text = "Temperatura: " + temperature.ToString("0") + " °C";
        pressureLabel.text = "Presión: " + pressure.ToString("0.00") + " atm";

>>>>>>> 39379a79ab95a8f032dedfeb8be0bdffc7eac9f6
        if (waterLevel > evaporationThreshold)
        {
            huboAgua = true;
        }

<<<<<<< HEAD
        // Agua completamente evaporada o no hay
=======
>>>>>>> 39379a79ab95a8f032dedfeb8be0bdffc7eac9f6
        if (waterLevel <= evaporationThreshold)
        {
            if (huboAgua)
                estadoAguaText.text = "El agua se ha evaporado";
            else
<<<<<<< HEAD
                estadoAguaText.text = "No hay agua en el recipiente";
=======
                estadoAguaText.text = "No hay agua en el recipiente ";
>>>>>>> 39379a79ab95a8f032dedfeb8be0bdffc7eac9f6

            if (steamEffect.activeInHierarchy)
                steamEffect.SetActive(false);

            if (burbujeoEffect.isPlaying)
            {
                burbujeoEffect.Stop();
                burbujeando = false;
            }

            tiempoEbullicion = 0f;
<<<<<<< HEAD
            return;
        }

        // Hay agua en el recipiente y estufa encendida
        if (estufaEncendida && waterLevel > evaporationThreshold)
        {
            // Mensajes según temperatura
            if (Mathf.Abs(temperature - 100f) < 0.5f)

            {
                estadoAguaText.text = "Punto de ebullición";
            }
            else if (temperature > 100f && pressure >= minPressureToBoil)
            {
                estadoAguaText.text = "Cambio de estado: gaseoso";
            }
            else
            {
                estadoAguaText.text = "Estado líquido";
            }

            // Activar burbujeo si no está activo
            if (!burbujeando && temperature >= 100f)
=======
        }
        else if (temperature >= 100f && pressure >= minPressureToBoil)
        {
            estadoAguaText.text = "Punto de ebullición";

            if (!burbujeando)
>>>>>>> 39379a79ab95a8f032dedfeb8be0bdffc7eac9f6
            {
                burbujeoEffect.Play();
                burbujeando = true;
            }

<<<<<<< HEAD
            // Ajustar intensidad del burbujeo
            var main = burbujeoEffect.main;
            float tempFactor = Mathf.Clamp01((temperature - 100f) / 50f);
            main.startSpeed = Mathf.Lerp(0.1f, 1.5f, tempFactor);
            main.startSize = Mathf.Lerp(0.05f, 0.15f, tempFactor);

            // Control del vapor
            if (temperature >= 100f && pressure >= minPressureToBoil)
            {
                tiempoEbullicion += Time.deltaTime;
                if (tiempoEbullicion >= tiempoParaVapor)
                {
                    if (!steamEffect.activeInHierarchy)
                        steamEffect.SetActive(true);
                }
                else
                {
                    if (steamEffect.activeInHierarchy)
                        steamEffect.SetActive(false);
                }

                // Evaporar agua
                Vector3 scale = potWater.localScale;
                Vector3 pos = potWater.localPosition;

                if (scale.y > evaporationThreshold)
                {
                    scale.y -= evaporationRate * Time.deltaTime;
                    pos.y -= (evaporationRate * Time.deltaTime) / 2;

                    potWater.localScale = scale;
                    potWater.localPosition = pos;
                }
            }
            else
            {
                tiempoEbullicion = 0f;
                if (steamEffect.activeInHierarchy)
                    steamEffect.SetActive(false);
            }
        }
        else
        {
            estadoAguaText.text = "Estado líquido";
=======
            tiempoEbullicion += Time.deltaTime;

            if (tiempoEbullicion >= tiempoParaVapor)
            {
                if (!steamEffect.activeInHierarchy)
                    steamEffect.SetActive(true);
            }
            else
            {
                if (steamEffect.activeInHierarchy)
                    steamEffect.SetActive(false);
            }

            // Evaporación
            Vector3 scale = potWater.localScale;
            Vector3 pos = potWater.localPosition;

            if (scale.y > evaporationThreshold)
            {
                scale.y -= evaporationRate * Time.deltaTime;
                pos.y -= (evaporationRate * Time.deltaTime) / 2;

                potWater.localScale = scale;
                potWater.localPosition = pos;
            }
        }
        else
        {
            estadoAguaText.text = "Agua en reposo";
>>>>>>> 39379a79ab95a8f032dedfeb8be0bdffc7eac9f6

            if (steamEffect.activeInHierarchy)
                steamEffect.SetActive(false);

            if (burbujeoEffect.isPlaying)
            {
                burbujeoEffect.Stop();
                burbujeando = false;
            }

            tiempoEbullicion = 0f;
        }
    }
}

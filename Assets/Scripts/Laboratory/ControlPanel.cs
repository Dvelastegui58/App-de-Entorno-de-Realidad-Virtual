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
    public float minPressureToBoil = 1.0f;

    private bool huboAgua = false;
    private bool burbujeando = false;
    private float tiempoEbullicion = 0f;

    void Update()
    {
        float temperature = temperatureSlider.value;
        float pressure = pressureSlider.value;
        float waterLevel = potWater.localScale.y;

        temperatureLabel.text = "Temperatura: " + temperature.ToString("0") + " °C";
        pressureLabel.text = "Presión: " + pressure.ToString("0.00") + " atm";

        bool estufaEncendida = EstufaController.EstaEncendida;

        // Verifica si alguna vez hubo agua
        if (waterLevel > evaporationThreshold)
        {
            huboAgua = true;
        }

        // Agua completamente evaporada o no hay
        if (waterLevel <= evaporationThreshold)
        {
            if (huboAgua)
                estadoAguaText.text = "El agua se ha evaporado";
            else
                estadoAguaText.text = "No hay agua en el recipiente";

            if (steamEffect.activeInHierarchy)
                steamEffect.SetActive(false);

            if (burbujeoEffect.isPlaying)
            {
                burbujeoEffect.Stop();
                burbujeando = false;
            }

            tiempoEbullicion = 0f;
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
            {
                burbujeoEffect.Play();
                burbujeando = true;
            }

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

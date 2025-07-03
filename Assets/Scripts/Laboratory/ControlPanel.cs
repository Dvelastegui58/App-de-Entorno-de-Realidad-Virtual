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
    public float minPressureToBoil = 1.0f; // Presión mínima para hervir

    private bool huboAgua = false;
    private bool burbujeando = false;
    private float tiempoEbullicion = 0f;

    void Update()
    {
        float temperature = temperatureSlider.value;
        float pressure = pressureSlider.value;
        float waterLevel = potWater.localScale.y;

        // Mostrar en UI
        temperatureLabel.text = "Temperatura: " + temperature.ToString("0") + " °C";
        pressureLabel.text = "Presión: " + pressure.ToString("0.00") + " atm";

        if (waterLevel > evaporationThreshold)
        {
            huboAgua = true;
        }

        if (waterLevel <= evaporationThreshold)
        {
            if (huboAgua)
                estadoAguaText.text = "El agua se ha evaporado";
            else
                estadoAguaText.text = "No hay agua en el recipiente ";

            if (steamEffect.activeInHierarchy)
                steamEffect.SetActive(false);

            if (burbujeoEffect.isPlaying)
            {
                burbujeoEffect.Stop();
                burbujeando = false;
            }

            tiempoEbullicion = 0f;
        }
        else if (temperature >= 100f && pressure >= minPressureToBoil)
        {
            estadoAguaText.text = "Punto de ebullición";

            if (!burbujeando)
            {
                burbujeoEffect.Play();
                burbujeando = true;
            }

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

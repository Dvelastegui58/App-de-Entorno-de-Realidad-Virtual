using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlPanel : MonoBehaviour
{
    public Slider temperatureSlider;
    public TextMeshProUGUI temperatureLabel;
    public GameObject steamEffect;

void Update()
{
    float temperature = temperatureSlider.value;
    temperatureLabel.text = "Temperatura: " + temperature.ToString("0") + " °C";

    // Activar o desactivar el vapor según la temperatura
    if (temperature > 60f)
    {
        if (!steamEffect.activeInHierarchy)
            steamEffect.SetActive(true);
    }
    else
    {
        if (steamEffect.activeInHierarchy)
            steamEffect.SetActive(false);
    }
}

}

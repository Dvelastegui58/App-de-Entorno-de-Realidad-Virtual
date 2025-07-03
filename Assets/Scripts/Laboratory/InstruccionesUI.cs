using UnityEngine;

public class InstruccionesUI : MonoBehaviour
{
    public GameObject panelInstrucciones;

    private bool visible = false;

    public void ToggleInstrucciones()
    {
        visible = !visible;
        panelInstrucciones.SetActive(visible);
    }
}

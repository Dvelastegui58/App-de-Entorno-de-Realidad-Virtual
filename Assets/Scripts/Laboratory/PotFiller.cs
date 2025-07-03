using UnityEngine;

public class PotFiller : MonoBehaviour
{
    public GameObject waterInPot;

    public void FillPot()
    {
        waterInPot.SetActive(true); // Activa el agua cuando se llama este método
    }
}

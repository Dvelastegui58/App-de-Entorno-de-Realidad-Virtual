using UnityEngine;

public class WaterHeating : MonoBehaviour
{
    public GameObject water;
    public ParticleSystem steamParticles;
    public float heatingSpeed = 0.01f;
    public float minWaterHeight = 0.1f;

    private bool isHeating = false;

    void Start()
    {
        steamParticles.Stop();
    }

    void Update()
    {
        if (isHeating)
        {
            float currentHeight = water.transform.localScale.y;
            if (currentHeight > minWaterHeight)
            {
                water.transform.localScale -= new Vector3(0, heatingSpeed * Time.deltaTime, 0);
                water.transform.position -= new Vector3(0, (heatingSpeed * Time.deltaTime / 2), 0);
            }
            else
            {
                steamParticles.Stop();
            }
        }
    }

    public void StartHeating()
    {
        isHeating = true;
        steamParticles.Play();
    }
}

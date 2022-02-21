using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLight : MonoBehaviour
{
    public Light LightSource;
    public float lightIntensity;
    public float minIntensity = 0.35f, maxIntensity = 2f;
    public void Update()
    {
        minIntensity = 1f * Time.deltaTime;
        maxIntensity = 2f * Time.deltaTime;
    }
    public void HoverLight()
    {
        lightIntensity = maxIntensity;
        LightSource.intensity = lightIntensity;
    }
    public void OrdinaryLight()
    {
        lightIntensity = minIntensity;
        LightSource.intensity = lightIntensity;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{

    [SerializeField] float lightDecay = 0.5f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minnimumAngle = 10f;

    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }

    void Update()
    {
        DecreaseAngle();
        DecreaseIntensity();
    }

    private void DecreaseAngle()
    {
        if(myLight.spotAngle <= minnimumAngle){return;}
        myLight.spotAngle -= angleDecay * Time.deltaTime;
    }
    private void DecreaseIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    public void RestoreAngle(float angle)
    {
        myLight.spotAngle = angle;
    }

    public void RestoreIntensity(float intensity)
    {
        myLight.intensity = intensity;
    }
}

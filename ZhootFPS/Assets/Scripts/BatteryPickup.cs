using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float angleRestored = 30f;
    [SerializeField] float intensityRestored = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreAngle(angleRestored);
            other.GetComponentInChildren<FlashLightSystem>().RestoreIntensity(intensityRestored);
            Destroy(gameObject);
        }
    }
}

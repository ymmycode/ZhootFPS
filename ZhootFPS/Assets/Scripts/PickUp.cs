using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    [SerializeField] int ammoAmount = 10;
    [SerializeField] AmmoType ammoType;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<Ammo>().IncreaseAmmoAmount(ammoType, ammoAmount);
            Destroy(gameObject);
        }
    }
}

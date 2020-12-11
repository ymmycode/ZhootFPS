using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] int keyAmount = 1;
    [SerializeField] KeyType keyType;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<Key>().IncreaseKeyAmount(keyType, keyAmount);
            FindObjectOfType<Key>().ShowKeyImage(keyType);
            Destroy(gameObject);
        }
    }
}

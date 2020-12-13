using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] int keyAmount = 1;
    [SerializeField] KeyType keyType;
    [SerializeField] GameObject pickupMessage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<Key>().IncreaseKeyAmount(keyType, keyAmount);
            FindObjectOfType<Key>().ShowKeyImage(keyType);
            GetComponentInChildren<MeshRenderer>().enabled = false;
            GetComponentInChildren<Light>().enabled = false;
            StartCoroutine(ShowMessage());
        }
    }

    IEnumerator ShowMessage()
    {
        if(pickupMessage == null){}
        pickupMessage.SetActive(true);
        yield return new WaitForSeconds(2f);
        pickupMessage.SetActive(false);
        Destroy(gameObject);
    }
}

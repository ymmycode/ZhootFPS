using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    [SerializeField] KeyType keyType;
    [SerializeField] Key key;
    bool isNearDoor = false;
    int keyCost = 1;
    int keyInventory;
    private void Update()
    {
        if(isNearDoor == true)
        {
            UnlockTheDoor();
        }
    }

    private void UnlockTheDoor()
    {
        if(Input.GetKey(KeyCode.F))
        {
            keyInventory = key.GetCurrentKeyAmount(keyType);
            if(keyInventory != 0)
            {
                key.ReduceKeyAmount(keyType, keyCost);
                GetComponentInParent<Animator>().SetBool("isOpening", true);
                Invoke("SelfDestruct",1.2f);
            }
            else
            {
                Debug.LogWarning("Locked, Need a Safe House Key");
            }
        }
    }

    private void SelfDestruct()
    {
        GetComponent<BoxCollider>().enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player")) isNearDoor = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")) isNearDoor = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    [SerializeField] KeyType keyType;
    [SerializeField] Key key;
    [SerializeField] GameObject doorUnlockMessage;
    [SerializeField] GameObject doorLockMessage;
    [SerializeField] GameObject openDoorMessage;
    [SerializeField] GameObject needKeyMessage;

    bool isNearDoor = false;
    bool isHaveKey = false;
    int keyCost = 1;
    [SerializeField]int keyInventory;
    private void Update()
    {
        keyInventory = key.GetCurrentKeyAmount(keyType);

        if(keyInventory != 0){isHaveKey = true;}
        else{isHaveKey = false;}

        if(isNearDoor == true)
        {
            UnlockTheDoor();
        }
    }

    private void UnlockTheDoor()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(keyInventory != 0)
            {
                GetComponent<BoxCollider>().enabled = false;
                key.ReduceKeyAmount(keyType, keyCost);
                StartCoroutine(ShowUnlockedMessage());
                GetComponentInParent<Animator>().SetBool("isOpening", true);
            }
            else
            {
                StartCoroutine(ShowLockedMessage());
            }
        }
    }

    IEnumerator ShowUnlockedMessage()
    {
        if(doorUnlockMessage == null) {}
        doorUnlockMessage.SetActive(true);
        openDoorMessage.SetActive(false);
        doorLockMessage.SetActive(false);
        needKeyMessage.SetActive(false);
        yield return new WaitForSeconds(2f);
        doorUnlockMessage.SetActive(false);
    }

    IEnumerator ShowLockedMessage()
    {
        if(doorLockMessage == null){}
        doorLockMessage.SetActive(true);
        needKeyMessage.SetActive(false);
        yield return new WaitForSeconds(2f);
        doorLockMessage.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) isNearDoor = true;
        if(isHaveKey == true)
        {
            openDoorMessage.SetActive(true);
        }
        else if(isHaveKey == false)
        {
            needKeyMessage.SetActive(true);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")) isNearDoor = false;
        openDoorMessage.SetActive(false);
        needKeyMessage.SetActive(false);
    }
}
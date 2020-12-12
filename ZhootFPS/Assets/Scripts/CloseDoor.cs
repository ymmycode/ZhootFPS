using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Invoke("CloseTheDoor",2f);
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void CloseTheDoor()
    {
        //Show Win UI
        GetComponentInParent<Animator>().SetBool("isOpening", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Invoke("CloseTheDoor",1f);
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void CloseTheDoor()
    {
        GetComponentInParent<Animator>().SetBool("isOpening", false);
        StartCoroutine(ShowWinPanel());
    }

    IEnumerator ShowWinPanel()
    {
        yield return new WaitForSeconds(1f);
        winPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
    }
}

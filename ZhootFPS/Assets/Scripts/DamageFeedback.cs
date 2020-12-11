using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageFeedback : MonoBehaviour
{
    [SerializeField] GameObject bloodHit;
    [SerializeField] float decayTime = 0.5f;

    private void Start()
    {
        bloodHit.SetActive(false);
    }

    public void ShowBloodHit()
    {
        StartCoroutine(BloodHit());
    }
    IEnumerator BloodHit()
    {
        bloodHit.SetActive(true);
        yield return new WaitForSeconds(decayTime);
        bloodHit.SetActive(false);
    }
}

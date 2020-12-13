using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePanel : MonoBehaviour
{
    [SerializeField] GameObject objectivePanel;

    void Start()
    {
        StartCoroutine(ShowObjectivePanel());
    }

    IEnumerator ShowObjectivePanel()
    {
        objectivePanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        objectivePanel.SetActive(false);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            objectivePanel.SetActive(true);
        }

        if(Input.GetKeyUp(KeyCode.Tab))
        {
            objectivePanel.SetActive(false);
        }
    }
}

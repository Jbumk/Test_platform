using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnTrigger : MonoBehaviour
{
    public GameObject[] TargetObj;
    public bool DoOff = false;
    private void OnTriggerEnter(Collider col)
    {
        if (!DoOff)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                for (int i = 0; i < TargetObj.Length; i++)
                {
                    TargetObj[i].SetActive(true);
                }
            }
        }
        else
        {
        if (col.gameObject.CompareTag("Player"))
            {   
                for (int i = 0; i < TargetObj.Length; i++)
                {
                    TargetObj[i].SetActive(false);
                }
            }
        }

    }
}

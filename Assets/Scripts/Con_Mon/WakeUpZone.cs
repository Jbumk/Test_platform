using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Crab_Act.instance.WakeUp();
        }
    }
}

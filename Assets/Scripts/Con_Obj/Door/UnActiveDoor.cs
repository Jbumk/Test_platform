using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnActiveDoor : MonoBehaviour
{
    public GameObject Door;
    public GameObject BackLight;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Door.gameObject.SetActive(false);
            if (BackLight != null)
            {
                BackLight.gameObject.SetActive(true);
            }
        }
    }

}

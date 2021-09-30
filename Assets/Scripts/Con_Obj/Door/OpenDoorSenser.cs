using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorSenser : MonoBehaviour
{
    public GameObject DoorHinge;
    OpenDoor DoorValue;

    private void Start()
    {
        DoorValue = DoorHinge.gameObject.GetComponent<OpenDoor>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            DoorValue.enabled = true;
        }      
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            OpenDoor.isDoing = false;
            DoorValue.enabled = false;
            
        }
    }

}

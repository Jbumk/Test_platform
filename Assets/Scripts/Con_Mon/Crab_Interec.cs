using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_Interec : MonoBehaviour
{
    private OpenDoor Door;
    
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Crab_Act.instance.Do_Att();
        }

        /*
        if (col.gameObject.CompareTag("Hinge"))
        {
            Door = col.GetComponent<OpenDoor>();
            if (!Door.OpenChk())
            {
                Door.Doing();
            }
            
        }
        */
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Hinge"))
        {
            Door = col.GetComponent<OpenDoor>();
            if (!Door.OpenChk())
            {
                Door.Doing(1);
            }

        }
    }

 

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Crab_Act.instance.Cancle_Att();
        }
     
    }
}

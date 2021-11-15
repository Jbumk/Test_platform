using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_Interec : MonoBehaviour
{
    private OpenDoor Door;
    private Hid_Locker Locker;
    
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
        //Open Door 앞에 있을때 문 연다
        if (col.gameObject.CompareTag("Hinge"))
        {
            Door = col.GetComponent<OpenDoor>();
            if (!Door.OpenChk())
            {
                Door.Doing(1);
            }

        }


        if (col.gameObject.CompareTag("HideLocker"))
        {
            if (Crab_Act.instance.See_Player)
            {
                Locker = col.gameObject.GetComponent<Hid_Locker>();
                Locker.Find();
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

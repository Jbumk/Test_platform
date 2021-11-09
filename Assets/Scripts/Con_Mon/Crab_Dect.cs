using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_Dect : MonoBehaviour
{
 


   
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
          //  Dect_Player = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //Dect_Player = false;
        }
    }
}

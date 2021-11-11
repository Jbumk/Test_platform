using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_Dect : MonoBehaviour
{

    public AudioSource BGM;
    private bool isBGMON = false;


    private void Update()
    {
        if(!isBGMON && BGM.volume!=0)
        {
            BGM.volume -= 0.001f;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player")&& !isBGMON)
        {
            BGM.volume = 0.5f;
            isBGMON = true;
            BGM.Play();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && isBGMON)
        {
            isBGMON = false;
           
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectForward : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.CompareTag("Ground"))
        {
            Chara_Main_Move.ForwardBlock = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Chara_Main_Move.ForwardBlock = false;
        }
    }


}

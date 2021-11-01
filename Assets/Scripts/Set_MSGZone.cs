using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_MSGZone : MonoBehaviour
{
    public int MSG_Code=0;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            MSG_Manager.instance.Ins_Code(MSG_Code);
            gameObject.SetActive(false);
        }
    }
}

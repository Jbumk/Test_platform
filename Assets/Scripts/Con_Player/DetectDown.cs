using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDown : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Ground"))
        {
            Chara_Main_Move.isJump = false;
            Chara_Main_Move.OnGround = true;
            Chara_Main_Move.fall_timer = 0f;
        }
       
    }
    private void OnTriggerStay(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Ground"))
        {
            Chara_Main_Move.isJump = false;
            Chara_Main_Move.OnGround = true;
            Chara_Main_Move.fall_timer = 0f;
        }     
    }
    private void OnTriggerExit(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Ground"))
        {
            Chara_Main_Move.isJump = true;           
        }
    }
}

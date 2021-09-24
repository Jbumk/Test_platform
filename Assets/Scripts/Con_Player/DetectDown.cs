using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDown : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Chara_Main_Move.isJump = false;
            Chara_Main_Move.OnGround = true;
            Chara_Main_Move.fall_timer = 0f;
        }
       
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Chara_Main_Move.isJump = false;
            Chara_Main_Move.OnGround = true;
            Chara_Main_Move.fall_timer = 0f;
        }       
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Chara_Main_Move.isJump = true;           
        }
    }
}

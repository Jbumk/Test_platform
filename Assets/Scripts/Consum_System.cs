using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Consum_System : MonoBehaviour
{
    float timer;
    double wait;
    double dot_wait;
    public float maxPosition; //최대 높이값
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        wait = 0.3; //1차피격후 무적시간 설정
        dot_wait = 0.35; //도트딜 주기
    }
    void Update()
    {
        timer += Time.deltaTime;

        Chara_Main_Move.fall();
    }


    
    // 닿았을때 한번 
    private void OnCollisionEnter(Collision collision)
    {
        //본체와 피격딜
        if (collision.gameObject.CompareTag("Monster") )
        {
            if (timer >= wait)
            {
                UI_Manager.instance.alterHP(10);
                timer = 0;
                
            }
        }

        //이하 패턴관련 피격 딜
        if (collision.gameObject.CompareTag("Pattern"))
        {
            if (timer >= wait)
            {
                UI_Manager.instance.alterHP(10);
                timer = 0;

            }
        }
    }

    //도트딜은 물리적 충돌 필요없어보여 일단 제거
    /* 
    private void OnCollisionStay(Collision collision)
    {
        //피격 지속딜
        if (collision.gameObject.CompareTag("Monster"))
        {
            if (timer >= wait)
            {
                Con_HP(1);
                timer = 0;

            }
        }
        
        //이하 패턴관련 지속딜
        if (collision.gameObject.CompareTag("Pattern"))
        {

        }
    }*/

    //도트딜 관련 물리처리 X
    private void OnTriggerStay(Collider c)
    {
        if (c.gameObject.CompareTag("Pattern")) { 

            if (dot_wait <= timer)
            {
                if (c.gameObject.name == "Pattern_1")
                {
                    UI_Manager.instance.alterHP(4);
                    timer = 0;
                }
            }

        }
    }

  
}

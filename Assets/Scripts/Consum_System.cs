using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Consum_System : MonoBehaviour
{
    private float timer;
    private double wait;
    private double dot_wait;
    private float ExploTimer;
    private double Explo_wait; //폭발 무적시간

    private Rigidbody rigid;
    private Vector3 ExploVec;
    private Vector3 PlayerVec;
    private Vector3 ForceVec;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        wait = 0.3; //1차피격후 무적시간 설정
        dot_wait = 0.35; //도트딜 주기
        ExploTimer = 0;
        Explo_wait = 0.8; //폭발 무적 주기

        rigid = this.GetComponent<Rigidbody>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        ExploTimer += Time.deltaTime;
       
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

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Explosion"))
        {
            if (ExploTimer >= Explo_wait)
            {
                UI_Manager.instance.alterHP(30);
                ExploTimer = 0;
                /*
                ExploVec = col.transform.position;
                PlayerVec = transform.position;
                ForceVec = (PlayerVec - ExploVec).normalized;

                rigid.AddForce(ForceVec * 10f, ForceMode.Impulse);
                */
                rigid.AddExplosionForce(600f, col.transform.position, 2.9f,3f);
            }
        }
    }



    //도트딜 관련 물리처리 X 
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Pattern")) { 

            if (dot_wait <= timer)
            {
                if (col.gameObject.name == "Pattern_1")
                {
                    UI_Manager.instance.alterHP(4);
                    timer = 0;
                }
            }

        }

        if (col.gameObject.CompareTag("Lava"))
        {
            if (dot_wait <= timer)
            {
                UI_Manager.instance.alterHP(20);
                timer = 0;

            }
        }


    }

  
}

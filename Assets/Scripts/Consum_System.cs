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
    private Vector3 PatternVec;
    private Vector3 PlayerVec;
    private Vector3 ForceVec;
    

    public static float max_Pos;
    private float fall_timer;
    private double fall_die = 5;
    
   
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

        fall();
       
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
                if (collision.gameObject.name =="Hammer")
                {
                    Debug.Log(collision.transform.position+ " / " + transform.position);
                    PlayerVec = transform.position;
                    PatternVec = collision.transform.position;
                    PlayerVec.y = 0;
                    PatternVec.y = 0;
                    rigid.AddForce((PlayerVec - PatternVec).normalized * 10f, ForceMode.Impulse);
                } 
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
                PatternVec = col.transform.position;
                PlayerVec = transform.position;
                ForceVec = (PlayerVec - PatternVec).normalized;

                rigid.AddForce(ForceVec * 10f, ForceMode.Impulse);                
               
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


    private void fall()
    {

        if (rigid.velocity.y < -40)
        {
            if (!UI_Manager.instance.getDead())
            {
                UI_Manager.instance.alterHP(UI_Manager.instance.getMaxHP());
                max_Pos = 0;
                fall_timer = 0;
            }
        }

        if (Chara_Main_Move.isJump)
        {
            if (rigid.velocity.y < 0 && max_Pos < rigid.transform.position.y)
            {
                max_Pos = rigid.transform.position.y;
            }
            if (rigid.velocity.y < 0)
            {
                fall_timer += Time.deltaTime;
            }
            if (fall_timer >= fall_die)
            {
                UI_Manager.instance.alterHP(UI_Manager.instance.getMaxHP());
                fall_timer = 0;
                max_Pos = 0;
            }
        }
        else
        {
            if (max_Pos - rigid.transform.position.y > 5)
            {
                //임시 계산식 추후 개선필요 가능성 있음
                double dmg;
                dmg = 1.4 * Mathf.Log(max_Pos - rigid.transform.position.y, 2);
                dmg = UI_Manager.instance.getMaxHP() / 100 * (dmg * 10);
                UI_Manager.instance.alterHP((int)dmg);

                dmg = 0;
                max_Pos = 0;
                fall_timer = 0;
            }
            else
            {
                max_Pos = rigid.transform.position.y;
                fall_timer = 0;
            }
        }
    }

}

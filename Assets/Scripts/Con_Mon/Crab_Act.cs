using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Crab_Act : MonoBehaviour
{
    public static Crab_Act instance
    {
        get
        {
            if (m_inst == null)
            {
                m_inst = FindObjectOfType<Crab_Act>();
            }
            return m_inst;
        }
    }

    private static Crab_Act m_inst;

    public GameObject[] DestPos;
    public int DestNum = 0;

    public Animator animator;
    public GameObject Player;
    private Rigidbody rigid;
    private NavMeshAgent nav;

    private Vector3 ResetPos;

    private float Timer = 0;
    private double CoolTime = 1.0;
    private float Att_Timer = 0;
    private double Att_CoolTime = 3.0;

    //감지 조건들
    public bool See_Player = false;
    public bool Hear= false;
    private bool In_AttRange = false;
    public bool Sleep = true;

    private Vector3 Hear_Position;// 들은곳의 위치

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        ResetPos = transform.position;
    }

    
    void Update()
    {
        Timer += Time.deltaTime;
        Att_Timer += Time.deltaTime;

        /*
        if (ResetManager.ObjReset)
        {
          
            Hear = false;
            See_Player = false;
            nav.SetDestination(DestPos[DestNum].transform.position);
        }*/

        

        //깨어있을때의 행동
        if (!Sleep)
        {

            //움직이는 애니메이션 담당
            if (Timer >= CoolTime && !In_AttRange)
            {
                if (nav.velocity != Vector3.zero)
                {

                    animator.SetTrigger("Walk_Cycle_1");
                }
                else
                {
                    animator.SetTrigger("Rest_1");
                }
                Timer = 0;
            }

            //추적, 수색 부분
            if (See_Player)
            {
                nav.speed = 5.5f;
                nav.SetDestination(Player.transform.position);
            }
            else if (Hear)
            {
                nav.speed = 5.5f;
                nav.SetDestination(Hear_Position);

                if (2 >= Vector3.Distance(transform.position, Hear_Position))
                {
                    Hear = false;
                }
            }
            else if (!See_Player && !Hear)
            {
                nav.speed = 2.5f;
                if (2 >= Vector3.Distance(transform.position, DestPos[DestNum].transform.position))
                {
                    DestNum = Random.Range(0, DestPos.Length);
                }
                else
                {
                    nav.SetDestination(DestPos[DestNum].transform.position);
                }

            }



            //공격하는 부분
            //숨어있을땐 공격X
            if (!Chara_Main_Move.isHide)
            {
                if (In_AttRange && Att_Timer >= Att_CoolTime)
                {
                    Att_Timer = 0;
                    nav.velocity = Vector3.zero;
                    animator.SetTrigger("Attack_1");
                }
                else if (In_AttRange && Att_Timer >= 0.5 && Att_Timer < 1)
                {

                    UI_Manager.instance.alterHP(100);
                    In_AttRange = false;
                    Att_Timer = 1f;
                }
                else if (!In_AttRange && Att_Timer < 1)
                {
                    Att_Timer = 1f;
                }
            }
        }
        else
        {
            animator.SetTrigger("Sleep");
        }

       
        //듣는것보다 보는것 더 우선시
        //소리를 들었을때 해당 위치로 이동
    }


    public void SeePlayer()
    {
        See_Player = true;
    }

    public void MissPlayer()
    {
        See_Player = false;
    }

    public void Do_Att()
    {
        In_AttRange = true;
    }
    public void Cancle_Att()
    {
        In_AttRange = false;
    }
    public void WakeUp()
    {
        Sleep = false;
    }

    public void HearSound(int SoundType,Vector3 Pos)
    {
        //SoundType  1 => 작은소리(중간절반) 2=>중간 (Dect Area크기의 거리) 3=> (큰소리 어디든 감지)
        switch (SoundType)
        {
            case 1:
                if (Vector3.Distance(transform.position, Pos) <= 5f)
                {
                    Hear_Position = Pos;
                    Hear = true;
                   
                }
                break;
            case 2:
                Hear_Position = Pos;
                Hear = true;                
                break;
            case 3:
                Hear_Position = Pos;
                Hear = true;               
                break;
        }
    }

}

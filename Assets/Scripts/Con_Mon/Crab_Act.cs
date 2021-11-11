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



    public Animator animator;
    public GameObject Player;
    private Rigidbody rigid;
    private NavMeshAgent nav;

    private float Timer = 0;
    private double CoolTime = 1.0;

    //감지 조건들
    private bool See_Player = false;
    private bool Hear= false;

    private Vector3 Hear_Position;// 들은곳의 위치

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= CoolTime)
        {
            if (nav.velocity!= Vector3.zero)
            {

                animator.SetTrigger("Walk_Cycle_1");
            }
            else
            {
                animator.SetTrigger("Rest_1");
            }
            Timer = 0;
        }



        
        if (See_Player)
        {
            nav.SetDestination(Player.transform.position);
        }
        else if(Hear)
        {
            nav.SetDestination(Hear_Position);
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

    public void HearSound(int SoundType,Vector3 Pos)
    {
        //SoundType  1 => 작은소리(중간절반) 2=>중간 (Dect Area크기의 거리) 3=> (큰소리 어디든 감지)
        switch (SoundType)
        {
            case 1:
                if (Vector3.Distance(transform.position, Pos) <= 15f)
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

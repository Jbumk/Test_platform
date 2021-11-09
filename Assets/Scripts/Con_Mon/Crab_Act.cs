using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Crab_Act : MonoBehaviour
{
    public Animator animator;
    public GameObject Player;
    private Rigidbody rigid;
    private NavMeshAgent nav;

    private float Timer = 0;
    private double CoolTime = 1.0;

    //감지 조건들
    public static bool See_Player = false;
    public static bool Hear= false;

    public static Vector3 Hear_Position;// 들은곳의 위치

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
}

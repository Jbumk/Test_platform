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
            if (Crab_Dect.Dect_Player)
            {

                animator.SetTrigger("Walk_Cycle_1");
            }
            else
            {
                animator.SetTrigger("Rest_1");
            }
            Timer = 0;
        }




        if (Crab_Dect.Dect_Player)
        {
            nav.SetDestination(Player.transform.position);
        }
        else
        {
            nav.SetDestination(transform.position);
        }
    }
}

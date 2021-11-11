using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sound : MonoBehaviour
{
    public AudioSource Jump;
    private float Timer = 0;
    private double CoolTIme = 1.0;
    private bool JumpEnd = true;



    public AudioSource Walk;
    private bool isWalk=false;

    public AudioSource Run;
    private bool isRun=false;



    
    private float horzmove;
    private float vertmove;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        //움직임 사운드
        horzmove = Input.GetAxis("Horizontal");
        vertmove = Input.GetAxisRaw("Vertical");
        if (horzmove == 0 && vertmove == 0)
        {
            Walk.Stop();
            isWalk = false;
            Run.Stop();
            isRun = false;
        }
        else
        {
            if (!Chara_Main_Move.OnDash)
            {
                if (Timer >= CoolTIme)
                {
                    Walk.Play();
                    isWalk = true;
                    Timer = 0;
                }
            }
            else
            {
                if (Timer >= CoolTIme)
                {
                    Run.Play();
                    isRun = true;
                    Timer = 0;
                }
            }

        }


        //점프 사운드
        if (JumpEnd)
        {
            if (Chara_Main_Move.isJump)
            {
                JumpEnd = false;
                Jump.Play();               
            }

        }
        else
        {
            if (!Chara_Main_Move.isJump)
            {
                JumpEnd = true;
            }
        }



    }


    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("CrabDect"))
        {
            if (isWalk)
            {
                Crab_Act.instance.HearSound(1,transform.position);
            }
            else if(isRun)
            {
                Crab_Act.instance.HearSound(2, transform.position);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_Ani : MonoBehaviour
{
    public float horzmove;
    public float vertmove;
    Animator ani;


    public AudioSource WalkSound;
    public AudioSource RunSound;

    float Timer = 0;
    double CoolTime = 1.0;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        horzmove = Input.GetAxis("Horizontal");
        vertmove = Input.GetAxisRaw("Vertical");       
        if (horzmove == 0 && vertmove == 0)
        {
            WalkSound.Stop();
            RunSound.Stop();
            
            ani.SetBool("runTrigger", false);
            ani.SetBool("walkTrigger", false);
            ani.SetBool("bowTrigger", false);
            ani.SetBool("idleTrigger", true);

        }
        else
        {
            if (!Chara_Main_Move.OnDash)
            {
                if (Timer >= CoolTime)
                {
                    WalkSound.Play();
                    Timer = 0;
                }
               
                ani.SetBool("runTrigger", false);
                ani.SetBool("walkTrigger", true);
                ani.SetBool("bowTrigger", false);
                ani.SetBool("idleTrigger", false);
            }
            else
            {
                if (Timer >= CoolTime)
                {
                    RunSound.Play();
                    Timer = 0;
                }
                ani.SetBool("runTrigger", true);
                ani.SetBool("walkTrigger", false);
                ani.SetBool("bowTrigger", false);
                ani.SetBool("idleTrigger", false);
            }

        }
    }
}

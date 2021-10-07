using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara_Attack : MonoBehaviour
{
    public GameObject Player;  
    //static float Con_MPTimer;
    //static double Con_MPMaxTime;
    private bool TimeStop = false;

    private bool CanTimeBack = false;
    Vector3 BackVec;
    public Vector3[] BackPoint = new Vector3[7];
    private int VecStack = 0;

    private void Start()
    {
        StartCoroutine(TimeBack());
    }

   
    void Update()
    {
        

        //좌클릭시 기본공격
        if (Input.GetMouseButtonDown(0) && Interec.GrabObj==null && CanTimeBack)
        {
            /*
             var skill = atkpool.GetObj();
             var pos = Camera.main.transform.position;
             pos += Player.transform.forward * 3;           
             skill.Skill(pos);         
             */
            if (UI_Manager.instance.getNowMP() >= 10)
            {
                Player.transform.position = BackPoint[VecStack];
                UI_Manager.instance.alterMP(10);
            }
        }


        //우클릭시 스킬 사용
       

        if (Input.GetMouseButtonDown(1) && !TimeStop)
        {
            if (UI_Manager.instance.getNowMP() >= 10)
            {
                TimeStop = true;
                Time.timeScale = 0.0f;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                UI_Manager.instance.alterMP(10);             

            }
            
        }
        else if (Input.GetMouseButtonDown(1) && TimeStop)
        {
            TimeStop = false;
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;

        }
    

    }


    
    
    public IEnumerator TimeBack()
    {
        while (true)
        {
            if (VecStack <= 6)
            {
                BackPoint[VecStack] = Player.transform.position;
            }
            else
            {                
                VecStack = 0;
                BackPoint[VecStack] = Player.transform.position;
                CanTimeBack = true;
            }
            VecStack++;
            yield return new WaitForSeconds(0.5f);
        }
    }


}

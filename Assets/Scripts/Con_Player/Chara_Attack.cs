using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara_Attack : MonoBehaviour
{
    public GameObject Player;  
    //static float Con_MPTimer;
    //static double Con_MPMaxTime;
    bool TimeStop = false;

    void Update()
    {        
        //좌클릭시 기본공격
        if (Input.GetMouseButtonDown(0) && Interec.GrabObj==null)
        {
           
            var skill = atkpool.GetObj();
            var pos = Camera.main.transform.position;
            pos += Player.transform.forward * 3;           
            skill.Skill(pos);         
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
    


}

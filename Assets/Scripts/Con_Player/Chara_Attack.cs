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

    //시간되돌리기 관련 함수
    public Vector3[] BackPoint = new Vector3[7];
    public GameObject BackPointPrefab;
    private bool CanTimeBack = false;
    Vector3 BackVec;
    
    private int VecStack = 0;

    private void Start()
    {
        StartCoroutine(TimeBack());
    }

   
    void Update()
    {

        if (!Menu.onMenu)
        {
            //좌클릭시 기본공격
            if (CanTimeBack)
            {
                BackPointPrefab.transform.position = BackPoint[VecStack];
                if (Input.GetMouseButtonDown(0) && Interec.GrabObj == null)
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
    
    public IEnumerator TimeBack()
    {
        while (true)
        {            
            BackPoint[VecStack] = Player.transform.position;        
            VecStack++;
            if (VecStack > 6)
            {
                VecStack = 0;                
                CanTimeBack = true;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Circle")
        {
            for(int i = 0; i < BackPoint.Length; i++)
            {
                BackPoint[i] = col.transform.position;
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_UnstablePlat : MonoBehaviour
{
    Vector3 RanVec = new Vector3(0f,0f,0f);
    Vector3 OriginVec;
    bool doBreak = false; //부서지는 중인지 체크 (발판위에 올라 서있는지)
    bool isBroken = false; //부서진 상태인지 체크
    double BreakTime=2.0; //부서지는 시간/ 재생성 쿨타임 설정
    float Timer=0f;

    Renderer render;
    Collider colld;

    private void Start()
    {
        OriginVec =transform.position;
        render = transform.GetComponent<MeshRenderer>();
        colld = transform.GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision col)
    {
        doBreak = true;        
    }


    private void Update()
    {
        if (doBreak)
        {
            Timer += Time.deltaTime;
            RanVec.x = Random.Range(-2f, 2f);
            RanVec.z = Random.Range(-2f, 2f);
            transform.Translate(RanVec*Time.deltaTime);
            
            if (Timer >= BreakTime)
            {
                Timer = 0f;
                doBreak = false;
                isBroken = true;                
                render.enabled = false;
                colld.enabled = false;
               
            }
        }
        else
        {
            if (isBroken)
            {
                Timer += Time.deltaTime;
                if (Timer >= BreakTime)
                {
                    Timer = 0f;
                    doBreak = false;
                    isBroken = false;                   
                    render.enabled = true;
                    colld.enabled = true;
                    transform.position = OriginVec;

                }
            }
        }
        
    }

}

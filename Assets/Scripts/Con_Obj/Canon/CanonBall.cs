using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    private Rigidbody rigid;
    private bool TimerStart = false;
    private double DeadTime = 2.0;
    private float Timer = 0;

    //충돌하지 않았을시 리턴
    private void Update()
    {
        if (TimerStart)
        {
            Timer += Time.deltaTime;
            if (Timer >= DeadTime)
            {                
                TimerStart = false;
                Timer = 0;
                ReturnObj();
            }
        }
    }  
 
    //충돌했을시 리턴
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            var obj = ExplosionPool.instance.GetObj();
            obj.transform.position = transform.position;
            obj.Explo();           
            TimerStart = false;
            Timer = 0;            
            ReturnObj();
        }else if (col.gameObject.CompareTag("Player"))
        {
            var obj = ExplosionPool.instance.GetObj();
            obj.transform.position = transform.position;
            UI_Manager.instance.alterHP(10);
            obj.Explo();
            TimerStart = false;
            Timer = 0;
            ReturnObj();
        }
    }



    public void CanonShoot(Vector3 pos, Vector3 forwd, float Power)
    {
        TimerStart = true;
        rigid = gameObject.GetComponent<Rigidbody>();
        transform.position = pos;
        rigid.AddForce(forwd * Power, ForceMode.Impulse);

    }


    public void ReturnObj()
    {
        rigid.velocity = Vector3.zero;
        CanonPool.returnObj(this);
    }

}

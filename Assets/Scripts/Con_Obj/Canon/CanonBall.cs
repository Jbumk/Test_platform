using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    private Rigidbody rigid;

  

    public void CanonShoot(Vector3 pos,Vector3 forwd,float Power)
    {      
        rigid = gameObject.GetComponent<Rigidbody>();        
        transform.position = pos;       
        rigid.AddForce(forwd*Power, ForceMode.Impulse);        
        Invoke("returnObj", 2f);
    }

    public void returnObj()
    {
        rigid.velocity = Vector3.zero;
        CanonPool.returnObj(this);
    }
}

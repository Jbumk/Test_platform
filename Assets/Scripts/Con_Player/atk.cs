using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//공격에 넣을 스크립트
public class atk : MonoBehaviour
{
    private Vector3 pos;

    public void Skill(Vector3 pos)
    {
        this.pos = pos;
        transform.position = pos;
        Invoke("del_Skill", 0.5f);
    }

    public void del_Skill()
    {
        atkpool.ReturnObj(this);
    }
  

    
}

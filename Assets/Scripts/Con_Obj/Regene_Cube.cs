using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regene_Cube : MonoBehaviour
{
    public GameObject RegenePoint;//재생성할 곳
    public GameObject Btn;//리셋 버튼
    private Rigidbody ObjRigid = null;
    private Collider ObjCol = null;
    Renderer BtnRender;


    private void Start()
    {
        if(Btn != null)
        {
            BtnRender = Btn.GetComponent<Renderer>();
        }
        ObjRigid = GetComponent<Rigidbody>();
        ObjCol = GetComponent<Collider>();
    }

    private void Update()
    {
        //버튼 누를시 재생성
        if (Btn != null) { 
            if (BtnRender.material.color == Color.green)
            {                
                transform.SetParent(RegenePoint.transform);
                ObjCol.isTrigger = false;
                ObjRigid.useGravity = true;
                ObjRigid.isKinematic = false;
                Interec.GrabObj = null;
                transform.position = RegenePoint.transform.position;
                BtnRender.material.color = Color.red;
            }
        }
        //낙하시 일정속도 도달하면 재생성->컨트롤 불가능한곳으로 떨어졌기 떄문
        if (ObjRigid.velocity.y < -40)
        {
            transform.SetParent(RegenePoint.transform);
            ObjRigid.velocity = Vector3.zero;
            transform.position = RegenePoint.transform.position;
        }
    }
  

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Lava"))
        {
            transform.SetParent(RegenePoint.transform);
            transform.position = RegenePoint.transform.position;
        }
    }





}

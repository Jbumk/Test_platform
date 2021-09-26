using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_Bridge : MonoBehaviour
{
    public GameObject Btn;
    private Renderer BtnRender;   

   
    public GameObject ActivePoint; //활성화시 도달하는 곳
    public GameObject InactivePoint;//비활성화시 도달하는 곳

    private void Start()
    {
        BtnRender = Btn.GetComponent<Renderer>();
       
    }

    private void Update()
    {      

        if(BtnRender.material.color==Color.green)
        {
            transform.position = Vector3.MoveTowards(transform.position, ActivePoint.transform.position, Time.deltaTime * 3f);
        }else if(BtnRender.material.color==Color.red)
        {
            transform.position = Vector3.MoveTowards(transform.position, InactivePoint.transform.position, Time.deltaTime * 3f);
        }

    }
}

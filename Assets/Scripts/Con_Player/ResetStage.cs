using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStage : MonoBehaviour
{
    public GameObject [] GOstack; //해당 배열에 초기화할 함수 넣기
    private Renderer rend;     
    public bool OnPlayer = false;
    private int i = 1;//반복문용 함수
    private Queue<Vector3> ObjVec = new Queue<Vector3>();
    private Queue<Quaternion> ObjQuat = new Queue<Quaternion>();

    float Timer = 0;
    double DeadEnd = 0.5;



    private void Awake()    
    {
        for (int j = 0; j < GOstack.Length; j++)
        {
            ObjVec.Enqueue(GOstack[j].transform.position);            
            ObjQuat.Enqueue(GOstack[j].transform.rotation);           
        }
    }

    private void Update()
    {
        if (OnPlayer)
        {
            if (ResetManager.ObjReset)
            {
                ResetObj();
            }            
        }
        
      
    }

    /*
    public void DoReset()
    {
        if (OnPlayer)
        {
            ResetObj();
            i = 1;
            btnreset = true;
        }
        
    }*/
    private void ResetObj()
    {
        for (int j = 0; j < GOstack.Length; j++)
        {            
            GOstack[j].transform.position = ObjVec.Dequeue();          
            GOstack[j].transform.rotation = ObjQuat.Dequeue();
          
        }
      
        for (int j = 0; j < GOstack.Length; j++)
        {
            ObjVec.Enqueue(GOstack[j].transform.position);
            ObjQuat.Enqueue(GOstack[j].transform.rotation);         
        }
        ResetManager.ObjReset = false;


    }

    //버튼 비활성화용 함수
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            OnPlayer = true;
        }

        if (OnPlayer)
        {
            if (ResetManager.BtnReset)
            {
                Timer += Time.deltaTime;
                if(Timer>= DeadEnd)
                {
                    i = 1;
                    Timer = 0;
                    ResetManager.BtnReset = false;
                }
                if (col.gameObject.name == ("Switch" + i))
                {

                    rend = col.GetComponent<Renderer>();
                    if (rend != null)
                    {
                        if (rend.material.color != Color.red)
                        {
                            rend.material.color = Color.red;
                        }                      
                        Timer = 0;
                        i++;
                    }   
                    /*
                    else
                    {
                        Debug.Log("버튼초기화끝");
                        i = 1;
                        ResetManager.BtnReset = false;
                        
                    }*/
                    
                }
            }
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            OnPlayer = false;
        }
    }

}

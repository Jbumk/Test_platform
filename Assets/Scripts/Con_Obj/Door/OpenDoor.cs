using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private bool isOpen = false;
    private bool isDoing = false;  
    public int LockeCode = 0;
    //0 Unlock 1 Black 2 Blue 3 Green 4 Red

    public GameObject Open;
    public GameObject Close;


    public AudioSource Sound;
 
   
    private Quaternion StartQuat;
    private Quaternion EndQuat;
    private int ActerType = 0;
    //0= 플레이어 1= Crab

    

    private void Start()
    {
        StartQuat = Open.transform.rotation;
        EndQuat = Close.transform.rotation;
    }
    private void Update()
    {       

        if (isDoing)
        {           
            MoveDoor();           
        }
        else
        {
            if (isOpen)
            {
                if (transform.rotation != StartQuat)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, StartQuat, 10f * Time.deltaTime);
                }
            }
            else
            {
                if (transform.rotation != EndQuat)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, EndQuat, 10f * Time.deltaTime);
                }
            }
        }


    }

    //문 움직이기
    private void MoveDoor()
    {
        if (isOpen)
        {
            //transform.rotation = EndQuat;
            
           transform.rotation = Quaternion.Slerp(transform.rotation, EndQuat, 10f * Time.deltaTime);
            
            if (transform.rotation == EndQuat)
            {
                isOpen = false;
                isDoing = false;
            }
        }
        else
        {
            //transform.rotation = StartQuat;
           transform.rotation = Quaternion.Slerp(transform.rotation, StartQuat, 10f * Time.deltaTime);
            

            if (transform.rotation == StartQuat)
            {
                isOpen = true;
                isDoing = false;
            }
        }

       
    }
    

    
     //interec에서 e눌렀을때 실행 or 문닫혀있을때 Crab접근하면 실행
    public void Doing(int Type)
    {           
        ActerType = Type;
        Sound.Play();
        isDoing = true;        
    }

    public void UnLock(bool HaveKey)
    {
        if (HaveKey)
        {
            //잠금 헤제 메세지 출력 
            MSG_Manager.instance.Ins_Code(11);
            LockeCode = 0;
            Doing(0);
        }
        else
        {
            //잠긴문 사운드 출력

            //잠김 메세지 출력
            MSG_Manager.instance.Ins_Code(10);
        }
    }
 

    private void OnTriggerStay(Collider col)
    {   
        if (col.gameObject.CompareTag("CrabDect"))
        {
            if (isDoing && ActerType==0)
            {
                Crab_Act.instance.HearSound(2, transform.position);
            }
        }
    }

    public bool OpenChk()
    {
        return isOpen;
    }
 
    public int LockChk()
    {
        return LockeCode;
    }

}

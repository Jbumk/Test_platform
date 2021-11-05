﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interec : MonoBehaviour
{
    public static GameObject GrabObj = null;
    private Rigidbody GrabObjRigid = null;
    private Collider GrabObjCol = null;
    private OpenDoor Door=null;

    public GameObject FirCam;
    public GameObject ThrCam;
    public GameObject Player;

    Vector3 ThrCamVec;
    Quaternion HingeQuat;

    float InterecTimer = 0;
    double InterecCoolTime = 0.5;

    //사이에 방해물체 있는지 감지
    public GameObject RayPoint;//레이저 발사할 위치
    private RaycastHit hit;
    Vector3 RayVec;  
    int laymask = ~((1 << 9));

    Vector3 GrabScale;


    public AudioSource GrabSound;
    public AudioSource ThrowSound;

    

    private void Update()
    {
        InterecTimer += Time.deltaTime;
        if (GrabObj != null)
        {
            GrabObjRigid.velocity = Vector3.zero;
            if (Input.GetMouseButtonDown(0))
            {
                ThrowObj();
            }
        }
      


    }

    private void ThrowObj()
    {
        if (Con_Camera.FirCamOn)
        {
            ThrowSound.Play();
            GrabObj.transform.SetParent(null);
            GrabObj.transform.localScale = GrabScale;    
            GrabObjRigid.useGravity = true;
            GrabObjRigid.AddForce(FirCam.transform.forward * 10f, ForceMode.Impulse);
            
        }
        else
        {
            ThrowSound.Play();
            ThrCamVec = ThrCam.transform.forward;
            ThrCamVec.y = 0f;
            Player.transform.forward = ThrCamVec;
            GrabObj.transform.SetParent(null);
            GrabObj.transform.localScale = GrabScale;         
            GrabObjRigid.useGravity = true;          
            GrabObjRigid.AddForce(ThrCam.transform.forward * 10f, ForceMode.Impulse);
            
        }
        GrabObj = null;
        GrabObjCol = null;
        GrabObjRigid = null;
        InterecTimer = 0;
    }



    private void OnTriggerStay(Collider col)
    {
        //물건 집기
        if (col.gameObject.CompareTag("CanGrab") && InterecTimer >= InterecCoolTime)
        {
            RayVec = (col.transform.position - RayPoint.transform.position).normalized;
          
            if (Physics.Raycast(RayPoint.transform.position, RayVec,out hit,Vector3.Distance(RayPoint.transform.position,col.transform.position),laymask))
            {            
                if (!hit.collider.gameObject.CompareTag("Ground"))
                {                      
                    if (GrabObj == null && Input.GetKey(KeyCode.E)&& !Chara_Main_Move.OnDash)
                    {                        
                          GrabScale = col.transform.localScale;
                          GrabSound.Play();
                          GrabObj = col.gameObject;
                          GrabObj.transform.SetParent(transform);
                          GrabObj.transform.position = transform.position;
                          GrabObjRigid = GrabObj.GetComponent<Rigidbody>();
                          GrabObjCol = GrabObj.GetComponent<Collider>();                         
                          GrabObjRigid.useGravity = false;                       
                          InterecTimer = 0;
                        
                    }
                 }


            }
           

        }

        //물건 놓기
        if (GrabObj != null && InterecTimer >= InterecCoolTime)
        {
          
            if (Input.GetKey(KeyCode.E))
            {
                GrabSound.Play();
                GrabObj.transform.SetParent(null);
                GrabObj.transform.localScale = GrabScale;        
                GrabObjRigid.useGravity = true;       
                GrabObj = null;
                GrabObjCol = null;
                GrabObjRigid = null;
                InterecTimer = 0;
            }

            
        }


        //문열기
        if (col.gameObject.CompareTag("Hinge") && GrabObj==null && InterecTimer >= InterecCoolTime)
        {
            if (Input.GetKey(KeyCode.E))
            {                
                Door = col.gameObject.GetComponent<OpenDoor>();                                            
                Door.Doing();
                InterecTimer = 0;              
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (GrabObj != null && col.gameObject.CompareTag("CanGrab"))
        {
            GrabSound.Play();
            GrabObj.transform.SetParent(null);
            GrabObj.transform.localScale = GrabScale;     
            GrabObjRigid.useGravity = true;
            GrabObj = null;
            GrabObjCol = null;
            GrabObjRigid = null;
            InterecTimer = 0;
        }
        
    }


}

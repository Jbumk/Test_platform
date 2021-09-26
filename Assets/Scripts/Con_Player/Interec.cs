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
    private void Update()
    {
        InterecTimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && GrabObj != null)
        {
            ThrowObj();
        }
    }

    private void ThrowObj()
    {
        if (Con_Camera.FirCamOn)
        {
            GrabObj.transform.SetParent(null);
            GrabObjCol.isTrigger = false;
            GrabObjRigid.useGravity = true;
            GrabObjRigid.isKinematic = false;
            GrabObjRigid.AddForce(FirCam.transform.forward * 10f, ForceMode.Impulse);
            
        }
        else
        {
            ThrCamVec = ThrCam.transform.forward;
            ThrCamVec.y = 0f;
            Player.transform.forward = ThrCamVec;
            GrabObj.transform.SetParent(null);
            GrabObjCol.isTrigger = false;
            GrabObjRigid.useGravity = true;
            GrabObjRigid.isKinematic = false;           
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
            if (GrabObj == null)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    GrabObj = col.gameObject;
                    GrabObj.transform.SetParent(transform, true);
                    GrabObj.transform.position = transform.position;
                    GrabObjRigid = GrabObj.GetComponent<Rigidbody>();
                    GrabObjCol = GrabObj.GetComponent<Collider>();
                    GrabObjCol.isTrigger = true;
                    GrabObjRigid.useGravity = false;
                    GrabObjRigid.isKinematic = true;
                    InterecTimer = 0;
                }
            }
        }

        //물건 놓기
        if (GrabObj != null && InterecTimer >= InterecCoolTime)
        {
            if (Input.GetKey(KeyCode.E))
            {
                GrabObj.transform.SetParent(null);
                GrabObjCol.isTrigger = false;
                GrabObjRigid.useGravity = true;
                GrabObjRigid.isKinematic = false;
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

   
}
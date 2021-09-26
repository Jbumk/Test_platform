﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_Camera : MonoBehaviour
{
    public static bool FirCamOn = true;
    public GameObject FirCam;
    public GameObject ThrCam;
    public static GameObject ThrCamPos;
    public GameObject Player;
    public GameObject body;
    float Mouse_Speed = 2f;
   

    float ChangeTimer = 0;
    double ChangeCoolTime = 0.5;

    Vector3 FirCamRot = new Vector3(0f, 0f, 0f);
    Vector3 ThrCamRot = new Vector3(0f, 0f, 0f);
    Quaternion FirCamQuat;


    //Raycast에 쓰일 함수
    RaycastHit hit;
    private int laymask = 1 << 9;
    //Vector3 ThrCamOriginVec = new Vector3(0f, 1.5f, -2.5f); //원래 3인칭 카메라의 위치
    public GameObject ThrCamOriginVec; //원래 3인칭 카메라의 위치
    private float ThrCam_Dist = 3f; //3인칭 카메라의 대략적인 거리


  

    private void Start()
    {
        ThrCamPos = GameObject.Find("ThrCamPos");
        laymask = ~laymask;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeTimer += Time.deltaTime;
        if (ChangeTimer >= ChangeCoolTime)
        {
            ChangeCam();           
        }
        

        if (FirCamOn)
        {         
            Con_FirCam();         
            FirCamQuat = FirCam.transform.rotation;
            FirCamQuat.x = 0f;
            FirCamQuat.z = 0f;
            Player.transform.rotation = FirCamQuat;
        }
        else
        {
            Con_ThrCam();
            //FirCam.transform.rotation = Player.transform.rotation;
        }
        FirCam.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1.5f, Player.transform.position.z);
        ThrCamPos.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1.2f, Player.transform.position.z);

    }



    private  void ChangeCam()
    {

        if (Input.GetKey(KeyCode.F))
        {
            if (FirCamOn == true)
            {

                FirCam.SetActive(false);
                ThrCam.SetActive(true);
                FirCamOn = false;
                body.SetActive(true);

            }
            else
            {

                FirCam.SetActive(true);
                ThrCam.SetActive(false);
                FirCamOn = true;
                body.SetActive(false);               
                FirCam.transform.rotation = ThrCamPos.transform.rotation;
            
            }
            ChangeTimer = 0;
        }            

    }


    private void Con_FirCam()
    {
        Player.transform.Rotate(0f, Input.GetAxis("Mouse X") * Mouse_Speed, 0f, Space.Self);


        FirCamRot.x += -Input.GetAxis("Mouse Y") * Mouse_Speed;
        FirCamRot.x = Mathf.Clamp(FirCamRot.x, -60f, 40f);
        FirCamRot.y += Input.GetAxis("Mouse X") * Mouse_Speed;

        FirCam.transform.rotation = Quaternion.Euler(FirCamRot);
    }

    private void Con_ThrCam()
    {
        ThrCamRot.x += -Input.GetAxis("Mouse Y") * Mouse_Speed;
        ThrCamRot.x = Mathf.Clamp(ThrCamRot.x, -60f, 40f);
        ThrCamRot.y += Input.GetAxis("Mouse X") * Mouse_Speed;

        ThrCamPos.transform.rotation = Quaternion.Euler(ThrCamRot);
        Debug.DrawRay(ThrCamOriginVec.transform.position, ThrCamOriginVec.transform.forward * ThrCam_Dist,Color.red);


        //벽과 만났을시 앞으로 당겨옴
        if(Physics.Raycast(ThrCamOriginVec.transform.position, ThrCamOriginVec.transform.forward, out hit,ThrCam_Dist,laymask))
        {
            if (hit.transform.CompareTag("Player"))
            {
                ThrCam.transform.position = ThrCamOriginVec.transform.position;              
                
            }
            else if(hit.transform.CompareTag("CanGrab"))
            {
                ThrCam.transform.position = ThrCamOriginVec.transform.position;
                Debug.Log("GrabThing");
            }
            else
            {
                ThrCam.transform.position = hit.point;             
            }
        }
        else
        {
            ThrCam.transform.position = ThrCamOriginVec.transform.position;
        }
    }

    
 
    
}
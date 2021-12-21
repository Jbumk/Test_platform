using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_Camera : MonoBehaviour
{
    public static bool FirCamOn = true;
    public static bool setFircam = false;
    public GameObject FirCam;
    public GameObject ThrCam;
    public static GameObject ThrCamPos;
    public GameObject Player;
    public GameObject body;
    public GameObject RayPoint;
    public GameObject Spot; //화면 중앙 표시점

    private Vector3 Dir;
    private float Mouse_Speed = 2f;
    private float Distance; //ThrCam과 Player의 거리 저장
   

    private float ChangeTimer = 0;
    private double ChangeCoolTime = 0.5;

    private Vector3 FirCamRot = new Vector3(0f, 0f, 0f);
    private Vector3 ThrCamRot = new Vector3(0f, 0f, 0f);
    private Quaternion FirCamQuat;


    //Raycast에 쓰일 함수
    private RaycastHit hit;
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
        Dir = ThrCamOriginVec.transform.position - RayPoint.transform.position;
        ChangeTimer += Time.deltaTime;

      

        if (!Menu.onMenu)
        {
            if (setFircam)
            {
                FirCamOn = true;
                FirCam.SetActive(true);
                ThrCam.SetActive(false);
                body.SetActive(false);
            }

            if (ChangeTimer >= ChangeCoolTime)
            {
                ChangeCam();
            }
                        

            FirCam.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1.5f, Player.transform.position.z);
            ThrCamPos.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1.2f, Player.transform.position.z);

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

            }
        }
        

    }



    private  void ChangeCam()
    {

        if (Input.GetKey(KeyCode.F)&&!setFircam)
        {
            if (FirCamOn == true)
            {
                FirCamOn = false;
                FirCam.SetActive(false);
                ThrCam.SetActive(true);                
                body.SetActive(true);
                Spot.SetActive(false);

            }
            else
            {
                FirCamOn = true;
                FirCam.SetActive(true);
                ThrCam.SetActive(false);                
                body.SetActive(false);
                FirCam.transform.rotation = ThrCamPos.transform.rotation;
                Spot.SetActive(true);

            }
            ChangeTimer = 0;
        }            

    }


    private void Con_FirCam()
    {
        Player.transform.Rotate(0f, Input.GetAxis("Mouse X") * Mouse_Speed, 0f, Space.Self);


        FirCamRot.x += -Input.GetAxis("Mouse Y") * Mouse_Speed;
        FirCamRot.x = Mathf.Clamp(FirCamRot.x, -60f, 60f);
        FirCamRot.y += Input.GetAxis("Mouse X") * Mouse_Speed;

        FirCam.transform.rotation = Quaternion.Euler(FirCamRot);
    }

    private void Con_ThrCam()
    {
        ThrCamRot.x += -Input.GetAxis("Mouse Y") * Mouse_Speed;
        ThrCamRot.x = Mathf.Clamp(ThrCamRot.x, -60f, 40f);
        ThrCamRot.y += Input.GetAxis("Mouse X") * Mouse_Speed;

        ThrCamPos.transform.rotation = Quaternion.Euler(ThrCamRot);
        //Debug.DrawRay(ThrCamOriginVec.transform.position, ThrCamOriginVec.transform.forward * ThrCam_Dist,Color.red);


        //벽과 만났을시 앞으로 당겨옴
        if(Physics.Raycast(RayPoint.transform.position, Dir, out hit,ThrCam_Dist,laymask))
        {
            /* if (hit.transform.CompareTag("Player"))
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

             }*/
            Distance = Vector3.Distance(ThrCam.transform.position, Player.transform.position);
            ThrCam.transform.position = hit.point;            
            ThrCam.transform.position += ThrCam.transform.forward*(Distance*0.5f);
        }
        else
        {
            ThrCam.transform.position = ThrCamOriginVec.transform.position;
        }
    }

    
 
    
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara_Main_Move : MonoBehaviour
{
    //기본 정의 구간 2021-08-09
    public static Rigidbody rigid;
    static float speed = 3f;  //속도    
    public static bool OnGround;  // 바닥에 닿은지 체크
    public static bool isJump;// 점프중인지 체크
    public static bool OnDash; //대쉬중인지 채크
    private bool ForwardBlock;
    static float fall_timer;
    static double fall_die;
    
    public GameObject ThrCampos;
    public GameObject RayPoint;
    public GameObject RayPoint2;
    public GameObject RayPoint3;
    public GameObject RayPoint4;
    public GameObject RayPoint5;


    private RaycastHit hit;
    
    
    private static Vector3 RevivePoint = new Vector3(0, 3, 0); //부활할 첫번째 지점
  
    // Start is called before the first frame update
    void Start()
    {       
        rigid = GetComponent<Rigidbody>();
        fall_timer = 0;
        fall_die = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Con_Camera.FirCamOn)
        {
     
            //W눌러서 전방이동
            if (Input.GetKey(KeyCode.W))
            {
                MoveForward();
            }


            //S눌러서 후방이동
            if (Input.GetKey(KeyCode.S))
            {
                MoveBack();
            }

            //A눌러서 좌측 이동
            if (Input.GetKey(KeyCode.A))
            {
                MoveLeft();
            }


            //D눌러서 우측 이동
            if (Input.GetKey(KeyCode.D))
            {
                MoveRight();
            }


           
        }
        else
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                ThrLook();              
            }
        } 



        //앞과 밑 물체 감지
        DetectDown();
        DetectForward();


        //점프시 속도제어 부분
        if (isJump && OnGround || ForwardBlock)
        {
            speed = 0f;
        }
        /*
        else
        {
            if (OnDash)
            {
                speed = 6f;
            }
            else
            {
                speed = 3f;
            }
        }*/       
        //스페이스 눌러 점프
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!isJump)
            {
                Jump();
            }
        }
       

        //대쉬 작동과 해제
        Dash();
        Revive();



    
    }



    private void Revive()
    {
        if (UI_Manager.instance.getDead())
        {
            if (Input.GetKey(KeyCode.Return))
            {
                UI_Manager.instance.Revive();
                Game_Manager.instance.Revive();
            }
        }
    }


    //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ 플레이어 기본 움직임 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
    private void MoveForward()
    {       
       transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void MoveBack()
    {        
       transform.Translate(Vector3.back * speed * Time.deltaTime);      
    }

    private void MoveLeft()
    {       
      transform.Translate(Vector3.left * speed * Time.deltaTime);      
    }

    private void MoveRight()
    {      
       transform.Translate(Vector3.right * speed * Time.deltaTime);      
    }
    
    private void Jump()
    {
        if (OnGround && !isJump)
        {
            OnGround = false;
            isJump = true;
            rigid.AddForce(Vector3.up * 6f, ForceMode.Impulse);
        }
    }



    //대쉬 작동과 해제
    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (OnGround == true)
            {
                OnDash = true;
                speed = 6f;
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            OnDash = false;
            speed = 3f;
        }
    }


    //3인칭시 캐릭터 컨트롤
    private void ThrLook()
    {
        Vector2 MoveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = MoveInput.magnitude != 0;
        if (isMove)
        {
            Vector3 LookForward = new Vector3(ThrCampos.transform.forward.x, 0f, ThrCampos.transform.forward.z).normalized;
            Vector3 LookRight = new Vector3(ThrCampos.transform.right.x, 0f, ThrCampos.transform.right.z).normalized;
            Vector3 Direction = LookForward * MoveInput.y + LookRight * MoveInput.x;
            transform.forward = Direction;
            
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    
  
    
    //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ



    //바닥에 닿았을시 체크함수 true로변경
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;                  
        }
    }
    
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {           
           OnGround = true;           
           //fall_timer = 0;           
        }
    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("PlayerOut");
            OnGround = false;

        }
    }
    // 근처 오브젝트 탐지
    private void DetectForward()
    {
        //RayCast통해 앞에 물체 감지
        if (Physics.Raycast(RayPoint.transform.position, RayPoint.transform.forward * 0.35f, out hit, 0.35f))
        {
            
            if (hit.transform.CompareTag("Ground"))
            {
                ForwardBlock = true;
                speed = 0;

            }

        }
        else
        {
            ForwardBlock = false;
            if (OnDash)
            {
                speed = 6f;
            }
            else
            {
                speed = 3f;
            }
        }
        
    }
    private void DetectDown()
    {
       
        if (Physics.Raycast(RayPoint.transform.position, RayPoint.transform.up * -1.2f, out hit, 1.2f)
            || Physics.Raycast(RayPoint2.transform.position, RayPoint2.transform.up * -1.2f, out hit, 1.2f)
            || Physics.Raycast(RayPoint3.transform.position, RayPoint3.transform.up * -1.2f, out hit, 1.2f)
            || Physics.Raycast(RayPoint4.transform.position, RayPoint4.transform.up * -1.2f, out hit, 1.2f)
            || Physics.Raycast(RayPoint5.transform.position, RayPoint5.transform.up * -1.2f, out hit, 1.2f))
        {

            if (hit.transform.CompareTag("Ground"))
            {
                isJump = false;
                OnGround = true;
                fall_timer = 0f;
            }
        }
        else
        {
            isJump = true;
        }
    }
    

 

    //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ플레이어의 위치 이동 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
    public static void SavePoint()
    {       
        rigid.transform.position = RevivePoint;
    }


    //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ플레이어 낙하값 측정
    public static float max_Pos;


    //낙하데미지
    public static void fall()
    {
        if (!OnGround)
        {
            if (rigid.velocity.y< 0 && max_Pos < rigid.transform.position.y)
            {               
                max_Pos = rigid.transform.position.y;
            }
            if (rigid.velocity.y < 0)
            {
                fall_timer += Time.deltaTime;
            }
            if (fall_timer >= fall_die)
            {
                UI_Manager.instance.alterHP(UI_Manager.instance.getMaxHP());
                fall_timer = 0;
            }            
        }
        else
        {         
            if (max_Pos - rigid.transform.position.y > 5)
            {
                //임시 계산식 추후 개선필요 가능성 있음
                double dmg;
                dmg = 2 * Mathf.Log(max_Pos - rigid.transform.position.y, 2);
                dmg = UI_Manager.instance.getMaxHP() / 100 * (dmg*10);
                UI_Manager.instance.alterHP((int)dmg);
               
                dmg = 0;               
                max_Pos = 0;
            }
            else
            {
               max_Pos = rigid.transform.position.y;
            }          
        }
    }

   

}

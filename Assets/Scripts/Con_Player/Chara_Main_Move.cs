using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara_Main_Move : MonoBehaviour
{
   
    public static Rigidbody rigid;
    static float speed = 3f;  //속도    
    public static bool OnGround=false;  // 바닥에 닿은지 체크
    public static bool isJump=false;// 점프중인지 체크
    public static bool OnDash=false; //대쉬중인지 체크
    public static bool ForwardBlock=false; //앞이 막혀있는지 체크    
    public static bool isHide = false; //숨어있는지 아닌지 체크

    public GameObject ThrCampos;      
    public GameObject RayPoint;    


    private RaycastHit hit;
    
    
    private static Vector3 RevivePoint = new Vector3(0, 3, 0); //부활할 첫번째 지점

  
   
    void Start()
    {       
        rigid = GetComponent<Rigidbody>();
      
       
    }

    
    void Update()
    {
        if (!Menu.onMenu)
        {
            if (!isHide)
            {
                if (Con_Camera.FirCamOn)
                {
                    //1인칭일때 이동 조작
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
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

                }
                else
                {
                    //3인칭일때 이동 조작
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                    {
                        ThrLook();
                    }
                }


                //점프시 속도제어 부분
                if (ForwardBlock&&!OnGround)
                {
                    speed = 0f;
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

                //스페이스 눌러 점프
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    if (!isJump&&OnGround)
                    {
                        Jump();
                    }
                }


                //R키를 눌러 리셋
                if (Input.GetKeyDown(KeyCode.R))
                {
                    ResetManager.ObjReset = true;
                    ResetManager.BtnReset = true;
                    Revive();
                }



                //대쉬 작동과 해제
                Dash();

            }

            //죽었을시 엔터키 눌러 부활
            if (UI_Manager.instance.getDead())
            {
                if (Input.GetKey(KeyCode.Return))
                {
                    Revive();
                }
            }
        }
    
    }


    
    public void Revive()
    {
        UI_Manager.instance.Revive();               
        Game_Manager.instance.Revive();
        Consum_System.max_Pos = transform.position.y;
        rigid.velocity = Vector3.zero;        
     
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
       //OnGround = false;
       isJump = true;
       rigid.AddForce(Vector3.up * 6f, ForceMode.Impulse);
        
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
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;                  
        }
    }    

    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {           
            OnGround = false;

        }
    }  
    */
 

    //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ플레이어의 위치 이동 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
    public static void SavePoint()
    {
        RevivePoint = rigid.transform.position ;
        Game_Manager.instance.SaveRevivePoint(RevivePoint);
    }
       

   

}

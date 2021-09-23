using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Consum_Mon : MonoBehaviour
{
    public Slider Mon_UI;   
    //public GameObject UI; 3D오브젝트 임시 폐기

       
   public GameObject Player;    
   bool UI_ON = false;
   float UI_Timer=0;
   int Mon_Now_HP;
   double UI_Time_End=5.0;



    //스태틱 값 저장
    public static int On_Changer; //static으로 받아올 UI 실행 감지값
    public static int HP; //static으로 받아올 몬스터의 체력값


    // Start is called before the first frame update
    void Start()
    {       
  
        On_Changer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //UI 실행감지
        if (On_Changer == 1)
        {
            UI_ON = true;
            Mon_Now_HP = HP;
            UI_Timer = 0;
            On_Changer = 0;
        }

        //UI 실행
        if (UI_ON)
        {            
            UI_Timer += Time.deltaTime;
            if (UI_Timer >= UI_Time_End)
            {
                Mon_UI.gameObject.SetActive(false);
                UI_ON = false;
                UI_Timer = 0;
            }
            else
            {
                Mon_UI.gameObject.SetActive(true);
                Mon_UI.value = Mon_Now_HP;
            }

        }


        if (Mon_Now_HP <= 0)
        {
            Mon_UI.gameObject.SetActive(false);
        }
       
    }
    
    
    //스태틱으로 받아온 UI 실행값
    public static void  UI_ON_Changer(int N_HP)
    {
        HP = N_HP;
        On_Changer = 1;
    }
    


 
    
     
    //충돌 처리를 몬스터 개인 스크립트로 넘김
    
    /*
    void  OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Pattern"))
        {
            Mon_Now_HP -= 10;
            UI_ON = true;
            UI_Timer = 0;
            
        }
        

        /*
               3D오브젝트의 체력바 표시 => 기술력부족으로 임시 폐기
        if (col.gameObject.CompareTag("Pattern"))
        {
            if (col.gameObject.name == "Test_Attck(Clone)")
            {
                Mon_Now_HP -= 10;
                Debug.Log(Mon_Now_HP);
            }
            UI =Instantiate(Mon_UI, this.transform.position, Player.transform.localRotation);
            UI_ON = true;
            UI.transform.position += this.transform.up * 1;
            Destroy(UI,1f);
            UI_ON = false;
           // UI.transform.rotation = Player.transform.localRotation;
        }
        
        
     
    }
    
    */
    
}

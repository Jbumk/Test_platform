using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chara_Main_HPMPLV : MonoBehaviour
{/*
    //UI의 HP, MP, EXP 표시와 조절
    public static int Max_Health = 100;        //최대 HP값
    public static int Now_Health = 100;        //현재 HP값
    public Slider Slid_Health;                 //HP값 슬라이더 표기

    public static int Max_Magic = 100;         //최대 MP값
    public static int Now_Magic = 100;         //현재 MP값
    public Slider Slid_Magic;                  //MP값 슬라이더 표기


    public static int Max_EXP = 100;           //최대 EXP값
    public static int Now_EXP = 0;             //현재 EXP값
    public static int Temp_EXP = 0;            //레벨업 이후 남은 경험치 값 저장용
    public static double Per_EXP = 0.0;        //경험치 % 계산용
    public static int LV = 1;                  //현재 레벨

    public Text T_HP;                   //HP 표시
    public Text T_MP;                   //MP 표시
    public Text T_LV;                   //LV 표시
    public Text T_EXP;                  //EXP 표시

    public int HP_con = 0;                    //테스터모드에서 조절할 HP값
    public int MP_con = 0;                    //테스터모드에서 조절할 MP값
    public int EXP_con = 0;                    //테스터모드에서 조절할 EXP값

    public GameObject Mainscn;
    public GameObject HPUI;
   
   
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
     //UI값 조절과 표시 2021-08-09
    void Update()
    {
        T_HP.text = Now_Health + " / " + Max_Health;
        T_MP.text = Now_Magic + " / " + Max_Magic;
        T_LV.text = " "+LV;
        Cal_EXP(Now_EXP, Max_EXP);
        T_EXP.text = Now_EXP + " / " + Max_EXP + " (" + string.Format("{0:N2}",Per_EXP) + "%)";
        Slid_Health.value = (int)((double)Now_Health / (double)Max_Health * 100);
        Slid_Magic.value = (int)((double)Now_Magic / (double)Max_Magic * 100);


        if (Input.GetKey(KeyCode.F10))
        {
            Now_Health -= HP_con;
        }
        if (Input.GetKey(KeyCode.F11))
        {
            Now_Magic -= MP_con;
        }
        if (Input.GetKey(KeyCode.F12))
        {
            Now_EXP += EXP_con;
        }

        //레벨업
        if (Now_EXP >= Max_EXP)
        {
            //경험치 조절
            Temp_EXP = Now_EXP - Max_EXP; //남은 경험치 값 저장
            Now_EXP = 0;
            Max_EXP = Max_EXP*12/10;
            LV++;
            Now_EXP += Temp_EXP; //남은 경험치값 레벨업 후 더해줌
            Temp_EXP = 0;

            //HP 조절
            Max_Health = Max_Health * 12 / 10;
            Now_Health = Max_Health;

            //MP 조절
            Max_Magic = Max_Magic * 12 / 10;
            Now_Magic = Max_Magic;

        }

        //사망
        if (Now_Health <= 0)
        {
            Now_Health = 0;
            Mainscn.SetActive(true);
            HPUI.SetActive(false);
            if (Input.GetKey(KeyCode.Return))
            {
                revive();
            }
            
        }

    }

    void Cal_EXP(int N_EXP, int M_EXP)
    {
        Per_EXP = (double)N_EXP / (double)M_EXP * 100.0;
    }

    void revive()
    {
        Now_Health = Max_Health;
        Mainscn.SetActive(false);
        HPUI.SetActive(true);
        Chara_Main_Move.SavePoint();
       
    }

   */


   
}

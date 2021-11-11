using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance
    {
        get
        {
            if (m_inst == null)
            {
                m_inst = FindObjectOfType<UI_Manager>();
            }
            return m_inst;
        }
      
    }

    private static UI_Manager m_inst;


    //public Text textHP;
    public Slider silderHP;

    //public Text textMP;
    public Slider silderMP;

   // public Text textEXP;
   // public Text textLV;

    private int MaxHP = 100;
    private int NowHP = 100;

    private int MaxMP = 100;
    private int NowMP = 100;

   // private int MaxEXP = 100;
   // private int NowEXP = 0;

  //  private int LV = 1;

   // double perEXP;
    double perHP;
    double perMP;
    private bool isDead = false;
    public GameObject DeadScean;
    public GameObject HitScean;

    //HP값에 변동 있을때 호출
    public int alterHP(int altValue)
    {
        if (NowHP > 0)
        {
            NowHP -= altValue;
            if (altValue > 0)
            {
                HitScean.SetActive(true);
                Invoke("HitSceanOff", 0.5f);
            }
            UIUpdate();
            if (NowHP <= 0)
            {
                isDead = true;
                Dead();
            }
        }
        return NowHP;

    }

    //MP값에 변동 있을때 호출
    public int alterMP(int altValue)
    {
        NowMP -= altValue;
        UIUpdate();
        return NowMP;
    }

    //EXP값에 변동 있을때 호출
   /* public int alterEXP(int altValue)
    {
        NowEXP += altValue;

        if (NowEXP >= MaxEXP)
        {
            LV++;
            alterStat();
            if (NowEXP >= MaxEXP)
            {
                alterEXP(0);
            }
        }

        UIUpdate();
        return NowEXP;
    }*/

    //레벨업시 스텟변경
    /*
    public void alterStat()
    {
        MaxHP *= 12 / 10;
        NowHP = MaxHP;
        MaxMP *= 12 / 10;
        NowMP = MaxMP;
        MaxEXP *= 15 / 10;

    }*/

    //계산위해 HP,MP값 리턴
    public int getMaxHP()
    {
        return MaxHP;
    }
    public int getMaxMP()
    {
        return MaxMP;
    }
    public int getNowHP()
    {
        return NowHP;
    }
    public int getNowMP()
    {
        return NowMP;
    }
    public bool getDead()
    {
        return isDead;
    }
   

    //부활
    public void Revive()
    {

        NowHP = MaxHP;
        NowMP = MaxMP;
        isDead = false;
        DeadScean.SetActive(false);       
        UIUpdate();

    }

        //UI창 업데이트
        public void UIUpdate()
    {
       // perEXP = (double)NowEXP / (double)MaxEXP * 100;

       // if (NowHP > MaxHP) NowHP = MaxHP;
       // textHP.text = NowHP + "/" + MaxHP;

       // if (NowMP > MaxMP) NowMP = MaxMP;
        //textMP.text = NowMP + "/" + MaxMP;

       // textEXP.text = NowEXP + "/" + MaxEXP + "(" + perEXP + "%)";
        //textLV.text = LV + "";

        perHP = (double)NowHP / (double)MaxHP * 100;
        perMP = (double)NowMP / (double)MaxMP * 100;
        silderHP.value = (int)perHP;
        silderMP.value = (int)perMP;
    }

    //죽었을때의 행동
    public void Dead()
    {
        DeadScean.SetActive(true);       
        
    }

    public void HitSceanOff()
    {
        HitScean.SetActive(false);
    }

    private void Awake()
    {
        UIUpdate();
       
    }
}

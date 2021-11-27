using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MSG_Manager : MonoBehaviour
{
    public static MSG_Manager instance
    {
        get
        {
            if (m_inst == null)
            {
                m_inst = FindObjectOfType<MSG_Manager>();
            }
            return m_inst;
        }
    }

    private static MSG_Manager m_inst;

    private int MSG_Code;
    private bool DoPrint = false;
    private float Timer = 0;
    private double PrintTime = 2.0;
    public GameObject MSGPanel;
    public TextMeshProUGUI MSG;
    
    
    
    

    //외부에서 코드 받아온다
    public void Ins_Code(int Code)
    {
        MSG_Code = Code;
        DoPrint = true;
        MSGPanel.SetActive(true);
        Timer = 0;
    }


    //받아온 코드를 update에서 if문으로 감지해 실행
    //일정시간 경과하면 메세지 끔
    private void Update()
    {
        if (DoPrint)
        {
            Timer += Time.deltaTime;
            switch (MSG_Code)
            {
                case 0:
                    MSG.text = "Press WASD to Move";
                    break;
                case 1:
                    MSG.text = "Press Space to Jump";
                    break;
                case 2:
                    MSG.text = "Press Shift to Dash";
                    break;                   
                case 3:
                    MSG.text = "Press E to Grab And Release";                    
                    break;
                case 4:
                    MSG.text = "Press G to Turn On Light";
                    break;
                case 5:
                    MSG.text = "Click left Button To Go Back To 3 Seconds";
                    break;
                case 6:
                    MSG.text = "Click Right Button To Time Stop";
                    break;
                case 7:
                    MSG.text = "Press F to Camera Change";
                    break;
                case 8:
                    MSG.text = "When holding an object, throw it with a left click";
                    break;
                case 9:
                    MSG.text = "Press R to Reset";
                    break;
                case 10:
                    MSG.text = "Locked";
                    break;
                case 11:
                    MSG.text = "Door Unlock";
                    break;

            }
            if (Timer >= PrintTime)
            {
                DoPrint = false;
                Timer = 0;
                MSGPanel.SetActive(false);
            }
        }
       
    }
}

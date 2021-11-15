using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hid_Locker : MonoBehaviour
{
    //숨었을때 해당할 위치
    public GameObject HidePos;
    //해당 Locker 숨었는지 체크
    private bool HideThis = false;

    public GameObject Player;

    public GameObject Door;
    public GameObject OpenRot;
    public GameObject CloseRot;
    public bool isOpen = false; //false > 닫혀있음 true > 열려있음

    private void Update()
    {
        if (HideThis)
        {
            Con_Camera.setFircam = true;
        }
        else
        {
            Con_Camera.setFircam = false;
        }


        if (isOpen)
        {
            if (Door.transform.rotation != OpenRot.transform.rotation)
            {
                Door.transform.rotation = Quaternion.Slerp(Door.transform.rotation, OpenRot.transform.rotation, 3f * Time.deltaTime);
            }
        }
        else
        {
            if(Door.transform.rotation != CloseRot.transform.rotation)
            {
                Door.transform.rotation = Quaternion.Slerp(Door.transform.rotation, CloseRot.transform.rotation, 10f * Time.deltaTime);
            }
        }

    }



    //숨기
    public void Hide()
    {
        HideThis = true;
        isOpen = false;
        Player.transform.position = HidePos.transform.position;
        Player.transform.rotation = HidePos.transform.rotation;

    }
    
    //나오기
    public void Expose()
    {
        HideThis = false;        
        Player.transform.position = HidePos.transform.position + (HidePos.transform.forward*3f);

    }


    //Crab이 수색
    public void Find()
    {
        isOpen = true;
        if (HideThis)
        {
            Chara_Main_Move.isHide = false;
        }
    }
}

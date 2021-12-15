using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_Door : MonoBehaviour
{
    public GameObject Btn;   
    public GameObject BlockPoint;
    public GameObject OpenPoint;
    public GameObject Door;
    public AudioSource DoorSound;
   

    private Renderer Btn_Color;  
    private Button BtnValue;
   

    private bool StateOpen = false;

    public bool Senser = false;
    //근처에가면 열릴지 확인
    private bool exist = false;
    //센서공간 안에 플레이어or 몬스터 존재하는지 확인
  

    private void Start()
    {
        if (Btn != null)
        {
            Btn_Color = Btn.GetComponent<Renderer>();
            BtnValue = Btn.GetComponent<Button>();
        }       
     
    }
   
    private void Update()
    {
        if (!Senser)
        {
            if (Btn_Color.material.color == Color.green)
            {
                if (!StateOpen)
                {
                    DoorSound.Stop();
                    DoorSound.Play();
                    StateOpen = true;
                }

                Door.transform.position = Vector3.MoveTowards(Door.transform.position, OpenPoint.transform.position, 3f * Time.deltaTime);
            }
            else
            {
                if (StateOpen)
                {
                    DoorSound.Stop();
                    DoorSound.Play();
                    StateOpen = false;
                }

                Door.transform.position = Vector3.MoveTowards(Door.transform.position, BlockPoint.transform.position, 3f * Time.deltaTime);
            }
        }
        else
        {
            if (exist)
            {
                if (!StateOpen)
                {
                    DoorSound.Stop();
                    DoorSound.Play();
                    StateOpen = true;
                }

                Door.transform.position = Vector3.MoveTowards(Door.transform.position, OpenPoint.transform.position, 3f * Time.deltaTime);
            }
            else
            {
                if (StateOpen)
                {
                    DoorSound.Stop();
                    DoorSound.Play();
                    StateOpen = false;
                }

                Door.transform.position = Vector3.MoveTowards(Door.transform.position, BlockPoint.transform.position, 3f * Time.deltaTime);
            }
        }
        
     
    }
 

    private void OnTriggerStay(Collider col)
    {
        if (Senser)
        {
            if (col.gameObject.CompareTag("Player") || col.gameObject.name=="CrabMon")
            {
                exist = true;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (Senser)
        {
            if (col.gameObject.CompareTag("Player") || col.gameObject.name == "CrabMon")
            {
                exist = false;
            }
        }
    }
}

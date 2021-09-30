using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_Door : MonoBehaviour
{
    public GameObject Btn;
    public GameObject Door;
    Renderer Btn_Color;
    public bool BlockDoor = true; //true ==  기존 닫혀있음 false == 기존 열려있음
    public bool doStop = true; //지금 하는 행동을 멈춰야할때 ex)천장이나 바닥에 충돌했을때
    Rigidbody rigid;
    Button BtnValue;
  
    // Start is called before the first frame update
    void Start()
    {
        Btn_Color = Btn.GetComponent<Renderer>();
        BtnValue = Btn.GetComponent<Button>();
        rigid = Door.GetComponent<Rigidbody>();
        rigid.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        
       
        
        if (BtnValue.canLock)
        {
            if (Btn_Color.material.color == Color.green && BlockDoor)
            {                
                rigid.constraints = RigidbodyConstraints.FreezeRotation;
                Door.transform.Translate(Vector3.down * 1f * Time.deltaTime);
            }
            else if (Btn_Color.material.color == Color.red && !BlockDoor)
            {
                rigid.constraints = RigidbodyConstraints.FreezeRotation;
                Door.transform.Translate(Vector3.up * 1f * Time.deltaTime);
            }
            else
            {
                rigid.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
        else
        {
            if (!doStop)
            {
                if (Btn_Color.material.color == Color.green && BlockDoor)
                {                    
                    rigid.constraints = RigidbodyConstraints.FreezeRotation;
                    Door.transform.Translate(Vector3.down * 1 * Time.deltaTime);
                }
                else if (Btn_Color.material.color == Color.red)
                {
                    rigid.constraints = RigidbodyConstraints.FreezeRotation;
                    Door.transform.Translate(Vector3.up * 1 * Time.deltaTime);
                }
            }
            else
            {
                if (Btn_Color.material.color == Color.green && BlockDoor)
                {
                    doStop = false;
                }
                else if (Btn_Color.material.color == Color.red && !BlockDoor)
                {
                    doStop = false;
                }

            }

        }
      
    }
   

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Door_Down"))
        {
            BlockDoor = false;
            doStop = true;
        }
        if (col.gameObject.CompareTag("Door_Up"))
        {
            BlockDoor = true;
            doStop = true;
        }
        else
        {
            doStop = false;
        }
       
    }  

}

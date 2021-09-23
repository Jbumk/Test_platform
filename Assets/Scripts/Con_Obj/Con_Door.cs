using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_Door : MonoBehaviour
{
    public GameObject Btn;
    public GameObject Door;
    Renderer Btn_Color;
    bool BlockDoor = true; //true == 문 닫혀있음 false == 문 열려있음
    Rigidbody rigid;
  
    // Start is called before the first frame update
    void Start()
    {
        Btn_Color = Btn.GetComponent<Renderer>();
        rigid = Door.GetComponent<Rigidbody>();
        rigid.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {

        if(Btn_Color.material.color == Color.green && BlockDoor )
        {
            rigid.constraints = RigidbodyConstraints.FreezeRotation;
            Door.transform.Translate(Vector3.down*1*Time.deltaTime);
        }
        else if(Btn_Color.material.color == Color.red && !BlockDoor)
        {
            rigid.constraints = RigidbodyConstraints.FreezeRotation;
            Door.transform.Translate(Vector3.up*1*Time.deltaTime);
        }
        else
        {
            rigid.constraints = RigidbodyConstraints.FreezeAll;
        }
      
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Door_Down"))
        {
            BlockDoor = false;
        }
        if(col.gameObject.CompareTag("Door_Up"))
        {
            BlockDoor = true;
        }
    }
}

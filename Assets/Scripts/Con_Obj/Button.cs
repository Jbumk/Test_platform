using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    Renderer BtnColor;
    public bool canLock=true; //true = 누르면 상태변경 false = 누르고 있을때만 활성화
    // Start is called before the first frame update
    void Start()
    {
        BtnColor = this.GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision col)
    {
        //플레이어 에게 닿았을때
        if (canLock)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                if (BtnColor.material.color != Color.red)
                {
                    BtnColor.material.color = Color.red;
                }
                else
                {
                    BtnColor.material.color = Color.green;
                }
            }
            else if(col.gameObject.CompareTag("CanGrab"))
            {
                if (BtnColor.material.color != Color.red)
                {
                    BtnColor.material.color = Color.red;
                }
                else
                {
                    BtnColor.material.color = Color.green;
                }
            }
        }        
    }

    private void OnCollisionStay(Collision col)
    {
        if (!canLock)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                BtnColor.material.color = Color.green;
            }
            else if (col.gameObject.CompareTag("CanGrab"))
            {
                BtnColor.material.color = Color.green;
            }
       }
    }

    private void OnCollisionExit(Collision col)
    {
        if (!canLock)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                BtnColor.material.color = Color.red;
            }
            else if (col.gameObject.CompareTag("CanGrab"))
            {
                BtnColor.material.color = Color.red;
            }
        }
    }
}

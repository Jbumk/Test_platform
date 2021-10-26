using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    Renderer BtnColor;
    public bool canLock=true; //true = 누르면 상태변경 false = 누르고 있을때만 활성화    
    public double OffTime=0; //켜졌다 꺼지는 시간 0으로 설정하면 비활성화
    float Timer = 0;
    private AudioSource BtnSound;
    // Start is called before the first frame update
    void Start()
    {
        BtnColor = GetComponent<Renderer>();
        BtnSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(BtnColor.material.color == Color.green)
        {
            if (OffTime != 0)
            {
                Timer += Time.deltaTime;
                if(Timer>= OffTime)
                {
                    Timer = 0;
                    BtnColor.material.color = Color.red;
                }
            }
        }else if (BtnColor.material.color == Color.red)
        {
            Timer = 0;
        }
       
    }

    private void OnCollisionEnter(Collision col)
    {
        //플레이어 에게 닿았을때
        if (canLock)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                BtnSound.Play();
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
                BtnSound.Play();
                if (BtnColor.material.color != Color.red)
                {
                    BtnColor.material.color = Color.red;
                }
                else
                {
                    BtnColor.material.color = Color.green;
                }
            }
            else if (col.gameObject.CompareTag("ElseObj"))
            {
                BtnSound.Play();
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
            if (BtnColor.material.color == Color.red)
            {
                if (col.gameObject.CompareTag("Player"))
                {                   
                    BtnColor.material.color = Color.green;
                }
                else if (col.gameObject.CompareTag("CanGrab"))
                {                    
                    BtnColor.material.color = Color.green;
                }
                else if (col.gameObject.CompareTag("ElseObj"))
                {                   
                    BtnColor.material.color = Color.green;
                }
                BtnSound.Play();
            }
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (!canLock)
        {
            if (BtnColor.material.color == Color.green)
            {
                if (col.gameObject.CompareTag("Player"))
                {                
                    BtnColor.material.color = Color.red;
                }
                else if (col.gameObject.CompareTag("CanGrab"))
                {                   
                    BtnColor.material.color = Color.red;
                }
                else if (col.gameObject.CompareTag("ElseObj"))
                {                    
                    BtnColor.material.color = Color.red;
                }
                BtnSound.Play();
            }
        }
    }
}

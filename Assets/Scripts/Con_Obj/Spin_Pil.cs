using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin_Pil : MonoBehaviour
{
    public GameObject Pillar;
    float Toc = 0;   
    public GameObject btn;
    public float SpinSpeed=30f;  //회전 속도 설정
    Renderer Btnrender;
    public string SpinAxis="y";
    //x면 x축기준,y,z 축 기준으로 회전한다


    /* private IEnumerator Test_Spin(float CoolTime, float Sp)
     {
         Toc += Time.deltaTime*Sp;
         Pillar.gameObject.transform.rotation = Quaternion.Euler(0, Toc, 0);
         yield return new WaitForSeconds(CoolTime);

     }*/
    private void Start()
    {
        if (btn != null)
        {
            Btnrender = btn.GetComponent<Renderer>();
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (btn == null)
        {                      
            Toc += Time.deltaTime * SpinSpeed;
            if (SpinAxis.Equals("x") || SpinAxis.Equals("X"))
            {
                Pillar.gameObject.transform.localRotation = Quaternion.Euler(Toc, 0, 0);
            }
            else if (SpinAxis.Equals("y") || SpinAxis.Equals("Y"))
            {
                Pillar.gameObject.transform.localRotation = Quaternion.Euler(0, Toc, 0);
            }
            else if (SpinAxis.Equals("z") || SpinAxis.Equals("Z"))
            {
                Pillar.gameObject.transform.localRotation = Quaternion.Euler(0, 0, Toc);
            }
           
        }
        else
        {
            if (Btnrender.material.color == Color.green)
            {                    
                Toc += Time.deltaTime * SpinSpeed;
                if (SpinAxis.Equals("x") || SpinAxis.Equals("X"))
                {
                    Pillar.gameObject.transform.localRotation = Quaternion.Euler(Toc, 0, 0);
                }
                else if (SpinAxis.Equals("y") || SpinAxis.Equals("Y"))
                {
                    Pillar.gameObject.transform.localRotation = Quaternion.Euler(0, Toc, 0);
                }
                else if (SpinAxis.Equals("z") || SpinAxis.Equals("Z"))
                {
                    Pillar.gameObject.transform.localRotation = Quaternion.Euler(0, 0, Toc);
                }

            }
        }
        
     
    }

   
}

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
            Pillar.gameObject.transform.rotation = Quaternion.Euler(0, Toc, 0);
        }
        else
        {
            if (Btnrender.material.color == Color.green)
            {
                //StartCoroutine(Test_Spin(SpinToc, SpinSpeed));
                Toc += Time.deltaTime * SpinSpeed;
                Pillar.gameObject.transform.rotation = Quaternion.Euler(0, Toc, 0);

            }
        }
        
     
    }

   
}

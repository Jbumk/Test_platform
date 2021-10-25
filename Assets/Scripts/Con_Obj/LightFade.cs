using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFade : MonoBehaviour
{    
    public Light[] Lights;
    public GameObject Btn;
    private Renderer Rend;
    private float Timer = 0f;
    private double CoolTime = 0.025;

    public float value = 0.01f;


    private void Start()
    {
        Rend = Btn.GetComponent<Renderer>();
    }

    private void Update()
    {

        Timer += Time.deltaTime;
        if (Rend.material.color == Color.green)
        {
            for (int i = 0; i < Lights.Length; i++)
            {
                Lights[i].color = Color.red;
            }

            if (Timer >= CoolTime)
            {
                for (int i = 0; i < Lights.Length; i++)
                {
                    Lights[i].intensity -= value;
                }

                if (Lights[0].intensity <= 0)
                {
                    value *= -1;
                }
                else if (Lights[0].intensity >= 5f)
                {
                    value *= -1;
                }
                Timer = 0;
            }
        }else
        {
            for (int i = 0; i < Lights.Length; i++)
            {
                Lights[i].color = Color.white;
                Lights[i].intensity = 3f;
            }
        }
    }

    /*
    private IEnumerator LightControl()
    {
        while (true)
        {
            for (int i = 0; i < Lights.Length; i++)
            {
                Lights[i].intensity -= value;
            }
            if (Lights[0].intensity <= 0)
            {
                value *= -1;
            }
            else if (Lights[0].intensity >= 5f)
            {
                value *= -1;
            }

            yield return new WaitForSeconds(0.025f);
        }

    }
    */
    
}

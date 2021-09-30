using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLight : MonoBehaviour
{
    public static bool haveLight= false;
    public Light handligh;
    public GameObject FirCam;
    public GameObject ThrCam;
    private bool isOn = false;

    private double CoolTIme = 0.5;
    private float Timer = 0;
    private Quaternion LightVec;



    private void Update()
    {
        if (haveLight)
        {
            Timer += Time.deltaTime;
            if (Timer >= CoolTIme)
            {
                if (Input.GetKey(KeyCode.G))
                {
                    if (isOn)
                    {
                        handligh.intensity = 0;
                        isOn = false;
                        Timer = 0;
                    }
                    else
                    {
                        handligh.intensity = 15;
                        isOn = true;
                        Timer = 0;
                    }
                }
            }

            if (Con_Camera.FirCamOn)
            {
                LightVec = FirCam.transform.rotation;
                LightVec.y = 0;
                LightVec.z = 0;
                transform.localRotation = LightVec;
            }
            else
            {
                LightVec = ThrCam.transform.rotation;
                LightVec.y = 0;
                LightVec.z = 0;
                transform.localRotation = LightVec;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Change : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool FirCamOn = true;
    public GameObject FirCam;
    public GameObject ThrCam;
    float timer;
    double wait;

    void Start()
    {
        timer = 0;
        wait = 0.5;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (FirCamOn == true) {
            if (Input.GetKey(KeyCode.F)&& timer>=wait)
            {
                timer = 0;
                FirCam.SetActive(false);
                ThrCam.SetActive(true);
                FirCamOn = false;               
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.F) &&timer>=wait)
            {
                timer = 0;
                FirCam.SetActive(true);
                ThrCam.SetActive(false);
                FirCamOn = true;               
            }
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour
{
    public static bool ObjReset = false;
    public static bool BtnReset = false;

    public void DoReset()
    {
        ObjReset = true;
        BtnReset = true;
    }
    private void Update()
    {
        if (UI_Manager.instance.getDead())
        {
            ObjReset = true;
            BtnReset = true;
        }
    }
}

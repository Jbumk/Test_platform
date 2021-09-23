using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_MovingPlat2 : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(null);
        }
    }
}

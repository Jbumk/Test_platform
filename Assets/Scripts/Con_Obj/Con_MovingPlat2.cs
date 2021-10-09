using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_MovingPlat2 : MonoBehaviour
{
    public bool isLock = false;
    Vector3 OriginVec = new Vector3(0, 0, 0);

    private void Update()
    {
        if (isLock)
        {
            transform.rotation =Quaternion.Euler(OriginVec);
        }
    }
   
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

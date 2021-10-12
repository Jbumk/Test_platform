using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject NextPoint;
   
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Consum_System.max_Pos = NextPoint.transform.position.y;
            col.transform.position = NextPoint.transform.position+ NextPoint.transform.forward*2f;
        }
    }
}

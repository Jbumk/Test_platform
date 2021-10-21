using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject NextPoint;
    Rigidbody rigid;
    float Power;
  
  

    private void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("TPElse"))
        {           
                if (NextPoint != null)
                {
                    rigid = col.GetComponent<Rigidbody>();                  
                    Power = Mathf.Abs(rigid.velocity.x) + Mathf.Abs(rigid.velocity.y) + Mathf.Abs(rigid.velocity.z);
                    if (col.gameObject.CompareTag("Player"))
                    {
                        Consum_System.max_Pos = NextPoint.transform.position.y;
                    }
                    rigid.velocity = Vector3.zero;
                    col.transform.position = NextPoint.transform.position + NextPoint.transform.forward * 2f;
                    rigid.AddForce(NextPoint.transform.forward * Power, ForceMode.Impulse);
                }                      
        }
       
      
       
        
        
        
    }
}

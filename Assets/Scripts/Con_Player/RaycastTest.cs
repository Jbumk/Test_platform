using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    // Start is called before the first frame update

    private RaycastHit hit;
 
  
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.up * -0.3f, Color.red);
        if (Physics.Raycast(transform.position,transform.up * -1,out hit,0.7f))
        {
            
            if (hit.transform.CompareTag("Ground")){
                Debug.Log("OnGround");
            }          
            
        }
        
    }
   
}

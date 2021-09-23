using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private bool isOpen = false;
    public static bool isDoing = false;

    public GameObject Open;
    public GameObject Close;

   

    Quaternion StartQuat;
    Quaternion EndQuat;
    private void Start()
    {
        StartQuat = Open.transform.rotation;
        EndQuat = Close.transform.rotation;
    }
    private void Update()
    {
        if (isDoing)
        {
            
            MoveDoor(StartQuat);
            
        }
    }

    //문 움직이기
    private void MoveDoor(Quaternion StartQuat)
    {       
        if (isOpen)
        {
            //transform.rotation = EndQuat;
            
           this.transform.rotation = Quaternion.Slerp(this.transform.rotation, EndQuat, 10f * Time.deltaTime);
            
            if (this.transform.rotation == EndQuat)
            {
                isOpen = false;
                isDoing = false;
            }
        }
        else
        {
            //transform.rotation = StartQuat;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, StartQuat, 10f * Time.deltaTime);
            

            if (this.transform.rotation == StartQuat)
            {
                isOpen = true;
                isDoing = false;
            }
        }
     
        
    }

    //회전각 받아오기

    
    public void Doing()
    {
        isDoing = true;
        Debug.Log("행동시작");
    }
   
  
    
   
}

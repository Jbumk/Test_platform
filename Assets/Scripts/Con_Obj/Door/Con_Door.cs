using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_Door : MonoBehaviour
{
    public GameObject Btn;   
    public GameObject BlockPoint;
    public GameObject OpenPoint;
    private Renderer Btn_Color;  
    private Button BtnValue;  
  

    private void Start()
    {
        Btn_Color = Btn.GetComponent<Renderer>();
        BtnValue = Btn.GetComponent<Button>();      
     
    }
   
    private void Update()
    {
        if (Btn_Color.material.color == Color.green)
        {
            transform.position = Vector3.MoveTowards(transform.position, OpenPoint.transform.position, 1f*Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, BlockPoint.transform.position, 1f*Time.deltaTime);
        }
     
    }
}

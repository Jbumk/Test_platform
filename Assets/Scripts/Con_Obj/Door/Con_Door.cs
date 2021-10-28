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
    private AudioSource DoorSound;

    private bool StateOpen = false;
  

    private void Start()
    {
        
        Btn_Color = Btn.GetComponent<Renderer>();
        BtnValue = Btn.GetComponent<Button>();
        DoorSound = GetComponent<AudioSource>();
     
    }
   
    private void Update()
    {
       
        if (Btn_Color.material.color == Color.green)
        {
            if (!StateOpen)
            {
                DoorSound.Stop();
                DoorSound.Play();
                StateOpen = true;
            }
          
            transform.position = Vector3.MoveTowards(transform.position, OpenPoint.transform.position, 3f*Time.deltaTime);
        }
        else
        {
            if (StateOpen)
            {
                DoorSound.Stop();
                DoorSound.Play();
                StateOpen = false;
            }

            transform.position = Vector3.MoveTowards(transform.position, BlockPoint.transform.position, 3f*Time.deltaTime);
        }
     
    }
}

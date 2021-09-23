using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_Pendulum : MonoBehaviour
{
    public float speed=30f;
    public GameObject Hinge;
    public GameObject LeftEnd;
    public GameObject RightEnd;
    public GameObject Button;
    private Renderer Btnrender;
    bool isGoingLeft;

    private void Start()
    {
        if (Button != null)
        {
            Btnrender = Button.GetComponent<Renderer>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Button == null)
        {
            if (isGoingLeft)
            {
                Hinge.transform.rotation = Quaternion.Slerp(Hinge.transform.rotation, LeftEnd.transform.rotation, speed * Time.deltaTime);
                if (Hinge.transform.rotation == LeftEnd.transform.rotation)
                {
                    isGoingLeft = false;
                }
            }
            else
            {
                Hinge.transform.rotation = Quaternion.Slerp(Hinge.transform.rotation, RightEnd.transform.rotation, speed * Time.deltaTime);
                if (Hinge.transform.rotation == RightEnd.transform.rotation)
                {
                    isGoingLeft = true;
                }
            }
        }
        else
        {
            if (Btnrender.material.color == Color.green)
            {
                if (isGoingLeft)
                {
                    Hinge.transform.rotation = Quaternion.Slerp(Hinge.transform.rotation, LeftEnd.transform.rotation, speed * Time.deltaTime);
                    if (Hinge.transform.rotation == LeftEnd.transform.rotation)
                    {
                        isGoingLeft = false;
                    }
                }
                else
                {
                    Hinge.transform.rotation = Quaternion.Slerp(Hinge.transform.rotation, RightEnd.transform.rotation, speed * Time.deltaTime);
                    if (Hinge.transform.rotation == RightEnd.transform.rotation)
                    {
                        isGoingLeft = true;
                    }
                }
            } 
        }
     
    }
}

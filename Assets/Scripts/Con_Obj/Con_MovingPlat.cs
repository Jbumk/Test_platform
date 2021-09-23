using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_MovingPlat : MonoBehaviour
{
    public GameObject[] MovePoints; //0은 원위치 1~ 이동하고 싶은 포인트까지 설정
    public GameObject Platform; //움직일 발판    

    public GameObject Button;
    private Renderer BtnRender;

    public float speed = 5f;//이동속도
    int i=1; //반복문용 변수

    private void Start()
    {
        if(Button != null)
        {
            BtnRender = Button.gameObject.GetComponent<Renderer>();
        }
    }
    private void Update()
    {
        if (Button == null)
        {
            if (Platform.transform.position == MovePoints[i].transform.position)
            {
                i++;
                if (i == MovePoints.Length)
                {
                    i = 0;
                }
            }
            else
            {
                Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, MovePoints[i].transform.position, Time.deltaTime * speed);
            }
        }
        else
        {
            if (BtnRender.material.color == Color.green)
            {
                if (Platform.transform.position == MovePoints[i].transform.position)
                {
                    i++;
                    if (i == MovePoints.Length)
                    {
                        i = 0;
                    }
                }
                else
                {
                    Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, MovePoints[i].transform.position, Time.deltaTime * speed);
                }
            }
        }
        
    }
  

}

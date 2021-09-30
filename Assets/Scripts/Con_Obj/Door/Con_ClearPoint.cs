using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_ClearPoint : MonoBehaviour
{
    public GameObject NextPoint;
    public GameObject NextStage;
    public GameObject PrevStage;

    

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {         
            NextStage.gameObject.SetActive(true);
            Consum_System.max_Pos = NextPoint.transform.position.y;
            col.transform.position = NextPoint.transform.position;           
            Chara_Main_Move.SavePoint();            
            PrevStage.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mon_Test : MonoBehaviour
{
    public static int Max_HP;
    public static int Now_HP;
    

    // Start is called before the first frame update
    void Start()
    {
        Max_HP = 100;
        Now_HP = Max_HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Now_HP == 0)
        {
           // UI_Manager.instance.alterEXP(10); 
            Destroy(this.gameObject);
            

        }
    }


    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Pattern"))
        {
            Now_HP -= 10;           
            Consum_Mon.UI_ON_Changer(Now_HP);   //UI 실행을 위한 함수   
          

        }
    }
}

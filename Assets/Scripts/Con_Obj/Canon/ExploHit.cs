using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploHit : MonoBehaviour
{
    Vector3 OriginVec;
    Vector3 PlayerVec;
    Vector3 ForceVec;
    private double CoolTime = 3;
    private float Timer = 0f;
    /*
    private GameObject Player;
    private Rigidbody  PlayerRigid;
    */


    private void Start()
    {
     
        //PlayerRigid = Player.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Timer += Time.deltaTime;
        
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //플레이어와 이 오브젝트의 position 이용해 방향벡터 구해서 해당방향으로 밀어냄
            OriginVec = transform.position;
            PlayerVec = col.transform.position;
            ForceVec = (PlayerVec - OriginVec).normalized;
            //PlayerRigid.AddForce(ForceVec * 10f, ForceMode.Impulse);
            //여기서 선언할지 player에서 감지?
            
            if (Timer > CoolTime)
            {
                UI_Manager.instance.alterHP(30);
            }
        }
    }
}

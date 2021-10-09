using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_Jumper : MonoBehaviour
{
    Vector3 ForceVec;
    public float JumpPower = 13f;

    private void Start()
    {
        ForceVec = transform.up;
    }
    

    private void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            Consum_System.fall_timer = 0;
            col.rigidbody.AddForce(ForceVec * JumpPower, ForceMode.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_Jumper : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Consum_System.fall_timer = 0;
            col.rigidbody.AddForce(Vector3.up * 13f, ForceMode.Impulse);
        }
    }
}

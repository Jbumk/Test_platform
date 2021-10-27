using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_Jumper : MonoBehaviour
{
    Vector3 ForceVec;
    public float JumpPower = 13f;
    private AudioSource JumpSound;


    private void Awake()
    {
        ForceVec = transform.up;
        JumpSound = GetComponent<AudioSource>();
    }
  

    private void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            JumpSound.Play();
            Consum_System.max_Pos = col.transform.position.y;
            Consum_System.fall_timer = 0;
            col.rigidbody.AddForce(ForceVec * JumpPower, ForceMode.Impulse);
        }
    }
}

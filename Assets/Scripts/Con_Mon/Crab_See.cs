using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_See : MonoBehaviour
{
    private int laymask = 1 << 9;
    private Vector3 Dir;
    private RaycastHit hit;
    public GameObject Eyes;
    

    private void Start()
    {
        laymask = ~laymask;
    }
 
    private void OnTriggerStay(Collider col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            Dir = col.transform.position - Eyes.transform.position;
            Dir.y += 1.5f;
            Debug.DrawRay(Eyes.transform.position, Dir, Color.red);

            if (Physics.Raycast(Eyes.transform.position, Dir, out hit, 30f, laymask))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    Crab_Act.See_Player = true;
                }
                else
                {
                    Crab_Act.See_Player = false;
                }
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Crab_Act.See_Player = false;
        }
    }
}

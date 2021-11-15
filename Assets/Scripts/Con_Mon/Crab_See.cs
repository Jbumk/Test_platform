using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_See : MonoBehaviour
{
    private int laymask = 1 << 9;
    private Vector3 Dir;
    private RaycastHit hit;
    public GameObject Eyes;

    private bool Miss = false;
    private double SeeEnd = 1.0;
    private float Timer = 0;

    private void Start()
    {
        laymask = ~laymask;
    }

    private void Update()
    {
        if (Miss)
        {
            Timer += Time.deltaTime;
        }
       

        if(Timer>= SeeEnd)
        {
            Crab_Act.instance.MissPlayer();
            Miss = false;
            Timer = 0;
        }
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
                    Crab_Act.instance.SeePlayer();
                }
                else
                {
                    Miss = true;
                    //Crab_Act.instance.MissPlayer();
                }
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Miss = true;
            //Crab_Act.instance.MissPlayer();
        }
    }
}

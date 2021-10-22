using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger3_5 : MonoBehaviour
{
    public GameObject Wall;
    public GameObject MovWall;
    public GameObject Btn;
    public GameObject OriginVec;
    private Renderer Rend;

    private void Start()
    {
        Rend = Btn.GetComponent<Renderer>();
    }
    private void Update()
    {
        if (UI_Manager.instance.getDead())
        {            
            Wall.transform.position = OriginVec.transform.position;
            MovWall.transform.position = OriginVec.transform.position;
            Rend.material.color = Color.red;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (!UI_Manager.instance.getDead())
        {
            if (col.gameObject.CompareTag("Player"))
            {
                Rend.material.color = Color.green;
                Wall.transform.position = transform.position + transform.right * 3f;
            }
        }
    }
}

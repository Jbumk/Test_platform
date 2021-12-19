using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Key : MonoBehaviour
{
    public Vector3[] Spawn_Spot;
    public GameObject Key;
    private int Count = 0;
    
   
    private void OnTriggerStay(Collider col)
    {        
        if (col.gameObject.name == "KeyPoint")
        {          
            
            Spawn_Spot[Count] = col.gameObject.transform.position;
            col.gameObject.name = "KeyPoint " + Count;
            Count++;
        }

        if (Count == Spawn_Spot.Length)
        {
            Key.transform.position= Spawn_Spot[Random.Range(0,Spawn_Spot.Length)];
            Count++;
        }

    }

}

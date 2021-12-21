using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointArcv : MonoBehaviour
{
    public Vector3[] WayPoints;

    private bool ExistPlayer = false;   
    private int Count = 0;


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ExistPlayer = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ExistPlayer = false;
        }
    }


    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "WayPoint" && Count!= WayPoints.Length)
        {
            WayPoints[Count] = col.gameObject.transform.position;
            col.gameObject.name = "WayPoint " + Count;
            Count++;
        }

    }

    public Vector3 GetWayPoint()
    {
        Debug.Log("WayPoint값 보내줌");
        return WayPoints[Random.Range(0, Count)];
    }

    public bool GetExistPlayer()
    {
        return ExistPlayer;
    }
    
}

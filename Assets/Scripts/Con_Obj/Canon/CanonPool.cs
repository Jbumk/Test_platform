using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonPool : MonoBehaviour
{
   public static CanonPool instance;
   public GameObject CanonBallPrefab;   
   public int Ballcount=5;

    Queue<CanonBall> poolingObjQueue = new Queue<CanonBall>();

    private void Awake()
    {
        instance = this;
        Initialize(Ballcount);

    }
    
    private void Initialize(int count)
    {
        for(int i=0; i < count; i++)
        {
            poolingObjQueue.Enqueue(CreateNewObj());
        }
    }
    private CanonBall CreateNewObj()
    {
        var newObj = Instantiate(CanonBallPrefab).GetComponent<CanonBall>();
        newObj.transform.SetParent(transform);
        newObj.gameObject.SetActive(false);

        return newObj;
    }

    public static CanonBall GetObj()
    {
        if (instance.poolingObjQueue.Count > 0)
        {
            var obj = instance.poolingObjQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);

            return obj;
        }
        else
        {
            var newobj = instance.CreateNewObj();
            newobj.transform.SetParent(null);
            newobj.gameObject.SetActive(true);
            return newobj;
        }
    }

    public static void returnObj(CanonBall obj)
    {        
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(instance.transform);        
        instance.poolingObjQueue.Enqueue(obj);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//공격 objectpool 스크립트
public class atkpool : MonoBehaviour
{
    public static atkpool instance;

    public GameObject atkPrefab;

    Queue<atk> poolingObjQueue = new Queue<atk>();

    private void Awake()
    {
        instance = this;
        Initialize(5);
    }
    // Start is called before the first frame update

    private void Initialize(int count)
    {
        for(int i =0; i < count; i++)
        {
            poolingObjQueue.Enqueue(CreateNewObj());
        }
    }

    private atk CreateNewObj()
    {
        var newObj = Instantiate(atkPrefab).GetComponent<atk>();
        newObj.transform.SetParent(transform);
        newObj.gameObject.SetActive(false);

        return newObj;
    }

    public static atk GetObj()
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
            return null;
        }
       
    }

    public static void ReturnObj(atk obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(instance.transform);
        instance.poolingObjQueue.Enqueue(obj);
    }

  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPool : MonoBehaviour
{
    public static ExplosionPool instance;
    public GameObject ExplosionPrefab;
    public int ExploCount=10;

    Queue<Explosion> ExplosionsQueue = new Queue<Explosion>();


    private void Awake()
    {
        instance = this;
        Initalize(ExploCount);
    }
    private void Initalize(int count)
    {
        for(int i=0; i < count; i++)
        {
            ExplosionsQueue.Enqueue(CreateNewObj());
        }

    }
    
    private Explosion CreateNewObj()
    {
        var NewObj = Instantiate(ExplosionPrefab).GetComponent<Explosion>();
        NewObj.transform.SetParent(transform);
        NewObj.gameObject.SetActive(false);

        return NewObj;        
    }

    public Explosion GetObj()
    {
        if (instance.ExplosionsQueue.Count > 0) {
            var obj = instance.ExplosionsQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);

            return obj;
        }
        else
        {
            var newObj = CreateNewObj();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);

            return newObj;
        }
    }

    public static void ReturnObj(Explosion obj)
    {
        obj.transform.SetParent(instance.transform);
        obj.gameObject.SetActive(false);
        instance.ExplosionsQueue.Enqueue(obj);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public void Explo()
    {
        Invoke("ReturnObj", 0.8f);
    }

    public void ReturnObj()
    {
        ExplosionPool.ReturnObj(this);
    }

}

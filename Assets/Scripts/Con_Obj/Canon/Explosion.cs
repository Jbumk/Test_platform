using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public void Explo()
    {
        Invoke("ReturnObj", 3f);
    }

    public void ReturnObj()
    {
        ExplosionPool.ReturnObj(this);
    }


}

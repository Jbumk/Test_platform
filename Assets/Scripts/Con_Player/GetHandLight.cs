using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHandLight : MonoBehaviour
{
    public GameObject UselessLight;

    private void OnTriggerEnter(Collider col)
    {
        HandLight.haveLight = true;
        UselessLight.gameObject.SetActive(false);
        gameObject.SetActive(false);

    }
}

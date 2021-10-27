using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnTrigger : MonoBehaviour
{
    public Renderer BtnRend;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            BtnRend.material.color = Color.green;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear3_4 : MonoBehaviour
{
    public GameObject Btn;
    public GameObject Window;

    private Button BtnGeneric;
    private Renderer Rend;

    private void Start()
    {
        BtnGeneric = Btn.GetComponent<Button>();
        Rend = Btn.GetComponent<Renderer>();
    }

    public void Update()
    {
        if (ResetManager.ObjReset)
        {          
            Window.gameObject.SetActive(false);
            BtnGeneric.OffTime = 5;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            BtnGeneric.OffTime = 0;
            Rend.material.color = Color.green;
            Window.gameObject.SetActive(true);
        }
        
    }
}

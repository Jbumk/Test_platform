using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_Circle : MonoBehaviour
{
    Renderer Circle_Color;
    // Start is called before the first frame update
    void Start()
    {
        Circle_Color = this.gameObject.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider col)
    {
        
        if (Circle_Color.material.color != Color.red)
        {   
            if (col.gameObject.CompareTag("Player"))
            {
                UI_Manager.instance.alterHP(-UI_Manager.instance.getMaxHP());
                UI_Manager.instance.alterMP(-UI_Manager.instance.getMaxMP());
                Game_Manager.instance.SaveRevivePoint(this.transform.position);
                Circle_Color.material.color = Color.red;
            }
        }
        
    }
}

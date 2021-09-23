using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    private static Game_Manager m_inst;

    public static Game_Manager instance
    {
        get
        {
            if (m_inst == null)
            {
                m_inst = FindObjectOfType<Game_Manager>();
            }
            return m_inst;
        }

       
    }
    Vector3 RevivePoint = new Vector3(0, 3, 0);
    public GameObject Player;

    public void SaveRevivePoint(Vector3 pos)
    {
        RevivePoint = pos;
    }

    public void Revive()
    {
        Player.transform.position = RevivePoint;
        Player.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));  
    }
}

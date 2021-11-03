using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static bool onMenu = false;
    public GameObject MenuScn;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!UI_Manager.instance.getDead())
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !onMenu)
            {
                MenuScn.gameObject.SetActive(true);
                onMenu = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0.0f;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && onMenu)
            {
                MenuScn.gameObject.SetActive(false);
                onMenu = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
            }
        }
        else
        {
            MenuScn.gameObject.SetActive(false);
            onMenu = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

    }

    public void ResumeGame()
    {
        MenuScn.gameObject.SetActive(false);
        onMenu = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}

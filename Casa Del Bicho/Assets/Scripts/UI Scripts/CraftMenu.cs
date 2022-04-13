using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject MenuUI, CraftUI, GatherUI;
    public GameObject CamController;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)){
            if(!GamePaused){
                Pause();
            }
            else if(GamePaused){
                Resume();
            }
        }
    }
    public void Resume(){
        MenuUI.SetActive(false);
        CamController.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Pause(){
        MenuUI.SetActive(true);
        CamController.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void GoToGatherScreen(){
        CraftUI.SetActive(false);
        GatherUI.SetActive(true);
    }

    public void GoToCraftScreen(){
        GatherUI.SetActive(false);
        CraftUI.SetActive(true);
    }
}

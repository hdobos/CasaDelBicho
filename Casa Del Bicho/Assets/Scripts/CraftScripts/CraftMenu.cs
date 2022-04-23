using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject MenuUI;//, CraftUI, GatherUI;
    public GameObject CamController, pauseMenu;
    public PauseMenu p;
    public GameObject crossHatch;

    void Start()
    {
       p = pauseMenu.GetComponent<PauseMenu>();
    }
    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.I) && !p.IsGamePaused()){
            if(!Paused){
                Pause();
            }
            else if(Paused){
                Resume();
               }
        }
        
    }
    private void Resume(){
        MenuUI.SetActive(false);
        CamController.GetComponent<FirstPersonLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        crossHatch.SetActive(true);
        
        Time.timeScale = 1f;
        Paused = false;
    }

    private void Pause(){
        MenuUI.SetActive(true);
        CamController.GetComponent<FirstPersonLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        crossHatch.SetActive(false);

        Time.timeScale = 0f;
        Paused = true;
    }

    // public void GoToGatherScreen(){
    //     CraftUI.SetActive(false);
    //     GatherUI.SetActive(true);
    // }

    // public void GoToCraftScreen(){
    //     GatherUI.SetActive(false);
    //     CraftUI.SetActive(true);
    // }
}

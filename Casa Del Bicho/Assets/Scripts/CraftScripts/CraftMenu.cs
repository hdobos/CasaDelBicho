using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject MenuUI, CraftUI, GatherUI;
    public GameObject CamController, pauseMenu;
    public PauseMenu p;

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
        CamController.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        
        Time.timeScale = 1f;
        Paused = false;
    }

    private void Pause(){
        MenuUI.SetActive(true);
        CamController.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
        Paused = true;
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

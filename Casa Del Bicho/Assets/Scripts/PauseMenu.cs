using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject CamController;
    public GameObject crossHatch;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(!GamePaused){
                Pause();
            }
            else if(GamePaused){
                Resume();
            }
        }
    }

    private void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        CamController.GetComponent<FirstPersonLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        crossHatch.SetActive(true);

        GamePaused = false;
    }

    private void Pause(){
        pauseMenuUI.SetActive(true);
        CamController.GetComponent<FirstPersonLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        crossHatch.SetActive(false);

        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void QuitGame(){
        Application.Quit();
    }

    public bool IsGamePaused(){
        return GamePaused;
    }
}

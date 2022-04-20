using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenuButtons : MonoBehaviour
{

    public string gameStartScene;

    public void PlayGame()
    {
        SceneManager.LoadScene(gameStartScene);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GoToTitleScene(){
        SceneManager.LoadScene("TitleScene");
    }
    public void GoToGardenScene(){
        SceneManager.LoadScene("GardenScene");
    }
    public void GoToForestScene(){
        SceneManager.LoadScene("ForestScene");
    }
    public void GoToVillageScene(){
        SceneManager.LoadScene("VillageScene");
    }
}

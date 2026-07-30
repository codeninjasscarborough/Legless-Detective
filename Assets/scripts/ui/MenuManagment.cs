using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagment : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject LevelSelect;
    public GameObject Credits;


    public void SwitchtoLevelSelect()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(false);
        LevelSelect.SetActive(true);
  
    }

    public void SwitchtoCredit()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
        LevelSelect.SetActive(false);
        
    }

    public void loadLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }
    public void backToMain(string levelname)
    {
        MainMenu.SetActive(true);
        Credits.SetActive(false);
        LevelSelect.SetActive(false);
    }
}
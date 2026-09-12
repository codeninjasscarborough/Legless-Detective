using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagment : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject LevelSelect;
    public GameObject Credits;

    private string sceneToLoad;

    public CanvasGroup[] screens;

    public void SwitchtoMain()
    {
        disableGroups();
        enablegroup(1);
    }

    public void SwitchToInstruction()
    {
        disableGroups();
        enablegroup(2);
    }

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

    public void startGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void loadLevel(string levelname)
    {
        sceneToLoad = levelname;
        SwitchToInstruction();
    }
    public void backToMain(string levelname)
    {
        MainMenu.SetActive(true);
        Credits.SetActive(false);
        LevelSelect.SetActive(false);
    }

    private void disableGroups()
    {
        foreach (var group in screens)
        {
            group.alpha = 0;
            group.interactable = false;
            group.blocksRaycasts = false;
        }
    }

    private void enablegroup(int index)
    {
        screens[index].alpha = 1;
        screens[index].interactable = true;
        screens[index].blocksRaycasts = true;
    }

    public void ExitGame() 
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
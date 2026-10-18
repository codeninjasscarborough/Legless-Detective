using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagment : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject LevelSelect;
    public GameObject Setting;
    public GameObject Credits;

    private string sceneToLoad;

    public CanvasGroup[] screens;

    public void SwitchtoIntro()
    {
        disableGroups();
        enablegroup(1);
    }

    public void SwitchToMain()
    {
        disableGroups();
        enablegroup(2);
    }
    public void SwitchToInstruction()
    {
        disableGroups();
        enablegroup(3);
    }
    public void SwitchtoLevelSelect()
    {
        MainMenu.SetActive(false);
        Setting.SetActive(false);
        Credits.SetActive(false);
        LevelSelect.SetActive(true);
  
    }

    public void SwitchToSettings()
    {
        MainMenu.SetActive(false);
        Setting.SetActive(true);
        Credits.SetActive(false);
        LevelSelect.SetActive(false);

    }

    public void SwitchtoCredit()
    {
        MainMenu.SetActive(false);
        Setting.SetActive(false);
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
    public void backToMain()
    {
        MainMenu.SetActive(true);
        Setting.SetActive(false);
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

    public void SetVolume(Slider slider)
    {
        PlayerPrefs.SetFloat("Volume", slider.value);
        foreach(var audioSource in GameObject.FindObjectsOfType<AudioSource>())
        {
            audioSource.volume = slider.value;
        }
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
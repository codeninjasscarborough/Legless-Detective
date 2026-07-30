using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;
    private int suspectIndex;
    public SuspectData[] suspectlist;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        suspectIndex = Random.Range(0, suspectlist.Length);

    }

    public void SelectSuspect(int index)
    {
        if (Checksuspect(index))
        {
            // suspect chose correctly
            Debug.Log("You Win");
            SceneManager.LoadScene(4);
        }
        else
        {
            // suspect wrong
            Debug.Log("You Lose it was guy " + suspectIndex + " but we chose " + index);
            SceneManager.LoadScene(5);
        }
    }

    public bool Checksuspect(int index)
    {
        return suspectIndex == index;
    }  

    public SuspectData GetSuspect()
    {
        return suspectlist[suspectIndex];
    }

    public SuspectData GetSuspect(int idx)
    {
        return suspectlist[idx];
    }
}

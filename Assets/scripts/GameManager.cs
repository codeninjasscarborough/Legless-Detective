using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
        else
        {
            // suspect wrong
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileMangement : MonoBehaviour
{
    public GameObject Checklist;
    public GameObject Suspects;

    public void SwitchtoSuspect()
    {
        Checklist.SetActive(false);
        Suspects.SetActive(true);
    }


}

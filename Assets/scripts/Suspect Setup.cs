using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SuspectSetup : MonoBehaviour
{
    private Button[] suspectList;
    private TMP_Text suspectName;
    private TMP_Text suspectHints;

    private void Awake()
    {
        suspectList = GetComponentsInChildren<Button> ();
        
        // go thru buttons
        for (int i = 0; i < suspectList.Length; i++)
        {
            // get suspect's hints
            suspectName = suspectList[i].transform.GetChild(0).GetComponent<TMP_Text>();
            suspectHints = suspectList[i].transform.GetChild(1).GetComponent<TMP_Text>();
            var suspect = GameManger.instance.GetSuspect(i);
            suspectName.text = suspect.name;

            suspectHints.text = "Hints: \n";
            for (int j = 0; j < 3; j++)
            {
                int hintIdx = suspect.hints[j];
                suspectHints.text += HintNames.HintName[hintIdx] + "\n";
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class showsuspect : MonoBehaviour
{
    public SelectedSuspect suspect;
    public TMP_Text name;
    public TMP_Text hints;

    // Start is called before the first frame update
    void Start()
    {
        name.text = suspect.suspect.name;
        hints.text = "";
        for(int i = 0; i < 3; i++)
            hints.text += HintNames.HintName[suspect.suspect.hints[i]] +"\n";
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilePopup : MonoBehaviour
{
    public GameObject filePanel;
    public KeyCode openKey = KeyCode.F;

    public List<Button> susBtns;

    private void Start()
    {
        if(susBtns.Count > 0)   
        for(int i = 0; i < susBtns.Count; i++)
        {
            susBtns[i].onClick.AddListener(() => GetComponent<GameManger>().SelectSuspect(i));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(openKey))
        {
            bool isPanelActive = filePanel.activeSelf;
            filePanel.SetActive(!isPanelActive);
            if (!isPanelActive) 
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}

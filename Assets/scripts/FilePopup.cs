using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilePopup : MonoBehaviour
{
    public GameObject filePanel;
    public KeyCode openKey = KeyCode.F;

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

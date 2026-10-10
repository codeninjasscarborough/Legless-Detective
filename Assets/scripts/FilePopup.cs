using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilePopup : MonoBehaviour
{
    public GameObject filePanel;
    public Transform suspectListObject;
    public KeyCode openKey = KeyCode.F;

    public List<Button> susBtns = new();

    private void Start()
    {
        if(susBtns.Count == 0)
        {
            foreach(Transform btn in suspectListObject)
            {
                susBtns.Add(btn.GetComponent<Button>());
            }
        }   

        for(int i = 0; i < susBtns.Count; i++)
        {
            int susNum = i;
            susBtns[i].onClick.AddListener(() => GetComponent<GameManager>().SelectSuspect(susNum));
        }

        filePanel.SetActive(false);
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

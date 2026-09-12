using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnotherScene : MonoBehaviour
{
    public void loadLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }
}

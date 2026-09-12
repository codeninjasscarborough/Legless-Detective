using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{
    public GameObject instructions;
    public void SwitchToStartGame()
    {
        instructions.SetActive(false);
    }
}

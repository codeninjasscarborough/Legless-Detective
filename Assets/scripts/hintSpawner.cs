using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintSpawner : MonoBehaviour
{
    public GameObject[] hint;
    public Transform[] locations;

    private SuspectData suspect;

    public HashSet<int> chosenIndexes = new();

    private void Awake()
    {
        if(locations.Length == 0)
        locations = transform.GetComponentsInChildren<Transform>();
    }

    private void Start()
    {
        suspect = GameManger.instance.GetSuspect();
        for (int i = 0; i < suspect.hints.Length; i++)
        {
            int hintIndex = suspect.hints[i];
            
                Instantiate(hint[hintIndex], locations[Random.Range(0, locations.Length)].position, hint[hintIndex].transform.rotation);
            
        }
    }
}

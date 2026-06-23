using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "suspect", menuName = "suspect/create new suspect")]
public class SuspectData : ScriptableObject
{
    public string suspectName;
    public int[] hints;
}

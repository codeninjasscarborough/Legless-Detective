using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class hintEffect : MonoBehaviour
{
    private ParticleSystem particaleEffect;

    private void Start()
    {
        particaleEffect = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hint"))
        {
            Debug.Log("partical should play");
            particaleEffect.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hint"))
        {
            particaleEffect.Stop();
            
        }
    }
}

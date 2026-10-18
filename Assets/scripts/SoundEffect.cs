using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("volume", 1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hint"))
        {
            Debug.Log("Soundeffect should play");
            audioSource.Play();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hint"))
        {
            audioSource.Stop();

        }
    }
}

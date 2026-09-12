using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] // Automatically adds AudioSource
public class MusicPlaylist : MonoBehaviour
{
    [Header("Playlist Settings")]
    [Tooltip("Add your audio tracks here in order.")]
    public AudioClip[] playlist;

    private AudioSource audioSource;
    private int currentTrackIndex = 0;
    private Coroutine playlistCoroutine;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false; // Prevents initial clashes

        if (playlist.Length > 0)
        {
            playlistCoroutine = StartCoroutine(PlaylistLoop());
        }
    }

    IEnumerator PlaylistLoop()
    {
        while (playlist.Length > 0)
        {
            // Set and play the clip
            audioSource.clip = playlist[currentTrackIndex];
            audioSource.Play();

            // Wait a fraction of a second to let the clip actually start loading/playing
            yield return new WaitForSeconds(0.1f);

            // Wait until the current song completely finishes playing
            yield return new WaitWhile(() => audioSource.isPlaying);

            // Advance to the next track index safely
            currentTrackIndex = (currentTrackIndex + 1) % playlist.Length;
        }
    }
}

using UnityEngine;

public class MGCCC_AudioManager : MonoBehaviour
{
    // Singleton instance of the AudioManager
    public static MGCCC_AudioManager Instance { get; private set; }

    // Reference to the AudioSource component for background music
    public AudioSource backgroundMusic;

    private void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persistent across scenes
        } else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }
    }

    private void Start()
    {
        // Start playing the background music if it's assigned and not already playing
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.loop = true; // Ensure the music loops
            backgroundMusic.Play();
        }
    }

    // Method to play the background music
    public void PlayMusic()
    {
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }

    // Method to stop the background music
    public void StopMusic()
    {
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }
    }

    // Method to adjust the volume of the background music
    public void SetVolume(float volume)
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = Mathf.Clamp(volume, 0f, 1f); // Clamp volume between 0 and 1
        }
    }
}

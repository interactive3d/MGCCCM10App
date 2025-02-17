using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance { get; private set; }

    private AudioSource musicSource;
    private AudioSource sfxSource;

    private float musicVolume = 1.0f;
    private float sfxVolume = 1.0f;
    private bool isMusicMuted = false;
    private bool isSfxMuted = false;

    [SerializeField] private AudioClip defaultBackgroundMusic;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
            return;
        }

        // Initialize AudioSources
        musicSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        musicSource.loop = true;
        musicSource.playOnAwake = false;

        sfxSource.loop = false;
        sfxSource.playOnAwake = false;

        if (defaultBackgroundMusic != null) {
            PlayBackgroundMusic(defaultBackgroundMusic);
        }
    }

    // Play sound effect
    public void PlaySound(AudioClip clip) {
        if (clip == null || isSfxMuted) return;
        sfxSource.PlayOneShot(clip, sfxVolume);
    }

    // Play background music
    public void PlayBackgroundMusic(AudioClip musicClip) {
        if (musicClip == null) return;
        musicSource.clip = musicClip;
        musicSource.volume = isMusicMuted ? 0 : musicVolume;
        musicSource.Play();
    }

    // Stop background music
    public void StopBackgroundMusic() {
        musicSource.Stop();
    }

    // Set music volume (0 to 1)
    public void SetMusicVolume(float volume) {
        musicVolume = Mathf.Clamp01(volume);
        musicSource.volume = isMusicMuted ? 0 : musicVolume;
    }

    // Set sound effects volume (0 to 1)
    public void SetSFXVolume(float volume) {
        sfxVolume = Mathf.Clamp01(volume);
    }

    // Mute/unmute music
    public void ToggleMusicMute() {
        isMusicMuted = !isMusicMuted;
        musicSource.volume = isMusicMuted ? 0 : musicVolume;
    }

    // Mute/unmute sound effects
    public void ToggleSFXMute() {
        isSfxMuted = !isSfxMuted;
    }

    // Check if music is muted
    public bool IsMusicMuted() => isMusicMuted;

    // Check if SFX is muted
    public bool IsSFXMuted() => isSfxMuted;
}

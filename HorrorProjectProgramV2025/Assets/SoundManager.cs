using UnityEngine;

namespace Game.Audio
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance; // Singleton Instance

        [Header("Audio Sources")]
        public AudioSource musicSource; // For background music
        public AudioSource sfxSource;   // For sound effects

        [Header("Audio Settings")]
        [Range(0f, 1f)] public float musicVolume = 1f;
        [Range(0f, 1f)] public float sfxVolume = 1f;

        private void Awake()
        {
            // Ensure only one instance exists (Singleton Pattern)
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // Persist through scenes
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Play background music.
        /// </summary>
        /// <param name="musicClip">The music clip to play.</param>
        public void PlayMusic(AudioClip musicClip)
        {
            if (musicSource.clip == musicClip) return; // Avoid replaying the same clip
            musicSource.clip = musicClip;
            musicSource.volume = musicVolume;
            musicSource.loop = true;
            musicSource.Play();
        }

        /// <summary>
        /// Play a sound effect.
        /// </summary>
        /// <param name="sfxClip">The sound effect clip to play.</param>
        public void PlaySFX(AudioClip sfxClip)
        {
            sfxSource.PlayOneShot(sfxClip, sfxVolume);
        }

        /// <summary>
        /// Set the volume for background music.
        /// </summary>
        /// <param name="volume">New volume (0 to 1).</param>
        public void SetMusicVolume(float volume)
        {
            musicVolume = Mathf.Clamp01(volume);
            musicSource.volume = musicVolume;
        }

        /// <summary>
        /// Set the volume for sound effects.
        /// </summary>
        /// <param name="volume">New volume (0 to 1).</param>
        public void SetSFXVolume(float volume)
        {
            sfxVolume = Mathf.Clamp01(volume);
        }

        /// <summary>
        /// Stop the current background music.
        /// </summary>
        public void StopMusic()
        {
            musicSource.Stop();
        }
    }
}

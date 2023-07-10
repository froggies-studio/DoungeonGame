using _Scripts.Helpers;
using UnityEngine;

namespace _Scripts.Systems
{
    public class AudioSystem : Singleton<AudioSystem>
    {
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource soundsSource;

        public void PlayMusic(AudioClip clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }

        public void PlaySound(AudioClip clip, Vector3 position, float volume = 1)
        {
            soundsSource.transform.position = position;
            PlaySound(clip, volume);
        }

        public void PlaySound(AudioClip clip, float volume = 1f)
        {
            soundsSource.PlayOneShot(clip, volume);
        }
    }
}
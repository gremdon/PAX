using UnityEngine;
using System.Collections;

public class AmbientAudio : MonoBehaviour
{
    public AudioSource backgroundAudioSource;
    public AudioClip backgroundSound;

    void Awake()
    {
        // Background AudioSource = GetComp AudioSource
        // AudioManager.audioSource = AudioSource backgroundAudioSource;
        // AudioManager.AmbientSound(AudioClip) audio clip that is passed in
        backgroundAudioSource = GetComponent<AudioSource>();
        AudioManager.audioSource = backgroundAudioSource;
        AudioManager.AmbientSound(backgroundSound);
    }

}

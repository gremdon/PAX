using UnityEngine;
using System.Collections;

public class AmbientAudio : MonoBehaviour
{
    public AudioSource backgroundAudioSource;
    public AudioClip backgroundSound;

    void Awake()
    {
        backgroundAudioSource = GetComponent<AudioSource>();
        Audio.audioManager = backgroundAudioSource;
        Audio.AmbientSound(backgroundSound);
    }

}

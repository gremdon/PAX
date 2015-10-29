using UnityEngine;
using System.Collections;

public class test_audio : MonoBehaviour
{
    /// <summary>
    /// Tran & Chui's test Audio script.
    /// </summary>

    
    public AudioSource audioSource;
    
    public AudioClip sound;
    public string audioEvent;
    
    public string argument;
    public bool sound3D;

    void Awake()
    {
        
        audioSource = GetComponent<AudioSource>();
        sound = audioSource.clip;
        argument = sound.ToString();
        string newstring = argument.Replace(" (UnityEngine.AudioClip)", "");
        argument = newstring;
        
        Audio.audioManager = audioSource;
        Audio.AddAudio(argument, sound);
        Audio.AudioListener(audioEvent, sound3D);


    }
    void Start()
    {
    }
}

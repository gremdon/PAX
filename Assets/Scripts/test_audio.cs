using UnityEngine;
using System.Collections;

public class test_audio : MonoBehaviour
{
    /// <summary>
    /// Tran & Chui's test Audio script.
    /// </summary>

    public AudioSource manager;
    public AudioClip music;
    public string broadcastMessge;
    public string argument;
    public bool ThreeDSound;

    void Start()
    {
        ThreeDAudio.manager = manager;
        Audio.AddAudio(argument, music);
        Audio.AudioListener(broadcastMessge, ThreeDSound);
    }
}

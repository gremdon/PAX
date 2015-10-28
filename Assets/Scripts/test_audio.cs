using UnityEngine;
using System.Collections;

public class test_audio : MonoBehaviour
{
    /// <summary>
    /// Tran & Chui's test Audio script.
    /// </summary>

    public AudioSource manager;
    public AudioClip death;
    public AudioClip music;
    public AudioClip threeSound;

    void Start()
    {
        Audio.audioManager = manager;
        ThreeDAudio.manager = manager;

        Audio.AddAudio("Player1", death);
        Audio.AddAudio("Player2", music);

        Audio.AudioListener("takeDamage", false);
        Audio.AudioListener("takeHealth", true);
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        Messenger.Broadcast<string>("takeDamage", "Player1");
    //    }

    //    if (Input.GetKeyDown(KeyCode.T))
    //    {
    //        Messenger.Broadcast<string>("takeHealth", "Player2");
    //    }
    //}
}

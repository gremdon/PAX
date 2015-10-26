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

        ThreeDAudio.threeDAudio(threeSound);

        Audio.AddAudio("Player1", death);
        Audio.AddAudio("Player2", music);

        Audio.AudioListener("takeDamage");
        Audio.AudioListener("takeHealth");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Messenger.Broadcast<string>("takeDamage", "Player1");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Messenger.Broadcast<string>("takeHealth", "Player2");
        }
    }

}

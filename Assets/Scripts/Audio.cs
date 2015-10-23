using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Tran and Paul audio file!
/// Tran did all of the audio script.
/// While Paul is looking into 3D settings.
/// </summary>
public class Audio
{
    /// <summary>
    /// A base audio for everyone to play the audio.
    /// A dictionary to add the audio
    /// </summary>
    public AudioSource audioManager;
    Dictionary<string, AudioClip> audioTable = new Dictionary<string, AudioClip>();

    /// <summary>
    /// Adds audio, checks to see if the same message is in the dictionary, if not, adds it in.
    /// </summary>
    /// <param string ="argument"></param>
    /// <param AudioClip ="audioclip"></param>
    public void AddAudio(string argument, AudioClip audioclip)
    {
        if (audioTable.ContainsKey(argument))
        {
            Debug.Log(argument.ToString() + "This message already exist");
        }
        else
            audioTable.Add(argument, audioclip);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="messageBroadcast">
    /// The message that the audio wants to listen to
    ///</param>
    public void AudioListener(string messageBroadcast)
    {
        Messenger.AddListener<string>(messageBroadcast, playAudio);
    }

    /// <summary>
    /// The audio plays by string arguments.
    /// </summary>
    /// <param string="argument"></param>
    void playAudio(string argument)
    {
        audioManager.clip = audioTable[argument];
        audioManager.Play();
    }
}

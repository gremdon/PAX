using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Tran and Paul audio file!
/// Tran did all of the audio script.
/// While Paul is looking into 3D settings.
/// </summary>
static public class Audio
{
    /// <summary>
    /// Audio Manager to play audio
    /// </summary>
    static public AudioSource audioManager;

    /// <summary>
    /// Key : string arg
    /// Value : AudioClip
    /// play audio depend on the string arg
    /// </summary>
    static Dictionary<string, AudioClip> audioTable = new Dictionary<string, AudioClip>();

    /// <summary>
    /// Add AudioClip with string argument to Dictionary
    /// </summary>
    /// <param name ="argument">
    /// Argument that audio need to play to
    /// </param>
    /// <param name ="audioclip">
    /// Audioclip that plays with the assign argument
    /// </param>
    static public void AddAudio(string argument, AudioClip audioclip)
    {
        if (audioTable.ContainsKey(argument))
        {
            Debug.Log(argument.ToString() + "This message already exist");
        }
        else
            audioTable.Add(argument, audioclip);
    }

    /// <summary>
    /// Subscribing to broadcast message that audio will listen to
    /// </summary>
    /// <param name="messageBroadcast">
    /// The message that is interested in.
    ///</param>
    static public void AudioListener(string messageBroadcast)
    {
        Messenger.AddListener<string>(messageBroadcast, playAudio);
    }

    /// <summary>
    /// Play the audio
    /// </summary>
    /// <param name="argument">
    /// Argument that audio needs to play to. :3
    /// </param>
    static private void playAudio(string argument)
    {
        audioManager.clip = audioTable[argument];
        audioManager.Play();
    }
}

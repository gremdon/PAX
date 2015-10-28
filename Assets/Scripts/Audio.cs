using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Tran and Paul audio file!
/// </summary>
static public class Audio
{
    /// <summary>
    /// Audio Source to play audio
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
    static public void AudioListener(string messageBroadcast, bool threeD)
    {
        if(threeD)
        {
            Messenger.AddListener<string>(messageBroadcast, play3DAudio);
        }
        else
            Messenger.AddListener<string>(messageBroadcast, play2DAudio);
    }

    /// <summary>
    /// So all audioClips start off 2D
    /// This function turns 2D Audio Clips into 3D
    /// </summary>
    /// <param name="audioClip">
    /// The audio that is passed in, will turn into 3D audio
    /// </param>
    static public void play3DAudio(string argument)
    {
        // Setting spatialBlend 0 is 2D & 1 is 3D;
        audioManager.clip = audioTable[argument];
        audioManager.spatialBlend = 1;
        audioManager.minDistance = 1.0f;
        audioManager.maxDistance = 10.0f;
        audioManager.loop = true;
        audioManager.Play();
    }

    /// <summary>
    /// Play the audio
    /// </summary>
    /// <param name="argument">
    /// Argument that audio needs to play to. :3
    /// </param>
    static private void play2DAudio(string argument)
    {
        audioManager.clip = audioTable[argument];
        audioManager.Play();
    }
}

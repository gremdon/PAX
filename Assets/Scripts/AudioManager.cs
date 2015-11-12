﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Tran and Paul audio file!
/// </summary>
static public class AudioManager
{
    /// <summary>
    /// Key : string arg
    /// Value : GameObject
    /// play audio depend on the string arg
    /// </summary>
    static Dictionary<string, GameObject> audioTable = new Dictionary<string, GameObject>();

    /// Add AudioClip with string argument to Dictionary
    /// Argument that audio need to play to
    /// GameObject that plays with the assign argument
    static public void AddAudioToDictionary(string argument, GameObject audioGameObject)
    {
            audioTable.Add(argument, audioGameObject);
    }

    /// <summary>
    /// Subscribing to broadcast message that audio will listen to
    /// </summary>
    /// <param name="messageBroadcast">
    /// The message that is interested in.
    /// </param>
    /// <param name="threeD">
    /// boolean for 3D audio
    /// </param>
    static public void AddListener(string messageBroadcast, bool threeD)
    {
        if (threeD)
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
    /// <param name="argument">
    /// The audio that is passed in, will turn into 3D audio
    /// </param>
    static private void play3DAudio(string argument)
    {
        // GameObject aud equals to the dictonary audioTable[string argument] To pull that Gameobject in Dict.
        // AudioSource asrc = Gameobject aud AudioSource.  AudioSource Asrc = Aud(AudioSource) What?!
        GameObject aud = audioTable[argument];
        AudioSource asrc = aud.GetComponent<AudioSource>();

		if (asrc == null)
			Debug.Log ("Need to add AudioSource");

        // Setting spatialBlend 0 is 2D & 1 is 3D;
        asrc.clip = audioTable[argument].GetComponent<AudioSource>().clip;
        asrc.spatialBlend = 1;
        asrc.minDistance = 1.0f;
        asrc.maxDistance = 5.0f;
        if (!asrc.isPlaying)
        {
            asrc.Play();
        }
    }

    /// <summary>
    /// Play the audio
    /// </summary>
    /// <param name="argument">
    /// Argument that audio needs to play to. :3
    /// </param>
    static private void play2DAudio(string argument)
    {
        GameObject aud = audioTable[argument];
        AudioSource asrc = aud.GetComponent<AudioSource>();

		if (asrc == null)
			Debug.Log ("Need to add AudioSource");

        if (!asrc.isPlaying)
        {
            asrc.Play();
        }
    }
}
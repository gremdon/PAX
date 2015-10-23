using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Audio : MonoBehaviour
{
    AudioSource player, enemy, gui;
    Dictionary<string, AudioClip> audioEvent = new Dictionary<string, AudioClip>();
    /* 
        An event is played and when that event is played, it shoots out a string, that a subscriber will subscribe to that message and play that audio
        clip.

        Dictionary of key : message
                      value : AudioClip
    */

    /// <summary>
    /// Tran and Paul
    /// </summary>
    /// <param name="message"></param>
    void PlayerAudio(string message)
    {
        player.clip = audioEvent[message];
        player.Play();
    }

    void EnemyAudio()
    {

    }

    void GuiAudio()
    {

    }
}

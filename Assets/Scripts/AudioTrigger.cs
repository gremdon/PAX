using UnityEngine;
using System.Collections;

public class AudioTrigger : BroadcastOnTrigger
{
    [SerializeField]
	private AudioClip soundClip;

    protected override void OnTriggerEnter(Collider col)
    {
        Messenger.Broadcast("playaudio", soundClip.name);
    }
}

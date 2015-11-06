using UnityEngine;
using System.Collections;

public class GUI_Audio : MonoBehaviour 
{
	AudioSource guiAudio;
	public AudioClip guiButton;

	void Awake()
	{
		guiAudio = GetComponent<AudioSource> ();
		if (guiAudio == null)
			Debug.Log ("Need to add AudioSource");
	}

	public void guiButtons()
	{
		playAudio(guiButton);
	}

	private void playAudio(AudioClip sound)
	{
		guiAudio.clip = sound;
		guiAudio.Play();
	}

}

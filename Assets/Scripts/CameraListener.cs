using UnityEngine;
using System.Collections;

public class CameraListener : MonoBehaviour {
    public string listeningFor;
	// Use this for initialization
	void Awake()
    {
        Messenger.AddListener<string>(listeningFor, SetCam);
        gameObject.SetActive(false);
    }

    void SetCam(string s)
    {
        gameObject.SetActive(true);
    }
}

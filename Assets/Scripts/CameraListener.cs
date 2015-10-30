using UnityEngine;
using System.Collections;

public class CameraListener : MonoBehaviour {
    public string listeningFor;
    public bool startCam;
	// Use this for initialization
	void Awake()
    {
        Debug.Log("blah");//camerachange
        Messenger.AddListener<string>(listeningFor, SetCam);
        if(!startCam)
            gameObject.SetActive(false);
    }

    void SetCam(string s) // s is the name of the gameobject that broadcasts the message
    {
        if (s == "Player1")
        {
            if (gameObject.activeSelf == false)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}

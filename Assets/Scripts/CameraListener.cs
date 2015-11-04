/*
    Setup:
        1) Listening For: [the message to listen for]
        2) Star Cam: if this camera is active on level start.
        2) Activator: the trigger(s) that this camera is activated with.
*/


using UnityEngine;
using System.Collections;

public class CameraListener : MonoBehaviour
{
    public string listeningFor;
    public bool startCam;
    public GameObject activator1, activator2;
	// Use this for initialization
	void Awake()
    {
        Messenger.AddListener<string,string>(listeningFor, SetCam);
        if(!startCam)
            gameObject.SetActive(false);
    }

    /// <summary>
    /// Sets the active camera.
    /// </summary>
    /// <param name="s">Name of the gameobject that triggered the event.</param>
    /// <param name="broadcaster">Name of the gameobject that broadcasts the message.</param>
    void SetCam(string s, string broadcaster)
    {
        if (s == "Player1")
        {
            if (gameObject.activeSelf == false)
            {
                if(activator2 == null)
                {
                    if (broadcaster == activator1.name)
                        gameObject.SetActive(true);
                }
                else
                {
                    if(broadcaster == activator1.name || broadcaster == activator2.name)
                        gameObject.SetActive(true);
                }
            }
            else
                gameObject.SetActive(false);
        }
    }
}

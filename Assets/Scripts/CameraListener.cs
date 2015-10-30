using UnityEngine;
using System.Collections;

public class CameraListener : MonoBehaviour
{
    public string listeningFor;
    public bool startCam;
	// Use this for initialization
	void Awake()
    {
        Messenger.AddListener<string,string>(listeningFor, SetCam);
        if(!startCam)
            gameObject.SetActive(false);
    }

    void SetCam(string s, string broadcaster) // s is the name of the gameobject that broadcasts the message
    {
        if (s == "Player1")
        {
            if (gameObject.activeSelf == false)
            {
                if(broadcaster == "HalfwayTrigger" && gameObject.name == "FreeFollowCam2")
                    gameObject.SetActive(true);
                if(broadcaster == "ArenaTrigger" && gameObject.name == "cctvCam")
                    gameObject.SetActive(true);
                if (broadcaster == "HalfwayTrigger" && gameObject.name == "FreeFollowCam")
                    gameObject.SetActive(true);
                if (broadcaster == "ArenaTrigger" && gameObject.name == "FreeFollowCam2")
                    gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}

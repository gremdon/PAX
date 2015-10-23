using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class InputHandler : MonoBehaviour
{
    public string Horizontal;
    public string Vertical;
    public string Jump;
    public string Crouch;
    public string Run;

    public float IdleTime;

    void Update()
    {
        IdleTime = Time.deltaTime * 2f;
        if (CrossPlatformInputManager.GetButton(Jump))
        {
            string[] temp = Jump.Split(':');
            //Messenger.Broadcast<string>(temp[0].ToLower(), temp[1].ToLower());
            IdleTime = 0;
        }

        if (CrossPlatformInputManager.GetButton(Crouch))
        {
            string[] temp = Crouch.Split(':');
            //Messenger.Broadcast<string>(temp[0].ToLower(), temp[1].ToLower());
            IdleTime = 0;

        }

        if (CrossPlatformInputManager.GetButton(Run))
        {
            string[] temp = Run.Split(':');
            //Messenger.Broadcast<string>(temp[0].ToLower(), temp[1].ToLower());
            IdleTime = 0;
        }

        if (CrossPlatformInputManager.GetAxis(Vertical) != 0)
        {
            string[] temp = Vertical.Split(':');
            //Messenger.Broadcast<string>(temp[0].ToLower(), temp[1].ToLower());
            IdleTime = 0;
        }

        if (CrossPlatformInputManager.GetAxis(Horizontal) != 0)
        {
            string[] temp = Horizontal.Split(':');
            //Messenger.Broadcast<string>(temp[0].ToLower(), temp[1].ToLower());
            IdleTime = 0;
        }
    }
}

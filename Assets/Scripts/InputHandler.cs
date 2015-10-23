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

    void Update()
    {
        if(CrossPlatformInputManager.GetButton(Jump))
        {
            string[] temp = Jump.Split(':');
            Messenger.Broadcast<string>(temp[0].ToLower(), temp[1].ToLower());
        }

        if (CrossPlatformInputManager.GetButton(Crouch))
        {
            string[] temp = Crouch.Split(':');
            Messenger.Broadcast<string>(temp[0].ToLower(), temp[1].ToLower());
        }

        if (CrossPlatformInputManager.GetButton(Run))
        {
            string[] temp = Run.Split(':');
            Messenger.Broadcast<string>(temp[0].ToLower(), temp[1].ToLower());
        }

        if (CrossPlatformInputManager.GetButton(Vertical))
        {
            string[] temp = Vertical.Split(':');
            Messenger.Broadcast<string>(temp[0].ToLower(), temp[1].ToLower());
        }

        if (CrossPlatformInputManager.GetButton(Horizontal))
        {
            string[] temp = Horizontal.Split(':');
            Messenger.Broadcast<string>(temp[0].ToLower(), temp[1].ToLower());
        }
    }
}

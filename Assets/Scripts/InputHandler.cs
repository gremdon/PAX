using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class InputHandler : MonoBehaviour
{
    public string Horizontal;
    public string Vertical;
    public string Jump;
    public string Attack;
    public string Special;
    public string Run;

    public float IdleTime; //Will be used to turn return to main menu if no input for a certain time.

    void Update()
    {
        //IdleTime = Time.deltaTime * 2f;
        if (CrossPlatformInputManager.GetButton(gameObject.name + ":" + Jump))
        {
            Messenger.Broadcast<string>(gameObject.name + ":j", Jump.ToString());
            //IdleTime = 0;
        }

        if (CrossPlatformInputManager.GetButton(gameObject.name + ":" + Attack))
        {
            Messenger.Broadcast<string>(gameObject.name + ":a", Attack);
            //IdleTime = 0;
        }

        if (CrossPlatformInputManager.GetButton(gameObject.name + ":" + Special))
        {
            Messenger.Broadcast<string>(gameObject.name + ":s", Special);
            //IdleTime = 0;
        }

        if (CrossPlatformInputManager.GetButton(gameObject.name + ":" + Run))
        {
            Messenger.Broadcast<string>(gameObject.name + ":r", Run);
            //IdleTime = 0;
        }

        Messenger.Broadcast<string>(gameObject.name + ":v", Vertical);
        Messenger.Broadcast<string>(gameObject.name + ":h", Horizontal);
    }
}

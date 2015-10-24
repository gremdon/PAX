using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour
{
    public string Attack;
    public string Jump;
    public string Special;
    public string Sprint;

    [SerializeField]
    List<string> Controls = new List<string>();

    public string joysticks;

    public float IdleTime; //Will be used to turn return to main menu if no input for a certain time.

    void Start()
    {
        Controls.Add(Attack);
        Controls.Add(Jump);
        Controls.Add(Special);
        Controls.Add(Sprint);
        Input.GetJoystickNames()[0] = "Player 1";
        Debug.Log(Input.GetJoystickNames()[0]);
        joysticks = Input.GetJoystickNames()[0];
    }

    void Update()
    {
        if(Input.anyKey)
        {
            Debug.Log("Input Detected");
        }


        
    }
}

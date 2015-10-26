using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections.Generic;

public class InputHandler : Singleton<InputHandler>
{
    public string Attack;
    public string Jump;
    public string Special;
    public string Sprint;
    public bool keyboard;

    public int numPlayers;

    [SerializeField]
    List<string> P1Controls = new List<string>();
    [SerializeField]
    List<string> P2Controls = new List<string>();

    public float IdleTime; //Will be used to turn return to main menu if no input for a certain time.

    void Awake()
    {

    }

    void Start()
    {
        P1Controls.Add(Attack + ":Attack");
        P1Controls.Add(Jump + ":Jump");
        P1Controls.Add(Special + ":Special");
        P1Controls.Add(Sprint + ":Sprint");
        P2Controls.Add(Attack + ":Attack");
        P2Controls.Add(Jump + ":Jump");
        P2Controls.Add(Special + ":Special");
        P2Controls.Add(Sprint + ":Sprint");
        if(!keyboard)
        {
            SetP1Controls();
            SetP2Controls();
        }

    }

    void Update()
    {
        IdleTime += Time.deltaTime;
        if(IdleTime > 20)
        {
            Debug.Log("Thanks for playing");
        }

        if (Input.anyKey || Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 ||
            Input.GetAxis("p2Vertical") != 0 || Input.GetAxis("p2Horizontal") != 0)
        {
            IdleTime = 0;
        }


        Messenger.Broadcast<string>("Player1:v", "Vertical");
        Messenger.Broadcast<string>("Player1:h", "Horizontal");
        Messenger.Broadcast<string>("Player2:h", "p2Horizontal");
        Messenger.Broadcast<string>("Player2:v", "p2Vertical");
        foreach (string s in P1Controls)
        {
            string[] temp = s.Split(':');
            if (!keyboard)
            {
                if (Input.GetKeyDown(temp[1]))
                {
                    //Debug.Log(temp[0] + " " + temp[1]);
                    Messenger.Broadcast<string>("Player1:" + temp[0], temp[0]);
                }
            }
            else
            {
                if(Input.GetKeyDown(temp[0]))
                {
                    //Debug.Log(temp[0] + " " + temp[1]);
                    Messenger.Broadcast<string>("Player1:" + temp[1], temp[1]);
                }
            }
        }

        foreach (string s in P2Controls)
        {
            string[] temp = s.Split(':');
            if (Input.GetKeyDown(temp[1]))
            {
                Debug.Log(temp[0] + " " + temp[1]);
                Messenger.Broadcast<string>("Player2:" + temp[0], temp[0]);
            }
        }
    }

    void NumberOfPlayers()
    {
        numPlayers++;
    }

    void SetP1Controls()
    {
        for (int i = 0; i < P1Controls.Capacity; i++ )
        {
            string[] temp = P1Controls[i].Split(':');
            switch (temp[0])
            {
                case "A":
                    {
                        P1Controls[i] = temp[1] + ":joystick 1 button 0";
                        break;
                    }
                case "B":
                    {
                        P1Controls[i] = temp[1] + ":joystick 1 button 1";
                        break;
                    }
                case "X":
                    {
                        P1Controls[i] = temp[1] + ":joystick 1 button 2";
                        break;
                    }
                case "Y":
                    {
                        P1Controls[i] = temp[1] + ":joystick 1 button 3";
                        break;
                    }
                case "RightBumper":
                    {
                        P1Controls[i] = temp[1] + ":joystick 1 button 4";
                        break;
                    }
                case "LeftBumper":
                    {
                        P1Controls[i] = temp[1] + ":joystick 1 button 5";
                        break;
                    }
                case "BackButton":
                    {
                        P1Controls[i] = temp[1] + ":joystick 1 button 6";
                        break;
                    }
                case "StartButton":
                    {
                        P1Controls[i] = temp[1] + ":joystick 1 button 7";
                        break;
                    }
                case "LeftStick":
                    {
                        P1Controls[i] = temp[1] + ":joystick 1 button 8";
                        break;
                    }
                case "RightStick":
                    {
                        P1Controls[i] = temp[1] + ":joystick 1 button 9";
                        break;
                    }
            }
        }
    }

    void SetP2Controls()
    {
        for (int i = 0; i < P2Controls.Capacity; i++ )
        {
            string[] temp = P2Controls[i].Split(':');
            switch (temp[0])
            {
                case "A":
                    {
                        P2Controls[i] = temp[1] + ":joystick 2 button 0";
                        break;
                    }
                case "B":
                    {
                        P2Controls[i] = temp[1] + ":joystick 2 button 1";
                        break;
                    }
                case "X":
                    {
                        P2Controls[i] = temp[1] + ":joystick 2 button 2";
                        break;
                    }
                case "Y":
                    {
                        P2Controls[i] = temp[1] + ":joystick 2 button 3";
                        break;
                    }
                case "RightBumper":
                    {
                        P2Controls[i] = temp[1] + ":joystick 2 button 4";
                        break;
                    }
                case "LeftBumper":
                    {
                        P2Controls[i] = temp[1] + ":joystick 2 button 5";
                        break;
                    }
                case "BackButton":
                    {
                        P2Controls[i] = temp[1] + ":joystick 2 button 6";
                        break;
                    }
                case "StartButton":
                    {
                        P2Controls[i] = temp[1] + ":joystick 2 button 7";
                        break;
                    }
                case "LeftStick":
                    {
                        P2Controls[i] = temp[1] + ":joystick 2 button 8";
                        break;
                    }
                case "RightStick":
                    {
                        P2Controls[i] = temp[1] + ":joystick 2 button 9";
                        break;
                    }
            }
        }
    }
}

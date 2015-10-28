using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections.Generic;

/// <summary>
/// Dylan Guidry
/// InputHandler.cs
/// 10/26/15
/// 
/// Handles all inputs by the user and if they are a input that is assigned to an action
/// it will publish it and what ever is listening for the event will perform the action 
/// </summary>

public class InputHandler : Singleton<InputHandler>
{
    private enum E_JOYSTICK
    {
        e_NULL,
        e_A,
        e_B,
        e_X,
        e_Y,
        e_RightBumper,
        e_LeftBumper,
        e_RightStick,
        e_LeftStick,
        e_StartButton,
        e_BackButton
    }

    private enum E_KEYBOARD
    {
        e_Null,
        e_A,
        e_B,
        e_C,
        e_D,
        e_E,
        e_F,
        e_G,
        e_H,
        e_I,
        e_J,
        e_K,
        e_L,
        e_M,
        e_N,
        e_O,
        e_P,
        e_Q,
        e_R,
        e_S,
        e_T,
        e_U,
        e_V,
        e_W,
        e_X,
        e_Y,
        e_Z,
        e_ARROW_UP,
        e_ARROW_LEFT,
        e_ARROW_DOWN,
        e_ARROW_RIGHT,
        e_SPACE,
        e_ESCAPE,
        e_SHIFT,
        e_NUM_LOCK,
        e_SCROLL_LOCK,
        e_CAP_LOCK,
        e_Num_0,
        e_Num_1,
        e_Num_2,
        e_Num_3,
        e_Num_4,
        e_Num_5,
        e_Num_6,
        e_Num_7,
        e_Num_8,
        e_Num_9,
        e_F1,
        e_F2,
        e_F3,
        e_F4,
        e_F5,
        e_F6,
        e_F7,
        e_F8,
        e_F9,
        e_F10,
        e_F11,
        e_F12
    }

    void Start()
    {
        //Adds all the controls to the list
        //They are modified in the SetControls Functions for each player
        P1Controls.Add(jAttack + ":Attack");
        P1Controls.Add(jJump + ":Jump");
        P1Controls.Add(jSpecial + ":Special");
        P1Controls.Add(jSprint + ":Sprint");
        P2Controls.Add(kAttack + ":Attack");
        P2Controls.Add(kJump + ":Jump");
        P2Controls.Add(kSpecial + ":Special");
        P2Controls.Add(kSprint + ":Sprint");
        if(!keyboard)
        {
            SetP1Controls();

        }
        SetP2Controls();
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

        //Sets the vertical and horizontal axis Player1 should move on based on if
        //KeyBoad Controls are active or not
        if(!keyboard)
        {
            Messenger.Broadcast<float, float>("Player1:", Input.GetAxis("Vertical"),
                Input.GetAxis("Horizontal"));
            //Messenger.Broadcast<string>("Player1:v", "Vertical");
            //Messenger.Broadcast<string>("Player1:h", "Horizontal");
        }
        else
        {
            Messenger.Broadcast<float, float>("Player1:", Input.GetAxis("KeyBoardVertical"),
                Input.GetAxis("KeyBoardHorizontal"));
            //Messenger.Broadcast<string>("Player1v", "KeyBoardVertical");
            //Messenger.Broadcast<string>("Player1:h", "KeyBoardHorizontal");
        }


        if (numPlayers == 2)
        {
            //Sets the Axis Player2 moves on regardless of control scheme. It will allways
            //move with the controller and not the keybard
            Messenger.Broadcast<float, float>("Player2:", Input.GetAxis("p2Horizontal"),
                Input.GetAxis("p2Vertical"));
            //Messenger.Broadcast<string>("Player2:v", "Vertical");
            //Messenger.Broadcast<string>("Player2:h", "Horizontal");

            //Checks for inputs that are in the List of controls for player2
            foreach (string s in P2Controls)
            {
                string[] temp = s.Split(':');
                if(temp[1] == "Sprint" && Input.GetKey(temp[1]))
                {
                    Messenger.Broadcast("Player2:" + temp[0]);
                }
                if (Input.GetKeyDown(temp[1]))
                {
                    Messenger.Broadcast("Player2:" + temp[0]);
                }
            }
        }


        //Checks for inputs that are in the List of controls for player1
        foreach (string s in P1Controls)
        {
            string[] temp = s.Split(':');
            if (!keyboard)
            {
                if (temp[0] == "Sprint" && Input.GetKey(temp[1]))
                {
                    Messenger.Broadcast("Player1:" + temp[0]);
                }
                if (Input.GetKeyDown(temp[1]))
                {
                    Messenger.Broadcast("Player1:" + temp[0]);
                }
            }
            else
            {
                if (temp[1] == "Sprint" && Input.GetKey(temp[0]))
                {
                    Messenger.Broadcast("Player1:" + temp[1]);
                }
                if (Input.GetKeyDown(temp[0]))
                {
                    Messenger.Broadcast("Player1:" + temp[1]);
                }
            }
        }


    }

    /// <summary>
    /// Will be used to tell how many players are active in the game and will enable 
    /// the controls only necessary for that many players
    /// </summary>
    private void NumberOfPlayers()
    {
        numPlayers++;
    }

    /// <summary>
    /// Sets the controls the user defines in to the list of controls for there selected character
    /// to utilize and react to when they are pressed
    /// </summary>
    private void SetP1Controls()
    {
        for (int i = 0; i < P1Controls.Capacity; i++ )
        {
            string[] temp = P1Controls[i].Split(':');
            string[] split = temp[0].Split('_');
            switch (split[1])
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

    /// <summary>
    /// Sets the controls the user defines in to the list of controls for there selected character
    /// to utilize and react to when they are pressed
    /// </summary>
    private void SetP2Controls()
    {
        //Checks the button the user assigns to the selected action and assigns it to the appropriate
        //string value for unity to recognize inputs of that type
        for (int i = 0; i < P2Controls.Capacity; i++ )
        {
            string[] temp = P2Controls[i].Split(':');
            string[] split = temp[0].Split('_');
            switch (split[1])
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
                default:
                    {
                        break;
                    }
            }
        }

        //Default controls for when keyboard is active
        if(keyboard)
        {
            P2Controls[0] = "Attack" + ":joystick 2 button 1";
            P2Controls[1] = "Jump" + ":joystick 2 button 0";
            P2Controls[2] = "Special" + ":joystick 2 button 2";
            P2Controls[3] = "Sprint" + ":joystick 2 button 4";
        }
    }

    /// <summary>
    /// All variables of the InputHandler class
    /// </summary>
    #region Varaibles
    [Header("Joystick Controls")]
    [SerializeField]
    private E_JOYSTICK jAttack; //Control assigned to the attack action if using a joystick
    [SerializeField]
    private E_JOYSTICK jJump; //Control assigned to the Jump Action if using a joystick
    [SerializeField]
    private E_JOYSTICK jSpecial; //Control assigned to the Specail Action if using a joystick
    [SerializeField]
    private E_JOYSTICK jSprint; //Control assigned to the Sprint Action if using a joystick

    [Header("Keyboard Controls")]
    [SerializeField]
    private E_KEYBOARD kAttack; //Control assigned to the attack action if using the Keyboard
    [SerializeField]
    private E_KEYBOARD kJump; //Control assigned to the Jump Action if using the Keyboard
    [SerializeField]
    private E_KEYBOARD kSpecial; //Control assigned to the Specail Action if using the Keyboard
    [SerializeField]
    private E_KEYBOARD kSprint; //Control assigned to the Sprint Action if using the Keyboard

    public bool keyboard; //A boolean to determine if the controls are configured for keyboard or Controler

    public int numPlayers; //Keeps track of number of players active in the game

    private List<string> P1Controls = new List<string>(); //List that stores all controls for player 1
    private List<string> P2Controls = new List<string>(); //List that stores all controls for player 2

    private float IdleTime; //Will be used to turn return to main menu if no input for a certain time.
    #endregion
}

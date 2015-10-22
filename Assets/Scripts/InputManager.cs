using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class InputManager
{
    private static Dictionary<PlayerInputs, KeyboardInput> _inputs;

    private static KeyboardInput _forward   = KeyboardInput.W;
    private static KeyboardInput _backward  = KeyboardInput.S;
    private static KeyboardInput _left      = KeyboardInput.A;
    private static KeyboardInput _right     = KeyboardInput.D;
    private static KeyboardInput _jump      = KeyboardInput.SPACE;

    public static void DirectInput(KeyboardInput input)
    {
        if(_inputs.ContainsValue(input))
        {

        }

        if(input == _forward)
        {
            OnMoveForward();
        }
        
        if (input == _backward)
        {
            OnMoveBackward();
        }

        if (input == _left)
        {
            OnMoveLeft();
        }

        if (input == _right)
        {
            OnMoveRight();
        }

        if (input == _jump)
        {
            OnJump();

        }
    }

    private static void OnMoveForward()
    {
        Debug.Log("I'm Moving Forward");
    }

    private static void OnMoveRight()
    {
        Debug.Log("I'm Moving Right");
    }

    private static void OnMoveLeft()
    {
        Debug.Log("I'm Moving Left");
    }

    private static void OnMoveBackward()
    {
        Debug.Log("I'm Moving Backward");
    }

    private static void OnJump()
    {
        Debug.Log("I'm Jumping");
    }
}

enum PlayerInputs
{
    MOVE_FORWARD,
    MOVE_RIGHT,
    MOVE_LEFT,
    MOVE_BACKWARD,
    JUMP
}

public enum KeyboardInput
{
    A,
    B,
    C,
    D,
    E,
    F,
    G,
    H,
    I,
    J,
    K,
    L,
    M,
    N,
    O,
    P,
    Q,
    R,
    S,
    T,
    U,
    V,
    W,
    X,
    Y,
    Z,
    ARROW_UP,
    ARROW_LEFT,
    ARROW_DOWN,
    ARROW_RIGHT,
    SPACE,
    ESCAPE,
    SHIFT,
    NUM_LOCK,
    SCROLL_LOCK,
    CAP_LOCK,
    Num_0,
    Num_1,
    Num_2,
    Num_3,
    Num_4,
    Num_5,
    Num_6,
    Num_7,
    Num_8,
    Num_9,
    F1,
    F2,
    F3,
    F4,
    F5,
    F6,
    F7,
    F8,
    F9,
    F10,
    F11,
    F12
}

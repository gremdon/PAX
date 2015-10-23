using UnityEngine;
using System.Collections.Generic;

public class GameStates:MonoBehaviour// : Singleton<MonoBehaviour>
{    /*protected override*/ void Awake()
    {
        //base.Awake();

        Messenger.AddListener<STATES>("maketransition", CallTransition);
        Messenger.AddListener<string>("win", RestartLevel);

        Messenger.MarkAsPermanent("maketransition");
        Messenger.MarkAsPermanent("win");
    
        callback = DoSomething;

        _fsm.AddState(STATES.INIT);
        _fsm.AddState(STATES.START);
        _fsm.AddState(STATES.PLAY);
        _fsm.AddState(STATES.PAUSE);
        _fsm.AddState(STATES.GAMEOVER);
        _fsm.AddState(STATES.END);
        _fsm.AddState(STATES.TERM);

        _fsm.m_currentState = STATES.INIT;

        _fsm.AddTransition(STATES.INIT,     STATES.START,       callback);
        _fsm.AddTransition(STATES.START,    STATES.PLAY,        callback);
        _fsm.AddTransition(STATES.PLAY,     STATES.PAUSE,       callback);
        _fsm.AddTransition(STATES.PAUSE,    STATES.PLAY,        callback);
        _fsm.AddTransition(STATES.PLAY,     STATES.GAMEOVER,    callback);
        _fsm.AddTransition(STATES.PAUSE,    STATES.GAMEOVER,    callback);
        _fsm.AddTransition(STATES.GAMEOVER, STATES.START,       callback);
        _fsm.AddTransition(STATES.START,    STATES.END,         callback);
        _fsm.AddTransition(STATES.END,      STATES.TERM,        callback);

        _fsm.AddTransition(STATES.GAMEOVER, STATES.PLAY,        callback);
    }

    public enum STATES
    {
        INIT,
        START,
        PLAY,
        PAUSE,
        GAMEOVER,
        END,
        TERM,
    }



    Callback<string> callback;

    void DoSomething(string transition)
    {
        Messenger.Broadcast("transition", transition);
    }

    void RestartLevel(string s)
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void CallTransition(STATES transition)
    {
        _fsm.MakeTransitionTo(transition);
    }

    private _FSM<STATES> _fsm = new _FSM<STATES>();
}

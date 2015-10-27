using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class PlayerCharacterController : MonoBehaviour
{
    DJG.FSM<E_CHARACTERSTATES> _fsm;

    enum E_CHARACTERSTATES
    {
        e_Init,
        e_Idle,
        e_Walking,
        e_Running,
        e_Attacking,
        e_Jumping,
        e_Dead,
        e_Count //Used to enumerate through the array
    }

    [SerializeField]
    private float m_MovementSeed = 0;
    [SerializeField]
    private float m_RotateSpeed = 0;
    [SerializeField]
    private float m_JumpPower = 0;
    [SerializeField]
    private int m_MaxHealth = 0;
    [SerializeField]
    private int m_CurrentHealth = 0;
    [SerializeField]
    private int m_MaxActionResource = 0;
    private int m_CurrentActionResource = 0;

    float h; //horizontal movement
    float v; //vertical movement

    void Awake()
    {
        _fsm = new DJG.FSM<E_CHARACTERSTATES>();
        m_CurrentHealth = m_MaxHealth;
        m_CurrentActionResource = m_MaxActionResource;
        AddStates();
        AddTransitions();
        Instance = this;
        AddListeners();
    }

    // Use this for initialization
    void Start()
    {

	}

    void AddListeners()
    {
        Messenger.AddListener<float,float>(gameObject.name + ":", Movement);
        Debug.Log(gameObject.name + ":");
    }

    void AddStates()
    {
        foreach(int i in Enum.GetValues(typeof(E_CHARACTERSTATES)))
        {
            if((E_CHARACTERSTATES)i != E_CHARACTERSTATES.e_Count)
            {
                _fsm.AddState((E_CHARACTERSTATES)i);
            }
        }
    }

    void AddTransitions()
    {
        //Transition from
            //e_Init
        _fsm.AddTransition(E_CHARACTERSTATES.e_Idle, E_CHARACTERSTATES.e_Idle);
            //e_Idle
        _fsm.AddTransition(E_CHARACTERSTATES.e_Idle, E_CHARACTERSTATES.e_Walking);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Idle, E_CHARACTERSTATES.e_Jumping);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Idle, E_CHARACTERSTATES.e_Attacking);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Idle, E_CHARACTERSTATES.e_Dead);
            //e_Walking
        _fsm.AddTransition(E_CHARACTERSTATES.e_Walking, E_CHARACTERSTATES.e_Idle);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Walking, E_CHARACTERSTATES.e_Running);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Walking, E_CHARACTERSTATES.e_Jumping);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Walking, E_CHARACTERSTATES.e_Attacking);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Walking, E_CHARACTERSTATES.e_Dead);
            //e_Running
        _fsm.AddTransition(E_CHARACTERSTATES.e_Running, E_CHARACTERSTATES.e_Walking);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Running, E_CHARACTERSTATES.e_Idle);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Running, E_CHARACTERSTATES.e_Attacking);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Running, E_CHARACTERSTATES.e_Jumping);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Running, E_CHARACTERSTATES.e_Dead);
            //e_Attacking
        _fsm.AddTransition(E_CHARACTERSTATES.e_Attacking, E_CHARACTERSTATES.e_Running);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Attacking, E_CHARACTERSTATES.e_Walking);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Attacking, E_CHARACTERSTATES.e_Idle);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Attacking, E_CHARACTERSTATES.e_Dead);
        //e_Jumping
        _fsm.AddTransition(E_CHARACTERSTATES.e_Jumping, E_CHARACTERSTATES.e_Idle);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Jumping, E_CHARACTERSTATES.e_Walking);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Jumping, E_CHARACTERSTATES.e_Running);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Jumping, E_CHARACTERSTATES.e_Attacking);
        _fsm.AddTransition(E_CHARACTERSTATES.e_Jumping, E_CHARACTERSTATES.e_Dead);
    }

    #region Event

    void Movement(float a, float b)
    {
        h = b;
        v = a;
    }

    #endregion

    // Update is called once per frame
    void FixedUpdate ()
    {
        transform.Rotate(0, h * 10.0f, 0);
        if (h < 0)
        {
            transform.Rotate(0, h * 10.0f, 0);
            transform.forward = new Vector3(transform.forward.x, h, transform.forward.z);
        }
        else if(h > 0)
        {
            transform.forward = new Vector3(transform.forward.x, h, transform.forward.z);
        }
        if (v > 0.1)
        {
            transform.forward = new Vector3(transform.forward.x, transform.forward.y, v);
            transform.Translate(0, 0, v * m_MovementSeed);      
        }
        else if (v < -0.1)
        {
            transform.forward = new Vector3(transform.forward.x, transform.forward.y, v);
            transform.Translate(0, 0, -v * m_MovementSeed);
        }
    }

    private PlayerCharacterController Instance;

    protected PlayerCharacterController _Instance
    {
        get
        {
            return Instance;
        }
    }
}

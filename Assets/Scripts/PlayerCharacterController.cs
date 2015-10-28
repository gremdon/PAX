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
    private float m_BaseMovementSpeed = 0;
    [SerializeField]
    private float m_RotateSpeed = 0;
    [SerializeField]
    private float m_JumpPower = 0;
    private float m_MovementSpeed;

    float GroundDistance = 0.1f;

    float h; //horizontal movement
    float v; //vertical movement

    bool sprint;

    Rigidbody rb;

    bool grounded;

    Vector3 groundNormal;

    void Awake()
    {
        _fsm = new DJG.FSM<E_CHARACTERSTATES>();
        AddStates();
        AddTransitions();
        Instance = this;
        rb = GetComponent<Rigidbody>();
        AddListeners();
    }

    // Use this for initialization
    void Start()
    {

	}

    void AddListeners()
    {
        Messenger.AddListener<float,float>(gameObject.name + ":", Movement);
        Messenger.AddListener(gameObject.name + ":Jump", Jump);
        Messenger.AddListener(gameObject.name + ":Attack", Attack);
        Messenger.AddListener(gameObject.name + ":Sprint", Sprint);
        Messenger.AddListener(gameObject.name + ":Special", SpecialAttack);
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

    void Jump()
    {
        rb.AddForce(Vector3.up * m_JumpPower, ForceMode.VelocityChange);
    }

    void Attack()
    {
        Debug.Log("Attack");
    }

    void SpecialAttack()
    {
        Debug.Log("Special Attack");
    }

    void Sprint()
    {
        sprint = true;
    }

    #endregion

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (sprint == true)
        {
            m_MovementSpeed = 0.2f;
        }
        else if(sprint == false)
        {
            m_MovementSpeed = m_BaseMovementSpeed;
        }


        transform.Rotate(0, h * 10.0f, 0);

        if (v > 0.1 || v < -0.1)
            transform.Translate(0, 0, v * m_BaseMovementSpeed);

        

        sprint = false;
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

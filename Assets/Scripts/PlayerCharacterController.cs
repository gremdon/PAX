using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class PlayerCharacterController : MonoBehaviour
{
	[SerializeField]
	private float
		m_BaseMovementSpeed = 0;
	[SerializeField]
	private float
		m_RotateSpeed = 0;
	[SerializeField]
	private float
		m_JumpPower = 0;
	private float m_MovementSpeed;
	float GroundDistance = 0.1f;
	float h; //horizontal movement
	float v; //vertical movement
	
	Rigidbody rb;
	float HorizontalVelocity;
	float VerticalVelocity;
	public Vector3 Position;
	public Vector3 Rotation;
	public Vector3 Forward;

	void Awake ()
	{
		rb = GetComponent<Rigidbody> ();
		AddListeners ();
	}

	// Use this for initialization
	void Start ()
	{
		Messenger.Broadcast<string> ("Player", gameObject.name);
	}

	void AddListeners ()
	{
		Debug.Log ("adding listeners");
		Messenger.AddListener<int>(gameObject.name, PlayerNum);
		Messenger.MarkAsPermanent(gameObject.name);
	}

	void OnDisable ()
	{
		Debug.Log ("removing listeners");
		Messenger.RemoveListener<int>(gameObject.name, PlayerNum);
	}
		
	void PlayerNum(int num)
	{
		switch(num)
		{
		case 0:
			GetComponent<UnityChanControlScriptWithRigidBody>().inputType = 
				UnityChanControlScriptWithRigidBody.InputState.PLAYER1;
			break;
		case 1:
			GetComponent<UnityChanControlScriptWithRigidBody>().inputType = 
				UnityChanControlScriptWithRigidBody.InputState.PLAYER2;
			break;
		default:
			break;
		}
	}
}
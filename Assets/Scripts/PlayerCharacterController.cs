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

	bool sprint;
	Rigidbody rb;
	float HorizontalVelocity;
	float VerticalVelocity;
	public Vector3 Position;
	public Vector3 Rotation;
	public Vector3 Forward;

	public Vector3 camForward;

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
		Messenger.AddListener<float,float> (gameObject.name + ":", Movement);
		Messenger.AddListener (gameObject.name + ":Jump", Jump);
		Messenger.AddListener (gameObject.name + ":Attack", Attack);
		Messenger.AddListener (gameObject.name + ":Sprint", Sprint);
		Messenger.AddListener (gameObject.name + ":Special", SpecialAttack);
		Messenger.MarkAsPermanent (gameObject.name + ":Jump");
		Messenger.MarkAsPermanent (gameObject.name + ":Attack");
		Messenger.MarkAsPermanent (gameObject.name + ":Sprint");
		Messenger.MarkAsPermanent (gameObject.name + ":Special");
		Messenger.MarkAsPermanent (gameObject.name + ":");
	}

	void OnDisable ()
	{
		Debug.Log ("removing listeners");
		Messenger.RemoveListener<float, float> (gameObject.name + ":", Movement);
		Messenger.RemoveListener (gameObject.name + ":Jump", Jump);
		Messenger.RemoveListener (gameObject.name + ":Attack", Attack);
		Messenger.RemoveListener (gameObject.name + ":Sprint", Sprint);
		Messenger.RemoveListener (gameObject.name + ":Special", SpecialAttack);
	}

    #region Event
	void Movement (float a, float b)
	{
		h = b;
		v = a;
	}

	void Jump ()
	{
		rb.AddForce (Vector3.up * m_JumpPower, ForceMode.VelocityChange);
	}

	void Attack ()
	{
		Debug.Log ("Attack");
	}

	void SpecialAttack ()
	{
		Debug.Log ("Special Attack");
	}

	void Sprint ()
	{
		sprint = true;
	}

    #endregion

	void FixedUpdate ()
	{
		Vector3 dir = new Vector3(-1,0,0);
		if (sprint == true)
		{
			m_MovementSpeed = 5.0f;
		} else if (sprint == false) 
		{
			m_MovementSpeed = m_BaseMovementSpeed;
		}
		Forward = Camera.main.transform.forward - dir;

		Forward.y = 0;
		transform.forward = Forward;

		VerticalVelocity = (v) / m_MovementSpeed;
		HorizontalVelocity = (h) / m_MovementSpeed;

		Position = new Vector3 (HorizontalVelocity, 0, VerticalVelocity);
		transform.position += Position;
		//sprint = false;
	}
}
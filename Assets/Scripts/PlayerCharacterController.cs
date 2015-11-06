using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class PlayerCharacterController : MonoBehaviour
{
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
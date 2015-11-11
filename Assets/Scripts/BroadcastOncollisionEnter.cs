using UnityEngine;
using System.Collections;

public class BroadcastOnCollisionEnter : MonoBehaviour
{
	[SerializeField] string message;

	void OnCollisionEnter(Collider c)
	{
		Messenger.Broadcast(message,c.GetInstanceID().ToString());

	}

}
using UnityEngine;
using System.Collections;

public class BetweenPlayer : MonoBehaviour {

    public float zoffset;
    public Transform player1;
    public Transform player2;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(
            player1.position.x + player2.position.x, 
            player1.position.y + player2.position.y, 
            player1.position.z + player2.position.z + zoffset)/2.0f;
	
	}
}

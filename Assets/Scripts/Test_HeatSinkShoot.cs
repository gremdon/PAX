using UnityEngine;
using System.Collections;

public class Test_HeatSinkShoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 pos = transform.position + transform.forward;

	    if(Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(_projectile, pos, transform.rotation);
        }
	}

    [SerializeField]
    private GameObject _projectile;
}

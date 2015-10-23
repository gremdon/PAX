using UnityEngine;
using System.Collections;

public class PAXCamera : MonoBehaviour
{
    Transform followTarget;
    Vector3 offset;
    public float distance = 2.2f;
    public float minDistance = 2f;
    public float maxDistance = 10;
    public Vector3 originPosition = new Vector3(0, 1.8f, 0);
    Vector3 originRotation;
    Vector3 cameraLookDirection;
    Vector3 playerMoveDirection;

    void Start()
    {
        followTarget = FindObjectOfType<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().transform;
        originPosition = followTarget.position;
        originPosition += (followTarget.forward * maxDistance);
        originPosition += new Vector3(0, 3, 0);

        transform.position = originPosition;
        transform.LookAt(followTarget);
        cameraLookDirection = transform.forward;
        //originPosition = new Vector3(0.17f, 2.48f, -2.53f);
        //originRotation = new Vector3(18, 0, 0);

        //transform.eulerAngles = originRotation;
        //Reset();
        offset = transform.position - followTarget.position;

    }

    void Update()
    {
        transform.position = followTarget.position + offset;
    }

    void Reset()
    {
        transform.position = (followTarget.position - followTarget.forward) * distance;
        transform.position += originPosition;
        transform.eulerAngles = new Vector3(18, 0, 0) + followTarget.eulerAngles;

        offset = transform.position - followTarget.position;
    }
}

using UnityEngine;
using System.Collections;

public class PAXCamera : MonoBehaviour
{
    Transform followTarget;
    Vector3 offset;
    public float distance = 2.2f;
    public float minDistance = 3f;
    public float maxDistance = 10f;
    public float smoothing = .1f;
    public Vector3 originPosition = new Vector3(0, 1.8f, 0);
    Vector3 originRotation;
    Vector3 cameraLookDirection;
    Vector3 playerMoveDirection;

    void Start()
    {
        //set follow targtet
        followTarget = FindObjectOfType<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().transform;

        //set initial camera position and orientation
        originPosition = followTarget.position;
        originPosition += (followTarget.forward * distance);
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
        Vector3 v = followTarget.position - transform.position;
        if (/* Vector3.Distance( hit.point, transform.position)*/ (v.x * v.x + v.z * v.z) <= minDistance * minDistance)
        {
            //transform.position = followTarget.position + offset;
            transform.position = Vector3.Lerp(transform.position, followTarget.position + offset, Time.deltaTime * smoothing);
        }
        else if((v.x * v.x + v.z * v.z) >= maxDistance * maxDistance)
        {
            transform.position += followTarget.position + offset;
            //transform.forward = Vector3.Lerp(transform.forward, transform.LookAt(followTarget), Time.deltaTime * smoothing);
        }
        transform.LookAt(followTarget);
    }

    void Reset()
    {
        transform.position = (followTarget.position - followTarget.forward) * distance;
        transform.position += originPosition;
        transform.eulerAngles = new Vector3(18, 0, 0) + followTarget.eulerAngles;

        offset = transform.position - followTarget.position;
    }
}

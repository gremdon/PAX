using UnityEngine;
using System.Collections;

public class PAXCamera : MonoBehaviour
{
    Transform pivot;
    Transform cam;
    Transform followTarget;
    Transform lookAtTarget;
    public float yOffset = 0f;
    public float playerDistanceToCamera = 2.2f;
    public float minDistance = 3f;
    public float maxDistance = 10f;
    public float followSpeed = 1f;
    public float smoothing = 0.1f;
    float lookAtDistance;
    Vector3 offset;
    Vector3 cameraLookDirection;
    Vector3 playerMoveDirection;

    Vector3 aboveClipPlane = new Vector3(0, -1, 0);
    Vector3 bottomClipPlane = new Vector3(0, 1, 0);

    void Awake()
    {
        cam = GetComponentInChildren<Camera>().transform;
        pivot = cam.parent;

        offset = new Vector3(0, yOffset, 0);
        //lookAtTarget = GameObject.FindGameObjectWithTag("Player").transform;
        lookAtTarget = GameObject.Find("Player1").transform;

        //set follow target
        if (GameObject.Find("followTarget") != null)
        {
            //followTarget = GameObject.FindGameObjectWithTag("cameraFollow").transform;
            GameObject.Find("followTarget");
        }
        else
        {
            GameObject g = new GameObject();
            g.name = "followTarget";
            g.transform.parent = lookAtTarget.transform;
            g.transform.position = lookAtTarget.position + new Vector3(0, 0, 3);
            followTarget = g.transform;
        }        

        ////set initial camera position and orientation
        //transform.position = followTarget.position + (-followTarget.forward * distance) + new Vector3(0, 3, 0);
        //transform.LookAt(followTarget);
        //cameraLookDirection = transform.forward;

        //Reset();
        lookAtDistance = Vector3.Distance(lookAtTarget.position, pivot.transform.position);// transform.position - lookAtTarget.position;

    }

    void Update()
    {
        Vector3 v = lookAtTarget.position - pivot.transform.position;
        if ((v.x * v.x + v.z * v.z) <= minDistance * minDistance ||
            (v.x * v.x + v.z * v.z) >= maxDistance * maxDistance)
        {
            transform.position = Vector3.Lerp(transform.position, lookAtTarget.position + (-lookAtTarget.forward * lookAtDistance), Time.deltaTime * followSpeed);
        }
        else if ((v.x * v.x + v.z * v.z) <= lookAtDistance * lookAtDistance ||
                 (v.x * v.x + v.z * v.z) >= lookAtDistance * lookAtDistance)
        {
            transform.position = Vector3.Lerp(transform.position, lookAtTarget.position + (-lookAtTarget.forward * lookAtDistance), Time.deltaTime * smoothing);
        }
        HandleRotation();
        transform.LookAt(lookAtTarget.position + offset);
    }

    void HandleRotation()
    {
        //shoot a ray from the followTarget to the camera pivot position
        cameraLookDirection = followTarget.position - pivot.transform.position;
        RaycastHit hit;
        Ray r = new Ray(followTarget.position, -cameraLookDirection);
        Physics.Raycast(r, out hit);
        Debug.DrawRay(followTarget.position, -cameraLookDirection, Color.red);
        //if the ray hit an obstacle blocking the view of the lookAtTarget, the camera should pan behind the followTarget
        if (hit.collider != null && hit.collider != lookAtTarget.gameObject && hit.collider != transform.gameObject)
        {
            //if(hit.normal == aboveClipPlane)
            transform.position = Vector3.Lerp(transform.position, lookAtTarget.position + (-lookAtTarget.forward * lookAtDistance), Time.deltaTime * followSpeed);
        }
    }

    void Reset()
    {
        transform.position = Vector3.Lerp(transform.position, lookAtTarget.position + (-lookAtTarget.forward * playerDistanceToCamera), Time.deltaTime * smoothing);
    }
}
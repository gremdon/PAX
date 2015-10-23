using UnityEngine;
using System.Collections;

public class PAXCamera : MonoBehaviour
{
    GameObject testCube;
    Transform followTarget;
    public float distance = 2.2f;
    public float minDistance = 3f;
    public float maxDistance = 10f;
    public float smoothing = .1f;
    //public Vector3 originPosition = new Vector3(0, 1.8f, 0);
    //Vector3 originRotation;
    Vector3 offset;
    Vector3 cameraLookDirection;
    Vector3 playerMoveDirection;

    void Start()
    {
        testCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        testCube.transform.position = Vector3.zero;
        //set follow targtet
        followTarget = GameObject.FindGameObjectWithTag("Player").transform;

        //set initial camera position and orientation
        transform.position = followTarget.position + (followTarget.forward * distance) + new Vector3(0, 3, 0);
        transform.LookAt(followTarget);
        cameraLookDirection = transform.forward;

        //Reset();
        offset = transform.position - followTarget.position;

    }

    void Update()
    {
        Vector3 v = followTarget.position - transform.position;
        if ((v.x * v.x + v.z * v.z) <= minDistance * minDistance || 
            (v.x * v.x + v.z * v.z) >= maxDistance * maxDistance)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position + offset, Time.deltaTime * smoothing);
        }
        //else if((v.x * v.x + v.z * v.z) >= maxDistance * maxDistance)
        //{
        //    transform.position = followTarget.position + offset;
        //    //transform.forward = Vector3.Lerp(transform.forward, transform.LookAt(followTarget), Time.deltaTime * smoothing);
        //}
        PredictPosition();
        transform.LookAt(followTarget);
    }

    void PredictPosition()
    {
        Vector3 predictedCameraPosition = transform.position + (followTarget.forward * distance);
        testCube.transform.position = predictedCameraPosition;
        float playerDistanceToCamera = Vector3.Distance(followTarget.position, transform.position);

        RaycastHit hit;
        Ray r = new Ray(predictedCameraPosition, transform.forward);        
        Physics.Raycast(r, out hit);
        Debug.DrawLine(predictedCameraPosition, hit.point);
        //if (Vector3.Distance(hit.point, predictedCameraPosition) <= playerDistanceToCamera)
        //{
        //    //transform.position = followTarget.position + (followTarget.forward * distance) + new Vector3(0, 3, 0);
        //    transform.position = Vector3.Lerp(transform.position, (followTarget.forward * playerDistanceToCamera), Time.deltaTime * smoothing);
        //}
    }

    void Reset()
    {
        transform.position = (followTarget.position - followTarget.forward) * distance;
        //transform.position += originPosition;
        transform.eulerAngles = new Vector3(18, 0, 0) + followTarget.eulerAngles;

        offset = transform.position - followTarget.position;
    }
}

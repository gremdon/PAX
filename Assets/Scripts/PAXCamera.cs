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
        //testCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //testCube.transform.position = Vector3.zero;
        //testCube.GetComponent<BoxCollider>().enabled = false;
        
        //set follow targtet
        followTarget = GameObject.FindGameObjectWithTag("partybro").transform;

        ////set initial camera position and orientation
        //transform.position = followTarget.position + (-followTarget.forward * distance) + new Vector3(0, 3, 0);
        //transform.LookAt(followTarget);
        //cameraLookDirection = transform.forward;

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
        PredictPlayerPosition();
        transform.LookAt(followTarget);
    }

    void PredictPlayerPosition()
    {
        //position in front of player facing in the direction the player is facing
        Vector3 predictedPlayerPosition = followTarget.position + (followTarget.forward * distance);
        predictedPlayerPosition = followTarget.position;
        //testCube.transform.position = predictedPlayerPosition;
        //testCube.transform.forward = followTarget.forward;

        float playerDistanceToCamera = Vector3.Distance(followTarget.position, transform.position);

        //shoot a ray from the predictedPlayerPosition to the camera position
        cameraLookDirection = predictedPlayerPosition - transform.position;
        RaycastHit hit;
        Ray r = new Ray(predictedPlayerPosition, -cameraLookDirection);
        Physics.Raycast(r, out hit);
        Debug.DrawRay(predictedPlayerPosition, -cameraLookDirection);
        if(hit.collider != null && hit.collider != followTarget.gameObject && hit.collider != transform.gameObject)
        {
            //transform.position += followTarget.forward * distance;
            transform.position = Vector3.Lerp(transform.position, followTarget.position + (-followTarget.forward * playerDistanceToCamera), Time.deltaTime * smoothing);
        }
        
    }

    void Reset()
    {
        transform.position = (followTarget.position - followTarget.forward) * distance;
        //transform.position += originPosition;
        transform.eulerAngles = new Vector3(18, 0, 0) + followTarget.eulerAngles;

        offset = transform.position - followTarget.position;
    }
}

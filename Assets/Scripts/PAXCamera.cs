using UnityEngine;
using System.Collections;

public class PAXCamera : MonoBehaviour
{
    //GameObject testCube;
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
        
        //set follow targtet
        followTarget = GameObject.FindGameObjectWithTag("Player").transform;

        //set initial camera position and orientation
        transform.position = followTarget.position + (-followTarget.forward * distance) + new Vector3(0, 3, 0);
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
        PredictPlayerPosition();
        transform.LookAt(followTarget);
    }

    void PredictPlayerPosition()
    {
        //position in front of player facing in the direction the player is facing
        Vector3 predictedPlayerPosition = followTarget.position + (followTarget.forward * distance) + new Vector3(0,0.2f, 0);
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

            //Vector3 hitDirection = Vector3.Normalize(hit.point - followTarget.position);
            //if (Vector3.Dot(followTarget.forward, hitDirection) > 0 && Vector3.Dot(followTarget.forward, hitDirection) < 1)
            //{
            //    transform.position -= new Vector3(.2f, 0, .2f);
            //}
            //else if (Vector3.Dot(followTarget.forward, hitDirection) > 1 && Vector3.Dot(followTarget.forward, hitDirection) < 0)
            //{
            //    transform.position += new Vector3(.2f, 0, .2f);
            //}

            //if (hit.point.x > followTarget.position.x)
            //{
            //    transform.position -= new Vector3(smoothing, 0, 0);
            //}
            //else if (hit.point.x < followTarget.position.x)
            //{
            //    transform.position += new Vector3(smoothing, 0, 0);
            //}

            ////if (hit.point.y > followTarget.position.y)
            ////{

            ////}
            ////else if (hit.point.y < followTarget.position.y)
            ////{

            ////}

            //if (hit.point.z > followTarget.position.z)
            //{
            //    transform.position -= new Vector3(0, 0, smoothing);
            //}
            //else if (hit.point.z < followTarget.position.z)
            //{
            //    transform.position += new Vector3(0, 0, smoothing);
            //}
        }
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

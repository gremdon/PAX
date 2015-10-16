using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour
{
    public void Update()
    {
        Camera();
    }
    public void Camera()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            gowCamera.enabled = false;
            map.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            gowCamera.enabled = true;
            map.enabled = false;
        }
    }

    public Camera gowCamera;
    public Camera map;
} 


//if (Input.GetKeyDown(KeyCode.M))
//{
//    Application.CaptureScreenshot(null, 5);
//}

using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Application.CaptureScreenshot(null, 5);
        }

    }
}

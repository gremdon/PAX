using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            OnGUI();
        }
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, 1600, 900), mapImage, ScaleMode.ScaleToFit);
    }

    //public Camera mapCamera;
    public Camera helicopterCamera;
    public Texture mapImage;
}


//if (Input.GetKeyDown(KeyCode.M))
//{
//    Application.CaptureScreenshot(null, 5);
//}

using UnityEngine;
using System.Collections;

public class AircraftGUI : MonoBehaviour
{
    void OnGUI()
    {
        RaycastHit groundHit;

        Physics.Raycast(player.transform.position - Vector3.up, -Vector3.up, out groundHit);
        helicopterThrottle = player.GetComponent<Aircraft>().rotorVel;

        GUI.Label(new Rect(0, 0, 128, 128), altimeter);
        // the 10 is 10 frames
        GUI.Label(new Rect(0, 128, 128, 128), throttle[(int)(helicopterThrottle * 10)]);
        GUI.Label(new Rect(40, 40, 256, 256), Mathf.Round(groundHit.distance) + " METERS ");
        GUI.Label(new Rect(20, 182, 256, 256), " ENGINE ");
        helicopterThrottle = 1.0f;
        Debug.Log(helicopterThrottle);
    }

    public GameObject player;
    private float helicopterThrottle;
    public Texture altimeter;
    public Texture[] throttle;
}

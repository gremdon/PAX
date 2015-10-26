using UnityEngine;
using System.Collections;
using System.Collections.Generic;

static public class ThreeDAudio
{
    static public AudioSource manager;

    /// <summary>
    /// So all audioClips start off 2D
    /// This function turns 2D Audio Clips into 3D
    /// </summary>
    /// <param name="audioClip">
    /// The audio that is passed in, will turn into 3D audio
    /// </param>
    static public void threeDAudio(AudioClip audioClip)
    {
        // Setting spatialBlend 0 is 2D & 1 is 3D;
        manager.spatialBlend = 1.0f;
        manager.minDistance = 1.0f;
        manager.maxDistance = 10.0f;
        manager.loop = true;
    }
}

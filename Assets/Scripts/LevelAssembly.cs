using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelAssembly : MonoBehaviour
{
    /// <summary>
    /// GameObjects that will store the prefabs loaded in from other scenes
    /// </summary>
    protected GameObject EricPuzzle;
    protected GameObject DylanPuzzle;
    protected GameObject ZacPuzzle;
    protected GameObject ShelbyPuzzle;
    protected GameObject TranPuzzle;
    protected GameObject PaulPuzzle;
    protected GameObject QuintonPuzzle;

    /// <summary>
    /// Dictionary to store a Key of type GameObject which in this case will be the Prefabs of the Puzzles
    /// for each scene.
    /// The Value to each key is a Vector3 to say where in the world space this object is suppose to be placed at
    /// when it is loaded into the hub world.
    /// </summary>
    Dictionary<GameObject, Vector3> PuzzleLocations = new Dictionary<GameObject, Vector3>();

    void FindObject(GameObject temp)
    {
        //EricPuzzle = FindObjectOfType<eric>();
        //DylanPuzzle = FindObjectOfType<dylan>();
        //ZacPuzzle = FindObjectOfType<zac>();
        //ShelbyPuzzle = FindObjectOfType<tran>();
        //TranPuzzle = FindObjectOfType<shelby>();
        //PaulPuzzle = FindObjectOfType<paul>();
        //QuintonPuzzle = FindObjectOfType<quinton>();
    }

    /// <summary>
    /// Adds new elements to the Dictionary and gives them a definition
    /// In this instance we are adding the GameObjects that represent each puzzle in the game
    /// and we are giving them the definition of there placement location in the scene
    /// </summary>
    private void DefineObjectPositions()
    {
        //Definition for EricPuzzle
        PuzzleLocations.Add(EricPuzzle, new Vector3(10, 0, 0));
        //Definition for DylanPuzzle
        PuzzleLocations.Add(DylanPuzzle, new Vector3(0, 0, 10));
        //Definition for ZacPuzzle
        PuzzleLocations.Add(ZacPuzzle, new Vector3(-10, 0, 0));
        //Definition for ShelbyPuzzle
        PuzzleLocations.Add(ShelbyPuzzle, new Vector3(0, 0, -10));
        //Definition for TranPuzzle
        PuzzleLocations.Add(TranPuzzle, new Vector3(20, 0, 0));
        //Definition for PaulPuzzle
        PuzzleLocations.Add(PaulPuzzle, new Vector3(0, 0, 20));
        //Definition for QuintonPuzzle
        PuzzleLocations.Add(QuintonPuzzle, new Vector3(-20, 0, 0));
    }

    void AssembleLevel()
    {
        foreach(KeyValuePair<GameObject, Vector3>  kvp in PuzzleLocations)
        {
            if(kvp.Key.transform.position != kvp.Value)
            {
                kvp.Key.transform.position = kvp.Value;
            }
        }
    }
}

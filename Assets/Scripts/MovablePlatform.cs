using UnityEngine;
using System.Collections;
using UnityEditor;

public class MovablePlatform : MonoBehaviour
{
	void Start ()
    {
        StartCoroutine(MoveToInit());
	}
    
    public void SetInitPos()
    {
        _intialPosistion = gameObject.transform.position;
    }
    
    public void SetSecondaryPos()
    {
        _secondaryPosistion = gameObject.transform.position;
    }

    IEnumerator MoveToInit()
    {
        while (Vector3.Distance(transform.position, _intialPosistion) > 0.5f)
        {
            transform.position = Vector3.Lerp(transform.position, _intialPosistion, _speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(_platformDelay);

        //Debug.Log("Done moving to Init");
        StartCoroutine(MoveToSecondary());

    }

    IEnumerator MoveToSecondary()
    {
        while (Vector3.Distance(transform.position, _secondaryPosistion) > 0.5f)
        {
            transform.position = Vector3.Lerp(transform.position, _secondaryPosistion, _speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(_platformDelay);

        //Debug.Log("Done moving to Secondary");
        StartCoroutine(MoveToInit());
    }

    [SerializeField]
    private Vector3 _intialPosistion;
    [SerializeField]
    private Vector3 _secondaryPosistion;

    [SerializeField]
    private float _platformDelay;
    [SerializeField]
    private float _speed;
}


[CustomEditor(typeof(MovablePlatform))]
public class MovablePlatformEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MovablePlatform myScript = (MovablePlatform)target;
        if (GUILayout.Button("Set Initial Posistion"))
        {
            myScript.SetInitPos();
        }
        if (GUILayout.Button("Set Secondary Posistion"))
        {
            myScript.SetSecondaryPos();
        }
    }
} 

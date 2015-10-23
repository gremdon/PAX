using UnityEngine;
using System.Collections;

public class MovablePlatform : MonoBehaviour
{
	void Start ()
    {
        StartCoroutine(MoveToInit());
        Messenger.AddListener<GameObject>("Chilled", OnCoolToggle);
	}
    
    public void SetInitPos()
    {
        _intialPosistion = gameObject.transform.position;
    }
    
    public void SetSecondaryPos()
    {
        _secondaryPosistion = gameObject.transform.position;
    }

    private void OnCoolToggle(GameObject go)
    {
        if(go == gameObject)
        {
            if (_chilled)
            {
                _chilled = false;
            }

            else
            {
                _chilled = true;
            }
        }
        
    }

    IEnumerator MoveToInit()
    {
        while (Vector3.Distance(transform.position, _intialPosistion) > 0.1f)
        {
            if(!_chilled)
            {
                transform.position = Vector3.Lerp(transform.position, _intialPosistion, _speed * Time.deltaTime);
                yield return null;
            }
        }

        yield return new WaitForSeconds(_platformDelay);

        //Debug.Log("Done moving to Init");
        StartCoroutine(MoveToSecondary());

    }

    IEnumerator MoveToSecondary()
    {
        while (Vector3.Distance(transform.position, _secondaryPosistion) > 0.1f)
        {
            if (!_chilled)
            {
                transform.position = Vector3.Lerp(transform.position, _secondaryPosistion, _speed * Time.deltaTime);
                yield return null;
            }
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

    private bool _chilled = false;
}




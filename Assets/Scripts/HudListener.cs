using UnityEngine; 

public class HudListener : MonoBehaviour
{
    [SerializeField]
    protected string listeningFor;

    [SerializeField]
    private bool disableOnStart;
    protected virtual void Awake()
    {
        gameObject.SetActive(!disableOnStart);
        Messenger.AddListener<string>(listeningFor, DoSomething);        
    }

    protected virtual void DoSomething(string message)
    {
    }
}

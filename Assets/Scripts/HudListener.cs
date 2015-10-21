using UnityEngine; 

public class HudListener : MonoBehaviour
{
    [SerializeField]
    protected string listeningFor;

    /// <summary>
    /// Default: Add's a <string> listener for DoSomething
    /// </summary>
    protected virtual void Awake()
    {
        //gameObject.SetActive(!disableOnStart);
        Messenger.AddListener<string>(listeningFor, DoSomething);      
    }

    protected virtual void DoSomething(string message){}
    protected virtual void DoSomething(string msga,string msgb){}
    protected virtual void DoSomething(int message) {}
    protected virtual void DoSomething(int msga,int msgb){}
}

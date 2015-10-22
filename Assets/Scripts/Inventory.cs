using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public List<Tool> items = new List<Tool>();
    public Tool current { get; private set; }
    public Tool previous { get; private set; }
    public Tool next { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tool">
    /// tool that player pick up or recieve
    /// </param>
    public void addTool(Tool tool)
    {
        items.Add(tool);
    }

    void Awake()
    {
        current = items[0];
        print(current);
    }
    
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            

            current = next;
            print(current);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            current = previous;
        }
    }
}

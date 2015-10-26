using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public List<Tool> items = new List<Tool>();
    public Tool current { get; private set; }
    private Tool previous { get; set; }
    private Tool next { get; set; }

    int currentIndex;
    int maxItems;

    /// <summary>
    /// Add gameobject to the list
    /// </summary>
    /// <param name="tool">
    /// tool that player pick up or recieve
    /// </param>
    public void AddTool(Tool tool)
    {
        items.Add(tool);
    }

    /// <summary>
    /// imcrement the list and go to the next tool
    /// </summary>
    public void NextTool()
    {
        currentIndex = items.IndexOf(current);
        maxItems = items.Count - 1;
        if (currentIndex == maxItems)
        {
            next = items[0];
        }
        else
        { next = items[currentIndex + 1]; }

        current = next;
        print(current);
    }

    /// <summary>
    /// decrement the list and go back to the previous tool
    /// </summary>
    public void PreviousTool()
    {
        currentIndex = items.IndexOf(current);
        maxItems = items.Count - 1;
        if (currentIndex == 0)
        {
            previous = items[maxItems];
        }
        else
        { previous = items[currentIndex - 1]; }

        current = previous;
        print(current);
    }


    void Awake()
    {
        current = items[3];
        print(current);
    }

    

    
}

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public List<Tool> items = new List<Tool>();
    
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
    
    
}

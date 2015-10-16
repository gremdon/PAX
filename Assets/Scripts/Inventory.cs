using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Inventory : MonoBehaviour
{
    List<GameObject> items = new List<GameObject>();

    public void addTool(GameObject tool)
    {
        items.Add(tool);
    }
	
    public void removeTool(GameObject tool)
    {
        items.Remove(tool);
    }

    void accessTool(GameObject tool)
    {
        
    }

    void displayTool()
    {
       
    }
}

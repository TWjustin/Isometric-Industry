using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farm : MonoBehaviour
{
    public BuildingSO buildingSO;
    public Text farmName;
    public Text executionText;
    
    private void Start()
    {
        buildingSO = transform.parent.GetComponent<Building>().buildingSO;
        SetText(farmName, executionText);
    }
    
    private void SetText(Text farmName, Text executionText)
    {
        farmName.text = buildingSO.buildingName;
        executionText.text = buildingSO.execution;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private BuildingSO buildingSO;
    public ProductTimer productTimer;
    
    public Text farmName;
    public Text executionText;
    public GameObject progressBar;
    
    private void Start()
    {
        buildingSO = GetComponentInParent<Building>().buildingSO;
        SetText(farmName, executionText);
    }
    
    private void SetText(Text farmName, Text executionText)
    {
        farmName.text = buildingSO.buildingName;
        executionText.text = buildingSO.execution;
        if (productTimer.inProgress)
        {
            progressBar.SetActive(true);
        }
        else
        {
            progressBar.SetActive(false);
        }
    }
}

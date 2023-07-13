using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    private GridBuildingSystem gridBuildingSystem;
    private Building building;

    public float offset = 0.03f;
    
    private void Start()
    {
        gridBuildingSystem = GridBuildingSystem.current;
        building = transform.parent.gameObject.GetComponent<Building>();
    }

    public void Settle()
    {
        GridLayout gridLayout = gridBuildingSystem.gridLayout;
        Building temp = gridBuildingSystem.temp;
        
        if (temp.CanBePlaced())
        {
            Vector3 cellPos = gridLayout.LocalToCell(temp.transform.position);
            temp.transform.localPosition = gridLayout.CellToLocalInterpolated(cellPos 
                                                                              + new Vector3(offset, offset, 0));
            temp.Place();

            Buy.Instance._Buy(building.buildingSO);
            Buy.Instance.AddPeople(building.buildingSO);
            Destroy(gameObject);
        }
    }

    public void Rotate()
    {
        
    }

    public void Cancel()
    {
        gridBuildingSystem.ClearArea();
        Destroy(transform.parent.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUI : MonoBehaviour
{
    private GridBuildingSystem gridBuildingSystem;
    
    public float offset = 0.03f;

    void Start()
    {
        gridBuildingSystem = GridBuildingSystem.current;
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
        }
        
        Destroy(gameObject);
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

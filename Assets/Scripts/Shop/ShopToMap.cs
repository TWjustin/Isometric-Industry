using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopToMap : MonoBehaviour
{
    private GridBuildingSystem gridBuildingSystem;
    private GameObject shop;
    public GameObject building;
    
    private void Start()
    {
        gridBuildingSystem = GridBuildingSystem.current;
        shop = GameObject.Find("Shop");
    }

    public void InitializeBuilding()
    {
        gridBuildingSystem.InitializeWithBuilding(building);
        shop.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopToMap : MonoBehaviour
{
    private GridBuildingSystem gridBuildingSystem;
    private Building building;
    private GameObject shop;
    public GameObject buildingToInit;
    
    private void Start()
    {
        gridBuildingSystem = GridBuildingSystem.current;
        shop = GameObject.Find("Shop");
        building = buildingToInit.GetComponent<Building>();
        GetComponentsInChildren<Text>()[1].text = building.price.ToString();
    }

    public void InitializeBuilding()
    {
        gridBuildingSystem.InitializeWithBuilding(buildingToInit);
        shop.SetActive(false);
    }
}

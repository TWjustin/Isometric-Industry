using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopToMap : MonoBehaviour
{
    public BuildingSO buildingSO;
    
    private GridBuildingSystem gridBuildingSystem;
    private GameObject shop;
    
    public Image buildingImage;
    public Text buildingNameText;
    public Text buildingPriceText;

    private void Start()
    {
        gridBuildingSystem = GridBuildingSystem.current;
        shop = GameObject.Find("Shop");
        
        buildingImage.sprite = buildingSO.buildingSprite;
        buildingNameText.text = buildingSO.buildingName;
        buildingPriceText.text = buildingSO.price.ToString();
    }

    public void InitializeBuilding()
    {
        gridBuildingSystem.InitializeWithBuilding(buildingSO.buildingPrefab);
        shop.SetActive(false);
    }
}

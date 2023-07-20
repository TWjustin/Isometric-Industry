using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmShopItem : MonoBehaviour
{
    public FarmingSO farmingSO;
    
    public Image itemImage;
    public Text itemName;
    public Text priceText;

    private void Start()
    {
        itemImage.sprite = farmingSO.cropIcon;
        itemName.text = farmingSO.cropName;
        priceText.text = farmingSO.price.ToString();
    }
}

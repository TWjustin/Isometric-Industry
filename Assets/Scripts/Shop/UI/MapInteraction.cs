using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInteraction : MonoBehaviour
{
    public GameObject shop;
    
    public void Update()
    {
        if (shop.activeSelf)
        {
            Input.simulateMouseWithTouches = false;
        }
        else
        {
            Input.simulateMouseWithTouches = true;
        }
    }
}

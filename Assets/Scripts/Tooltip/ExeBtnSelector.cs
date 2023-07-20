using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExeBtnSelector : MonoBehaviour
{
    public GameObject plantBtn;
    public GameObject skipBtn;
    public GameObject harvestBtn;
    
    public void SelectPlant()
    {
        plantBtn.SetActive(true);
        skipBtn.SetActive(false);
        harvestBtn.SetActive(false);
    }
    
    public void SelectSkip()
    {
        plantBtn.SetActive(false);
        skipBtn.SetActive(true);
        harvestBtn.SetActive(false);
    }
    
    public void SelectHarvest()
    {
        plantBtn.SetActive(false);
        skipBtn.SetActive(false);
        harvestBtn.SetActive(true);
    }
}

using UnityEngine;

public class StartRoad : MonoBehaviour
{
    public void StartPlace()
    {
        Buy.Instance.CloseShop();
        GameObject.Find("RoadPlacement").GetComponent<RoadPlacement>().enabled = true;
        Camera.main.GetComponent<CameraMovement>().enabled = false;
    }
    
    public static void EndPlace()
    {
        GameObject.Find("RoadPlacement").GetComponent<RoadPlacement>().enabled = false;
        Camera.main.GetComponent<CameraMovement>().enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipTrigger : MonoBehaviour // 負責顯示tooltip
{
    public GameObject tooltip;
    private GameObject prevGameObject;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                if (hit.collider != null)
                {
                    GameObject touchedObject = hit.collider.gameObject;
                    if (touchedObject.CompareTag("Building") && touchedObject.GetComponent<Building>().isMoving == false && !HasActiveTooltip())
                    {
                        touchedObject.transform.GetChild(0).gameObject.SetActive(true);
                        touchedObject.GetComponentInChildren<ProductTimer>().InitializeWindow();
                        prevGameObject = touchedObject;
                    }
                    else if(touchedObject.CompareTag("Building") && touchedObject.GetComponent<Building>().isMoving == false && HasActiveTooltip())
                    {
                        prevGameObject.transform.GetChild(0).gameObject.SetActive(false);
                        touchedObject.transform.GetChild(0).gameObject.SetActive(true);
                        touchedObject.GetComponentInChildren<ProductTimer>().InitializeWindow();
                        prevGameObject = touchedObject;
                    }
                }
                else if (HasActiveTooltip())
                {
                    prevGameObject.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
    
    private bool HasActiveTooltip()
    {
        return GameObject.Find("Tooltip") != null;
    }
}

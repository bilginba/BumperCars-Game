using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrakeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerController.instance.isReverse = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerController.instance.isReverse = true;
    }
}

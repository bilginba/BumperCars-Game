using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnRightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerController.instance.isRightPressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerController.instance.isRightPressed = true;
    }
}

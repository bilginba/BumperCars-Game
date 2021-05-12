using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnLeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerController.instance.isLeftPressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerController.instance.isLeftPressed = true;
    }
}

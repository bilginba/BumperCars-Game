using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AccelerateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerController.instance.isAccelerated = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerController.instance.isAccelerated = true;
    }
}

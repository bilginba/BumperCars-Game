using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BreakButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerController.instance.isReverse = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerController.instance.isReverse = true;
    }
}

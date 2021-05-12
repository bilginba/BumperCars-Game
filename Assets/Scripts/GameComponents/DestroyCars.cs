using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCars : MonoBehaviour
{
    public static DestroyCars instance; 
    public float totalEnemyCars;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        totalEnemyCars = GameObject.Find("AI_Cars").transform.childCount; // Takes car count from AI_Cars GameObject
    }

    public void DecreaseCarCount()
    {
        totalEnemyCars -= 1;
    }

    
    void Update()
    {
        if(GameObject.Find("AI_Cars").transform.childCount == 0)
        {
            // Show Win Popup if GameOver Popup is not active
            if (UIManager.instance.gameObjects.gameOverPopUp.activeSelf == false)
            {
                UIManager.instance.gameObjects.winPopUp.SetActive(true);
            }
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Texts texts;
    public GameObjects gameObjects;
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
    }

    void Update()
    {
        // Shows remaining car count on the screen
        if(DestroyCars.instance.totalEnemyCars == 1) texts.carCountTxt.text = DestroyCars.instance.totalEnemyCars.ToString() + " car left!";
        else texts.carCountTxt.text = DestroyCars.instance.totalEnemyCars.ToString() + " cars left!";
    }


    [System.Serializable]
    public class Texts
    {
        public TextMeshProUGUI carCountTxt;
    }

    [System.Serializable]
    public class GameObjects
    {

        public GameObject gameOverPopUp, winPopUp;
    }
}

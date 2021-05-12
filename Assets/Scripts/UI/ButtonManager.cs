using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void RestartScene()
    {
        // Restarts the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

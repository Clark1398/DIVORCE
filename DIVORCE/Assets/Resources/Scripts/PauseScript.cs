using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public bool isPaused;

    public void Continue()
    {
        Time.timeScale = 1;
        isPaused = false;
        this.gameObject.SetActive(false);      
    }

    public void MainMenu()
    {
        Time.timeScale = 1;

        if (GameObject.Find("GameInfoObject") != null)
        {
            Destroy(GameObject.Find("GameInfoObject"));
            Destroy(GameObject.Find("EarthFolder"));
            Destroy(GameObject.Find("MarsFolder"));
            Destroy(GameObject.Find("VenusFolder"));
        }
        else
        {
            Destroy(GameObject.Find("GameInfoObject DDL"));
            Destroy(GameObject.Find("EarthFolder DDL"));
            Destroy(GameObject.Find("MarsFolder DDL"));
            Destroy(GameObject.Find("VenusFolder DDL"));
        }

        SceneManager.LoadScene("MainMenuScene");
    }
}

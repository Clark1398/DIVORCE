using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public void Continue()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);      
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
        Destroy(GameObject.Find("GameInfoObject"));
        Destroy(GameObject.Find("EarthFolder"));
        Destroy(GameObject.Find("MarsFolder"));
        Destroy(GameObject.Find("VenusFolder"));
    }
}

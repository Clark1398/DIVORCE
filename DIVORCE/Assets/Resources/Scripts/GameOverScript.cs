using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    Stats statsScript;
    Text textbox;

    void Start()
    {
        statsScript = GameObject.Find("GameInfoObject DDL").GetComponent<Stats>();
        textbox = GameObject.Find("Textbox").GetComponent<Text>();

        Text();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Text()
    {
        textbox.text = statsScript.gameOver;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}

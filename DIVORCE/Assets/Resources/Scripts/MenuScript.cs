using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public GameObject loadingPanel;

    public Animator anim;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StartCoroutine(Fade());
    }

    public void StartGame()
    {
        loadingPanel.gameObject.SetActive(true);
        SceneManager.LoadScene("DIVORCE");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (GameObject.Find("GameInfoObject") != null)
        {
            Destroy(GameObject.Find("GameInfoObject"));
            Destroy(GameObject.Find("Earth Folder"));
            Destroy(GameObject.Find("Mars Folder"));
            Destroy(GameObject.Find("Venus Folder"));
        }
    }

    IEnumerator Fade()
    {
        anim.Play("Fade Back");

        yield return new WaitForSeconds(1.75f);

        GameObject.Find("Image").SetActive(false);
    }
}

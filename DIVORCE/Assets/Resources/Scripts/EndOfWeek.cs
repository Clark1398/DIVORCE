using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EndOfWeek : MonoBehaviour
{
    Stats statsScript;

    int counter;

    public GameObject goodDeal, badDeal, noDeal, noIndependence;

    public AudioSource audioSource;

    public AudioClip goodDealAudio;
    public AudioClip badDealAudio;
    public AudioClip noDealAudio;
    public AudioClip noIndependenceAudio;

    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        statsScript = GameObject.FindObjectOfType<Stats>();

        EndOfWeekCheck();

        audioSource.Play();
    }

    public void EndOfWeekCheck()
    {
        for (int i = 0; i < statsScript.stats.Length; i++)
        {
            if (statsScript.stats[i] >= 50)
            {
                counter++;
            }
        }

        Debug.Log(counter);

        if (statsScript.dayFiveFax)
        {
            if (counter >= 4)
            {
                goodDeal.SetActive(true);
                audioSource.clip = goodDealAudio;
                
            }
            else
            {
                badDeal.SetActive(true);
                audioSource.clip = badDealAudio;
            }
        }
        else if (statsScript.dayFiveBin)
        {
            if (statsScript.stats[5] >= 50)
            {
                noIndependence.SetActive(true);
                audioSource.clip = noIndependenceAudio;
            }
            else
            {
                noDeal.SetActive(true);
                audioSource.clip = noDealAudio;
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.gameObject.SetActive(true);
        }
    }
}

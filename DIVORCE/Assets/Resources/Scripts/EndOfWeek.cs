using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

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
            if (i >= 50)
            {
                counter++;
            }
        }

        Debug.Log(counter);

        if (statsScript.dayFiveFax)
        {
            if (counter >= 4)
            {
                Debug.Log("good deal");
                goodDeal.SetActive(true);
                audioSource.clip = goodDealAudio;
                
            }
            else
            {
                Debug.Log("bad deal");
                badDeal.SetActive(true);
                audioSource.clip = badDealAudio;
            }
        }
        else if (statsScript.dayFiveBin)
        {
            if (statsScript.stats[5] >= 50)
            {
                Debug.Log("no independence");
                noIndependence.SetActive(true);
                audioSource.clip = noIndependenceAudio;
            }
            else
            {
                Debug.Log("no deal");
                noDeal.SetActive(true);
                audioSource.clip = noDealAudio;
            }
        }
    }
}

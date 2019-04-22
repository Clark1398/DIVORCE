using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndOfWeek : MonoBehaviour
{
    Stats statsScript;

    int counter;

    public VideoPlayer videoPlayer;

    public VideoClip goodDeal;
    public VideoClip badDeal;
    public VideoClip noDeal;
    public VideoClip noIndependence;

    public AudioSource audioSource;

    public AudioClip goodDealAudio;
    public AudioClip badDealAudio;
    public AudioClip noDealAudio;
    public AudioClip noIndependenceAudio;

    // Start is called before the first frame update
    void Start()
    {
        statsScript = GameObject.FindObjectOfType<Stats>();

        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

        EndOfWeekCheck();

        videoPlayer.Play();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
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
                videoPlayer.clip = goodDeal;
                audioSource.clip = goodDealAudio;
                
            }
            else
            {
                Debug.Log("bad deal");
                videoPlayer.clip = badDeal;
                audioSource.clip = badDealAudio;
            }
        }
        else if (statsScript.dayFiveBin)
        {
            if (statsScript.stats[5] >= 50)
            {
                Debug.Log("no independence");
                videoPlayer.clip = noIndependence;
                audioSource.clip = noIndependenceAudio;
            }
            else
            {
                Debug.Log("no deal");
                videoPlayer.clip = noDeal;
                audioSource.clip = noDealAudio;
            }
        }
    }
}

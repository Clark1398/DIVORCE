using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    [Header("Phone Calls")]
    [TextArea(3, 154)]
    public string[] phoneCalls;
    public Text phoneCallText;
    public string phonecall;

    [Header("Booleans")]
    public bool isRinging;
    public bool timeUntilRingTimerActive;
    public bool ringTimerActive;
    public bool stopAudio;
    public bool newAudio;
    public bool firstCall;
    public bool callMissed;
    public bool dayOne;
    public bool phoneIsActive = false;

    [Header ("Timers")]
    public float timer;
    public float ringTimer;

    [Header("Audio")]
    public AudioClip phoneRing;

    [Header("Day 1 Audio")]
    public AudioClip marsPhoneCall;
    public AudioClip venusPhoneCall;

    [Header("Day 2 Audio")]
    public AudioClip wifePhoneCall;
    public AudioClip earthPhoneCall;

    [Header("Day 3 Audio")]
    public AudioClip wifePhoneCallHappy;
    public AudioClip wifePhoneCallAngry;
    public AudioClip marsPhoneCall2;
    public AudioClip earthPhoneCall2;

    [Header("Day 4 Audio")]
    public AudioClip wifePhoneCallHappy2;
    public AudioClip wifePhoneCallAngry2;
    public AudioClip venusPhoneCall2;

    public List<float> faxChanges = new List<float>();
    public List<string> faxChangedNames = new List<string>();

    public List<float> binChanges = new List<float>();
    public List<string> binChangedNames = new List<string>();

    public int calls = 0;

    public AudioSource audioSource;

    GameObject playerObj;

    InteractionScript interactionScript;
    Stats statsScript;
    DayOneScript dayOneScript;
    //RobotDialogueTrigger robotDialogueTrigger;

    public Renderer rend;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        interactionScript = playerObj.GetComponent<InteractionScript>();
        dayOneScript = FindObjectOfType<DayOneScript>();

        if (GameObject.Find("GameInfoObject DDL") != null)
        {
            statsScript = GameObject.Find("GameInfoObject DDL").GetComponent<Stats>();
        }
        else
        {
            statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();
        }

        //robotDialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();

        //timeUntilRingTimerActive = true;
        ringTimerActive = false;
        isRinging = false;

        if (statsScript.day == 1)
        {
            firstCall = true;
        }
        else
        {
            firstCall = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (statsScript == null)
        {
            statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();
        }

        if (dayOne)
        {
            if (dayOneScript.phoneActive == true)
            {   
                audioSource.clip = phoneRing;
                audioSource.Play();

                isRinging = true;
                //timeUntilRingTimerActive = false;

                if (firstCall)
                {                  
                    phoneCallText.GetComponent<Text>().text = phoneCalls[0];

                    faxChanges.Add(0.4f);
                    faxChanges.Add(10);
                    faxChanges.Add(-5);

                    faxChangedNames.Add("Revenue");
                    faxChangedNames.Add("Mars_Relationship");
                    faxChangedNames.Add("Public_Support");

                    binChanges.Add(-10);
                    binChanges.Add(10);

                    binChangedNames.Add("Mars_Relationship");
                    binChangedNames.Add("Autonomy");

                    phonecall = "Mars Helium";

                }
                else if (!firstCall)
                {
                    rend.material.SetFloat("Vector1_B78C4234", 0.5f);

                    phoneCallText.GetComponent<Text>().text = phoneCalls[1];
                    ringTimerActive = true;

                    faxChanges.Add(10);
                    faxChanges.Add(-5);
                    faxChanges.Add(-5);

                    faxChangedNames.Add("Venus_Relationship");
                    faxChangedNames.Add("System_Tension");
                    faxChangedNames.Add("Autonomy");

                    binChanges.Add(-10);
                    binChanges.Add(10);

                    binChangedNames.Add("Venus_Relationship");
                    binChangedNames.Add("Public_Support");

                    phonecall = "Venus Moon Territory";
                }

                calls++;
                dayOneScript.phoneActive = false;
            }
        }
        else if (phoneIsActive == true)
        {
            audioSource.clip = phoneRing;
            audioSource.Play();
            isRinging = true;
            calls++;
            rend.material.SetFloat("Vector1_B78C4234", 0.5f);

            if (statsScript.day == 2)
            {
                if (calls == 1)
                {
                    phoneCallText.GetComponent<Text>().text = phoneCalls[2];
                }
                else if (calls == 2)
                {
                    phoneCallText.GetComponent<Text>().text = phoneCalls[3];
                    ringTimerActive = true;

                    faxChanges.Add(10);
                    faxChanges.Add(-10);
                    faxChanges.Add(-10);

                    faxChangedNames.Add("Earth_Relationship");
                    faxChangedNames.Add("System_Tension");
                    faxChangedNames.Add("Autonomy");

                    binChanges.Add(-10);
                    binChanges.Add(20);
                    binChanges.Add(10);

                    binChangedNames.Add("Earth_Relationship");
                    binChangedNames.Add("System_Tension");
                    binChangedNames.Add("Autonomy");

                    phonecall = "Earth Nuclear Inspectors";
                }
            }
            else if (statsScript.day == 3)
            {
                if (calls == 1)
                {
                    phoneCallText.GetComponent<Text>().text = phoneCalls[4];
                }
                else if (calls == 2)
                {
                    phoneCallText.GetComponent<Text>().text = phoneCalls[5];
                    ringTimerActive = true;

                    faxChanges.Add(15);
                    faxChanges.Add(0.5f);
                    faxChanges.Add(10);

                    faxChangedNames.Add("Mars_Relationship");
                    faxChangedNames.Add("Revenue");
                    faxChangedNames.Add("System_Tension");

                    binChanges.Add(-10);
                    binChanges.Add(-10);
                    binChanges.Add(-10);

                    binChangedNames.Add("Mars_Relationship");
                    binChangedNames.Add("Autonomy");
                    binChangedNames.Add("System_Tension");

                    phonecall = "Mars Mining";
                }
                else if (calls == 3)
                {
                    phoneCallText.GetComponent<Text>().text = phoneCalls[6];
                    ringTimerActive = true;

                    faxChanges.Add(10);
                    faxChanges.Add(5);
                    faxChanges.Add(-0.3f);
                    faxChanges.Add(-10);

                    faxChangedNames.Add("Earth_Relationship");
                    faxChangedNames.Add("Public_Support");
                    faxChangedNames.Add("Revenue");
                    faxChangedNames.Add("Autonomy");

                    binChanges.Add(-10);
                    binChanges.Add(-5);
                    binChanges.Add(10);

                    binChangedNames.Add("Earth_Relationship");
                    binChangedNames.Add("Public_Support");
                    binChangedNames.Add("Autonomy");

                    phonecall = "Earth Royal Wedding";
                }
            }
            if (statsScript.day == 4)
            {
                if (calls == 1)
                {
                    phoneCallText.GetComponent<Text>().text = phoneCalls[7];
                }
                else if (calls == 2)
                {
                    phoneCallText.GetComponent<Text>().text = phoneCalls[8];
                    ringTimerActive = true;

                    faxChanges.Add(10);
                    faxChanges.Add(0.5f);
                    faxChanges.Add(-10);
                    faxChanges.Add(-10);

                    faxChangedNames.Add("Venus_Relationship");
                    faxChangedNames.Add("Revenue");
                    faxChangedNames.Add("Public_Support");
                    faxChangedNames.Add("Autonomy");

                    binChanges.Add(-10);
                    binChanges.Add(-0.5f);
                    binChanges.Add(10);
                    binChanges.Add(10);

                    binChangedNames.Add("Venus_Relationship");
                    binChangedNames.Add("Revenue");
                    binChangedNames.Add("Public_Support");
                    binChangedNames.Add("Autonomy");

                    phonecall = "Venus Interplanetary Businesses";
                }
            }

            phoneIsActive = false;
        }

        if (timeUntilRingTimerActive)
        {
            timer -= Time.deltaTime;           
        }
        
        if (timer < 0)
        {
            phoneIsActive = true;
            timeUntilRingTimerActive = false;
        }

        //if (phoneIsActive)
        //{
        //    if (statsScript.day == 2)
        //    {
        //        audioSource.clip = phoneRing;
        //        audioSource.Play();
        //        isRinging = true;
        //        ringTimerActive = true;
        //        phoneIsActive = false;

        //        if (firstCall)
        //        {
        //            phoneCallText.GetComponent<Text>().text = phoneCalls[1];
        //        }
        //        else
        //        {
        //            phoneCallText.GetComponent<Text>().text = phoneCalls[2];
        //        }               
        //    }
        //}

        if (ringTimerActive == true)
        {
            ringTimer -= Time.deltaTime;
        }

        if (ringTimer < 0)
        {
            interactionScript.answered = false;
            statsScript.phone2Answered = false;
            ringTimerActive = false;
            isRinging = false;
            stopAudio = true;
            callMissed = true;
            firstCall = false;
            ringTimer = 15;

            if (dayOne)
            {
                statsScript.stats[7] -= 5;
                dayOneScript.phoneActive = false;
            }
            else if (statsScript.day == 2)
            {
                if (calls == 2)
                {
                    statsScript.wifeCounter++;
                    statsScript.stats[5] -= 5;
                    statsScript.stats[4] += 5;
                    phoneIsActive = false;
                }
            }
            else if (statsScript.day == 3)
            {
                if (calls == 2)
                {
                    statsScript.stats[6] -= 5;
                }
                else if (calls == 3)
                {
                    statsScript.stats[5] -= 5;
                }
            }
            else if (statsScript.day == 4)
            {
                if (calls == 2)
                {
                    statsScript.stats[7] -= 5;
                }
            }
        }

        if (dayOne)
        {
            if (dayOneScript.answered == true && newAudio == true)
            {
                isRinging = false;

                if (firstCall)
                {
                    audioSource.clip = marsPhoneCall;
                    audioSource.PlayOneShot(marsPhoneCall);
                }
                else
                {
                    audioSource.clip = venusPhoneCall;
                    audioSource.PlayOneShot(venusPhoneCall);
                }
                newAudio = false;
                dayOneScript.phoneActive = false;
                ringTimer = 15;
            }

            if (callMissed == true && stopAudio == true)
            {
                audioSource.Stop();
                callMissed = false;
                ringTimer = 15;
                dayOneScript.policyIntractable = true;
            }
        }

        else if (statsScript.day > 1)
        {
            if (interactionScript.answered == true && newAudio == true)
            {
                isRinging = false;

                audioSource.Stop();
                interactionScript.answered = false;
                phoneIsActive = false;
                newAudio = false;

                if (statsScript.day == 2)
                {
                    if (calls == 1)
                    {
                        audioSource.clip = wifePhoneCall;
                        audioSource.PlayOneShot(wifePhoneCall);
                    }
                    else if (calls == 2)
                    {
                        audioSource.clip = earthPhoneCall;
                        audioSource.PlayOneShot(earthPhoneCall);
                    }
                }
                else if (statsScript.day == 3)
                {
                    if (calls == 1)
                    {
                        if (statsScript.wifeCounter > 0)
                        {
                            audioSource.clip = wifePhoneCallHappy;
                            audioSource.PlayOneShot(wifePhoneCallHappy);
                        }
                        else
                        {
                            audioSource.clip = wifePhoneCallAngry;
                            audioSource.PlayOneShot(wifePhoneCallAngry);
                        }
                    }
                    else if (calls == 2)
                    {
                        audioSource.clip = marsPhoneCall2;
                        audioSource.PlayOneShot(marsPhoneCall2);
                    }
                }
                else if (statsScript.day == 4)
                {
                    if (calls == 1)
                    {
                        if (statsScript.wifeCounter2 > 0)
                        {
                            audioSource.clip = wifePhoneCallHappy2;
                            audioSource.PlayOneShot(wifePhoneCallHappy2);
                        }
                        else
                        {
                            audioSource.clip = wifePhoneCallAngry2;
                            audioSource.PlayOneShot(wifePhoneCallAngry2);
                        }
                    }
                    else if (calls == 2)
                    {
                        audioSource.clip = venusPhoneCall2;
                        audioSource.PlayOneShot(venusPhoneCall2);
                    }
                }
            }
        }

        //if (callMissed == true && stopAudio == true)
        //{
        //    audioSource.Stop();
        //    audioSource2.Stop();
        //    callMissed = false;
        //    statsScript.stats[7] -= 5;
        //    ringTimer = 15;
        //    timer = 7;
        //    timeUntilRingTimerActive = true;           
        //}

        if (stopAudio == true)
        {
            audioSource.Stop();
            stopAudio = false;
        }
    }
}

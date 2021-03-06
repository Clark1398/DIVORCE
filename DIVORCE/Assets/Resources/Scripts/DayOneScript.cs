﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DayOneScript : MonoBehaviour {

    GameObject paper;
    GameObject gameInfoObject;

    public bool wbActive = false;
    public bool pcActive = false;
    public bool faxActive = false;
    public bool phoneLActive = false;
    public bool clockActive = false;
    public bool policyActive = false;

    public bool pcIntractable = false;
    public bool phoneIntractable = false;
    public bool policyIntractable = false;
    public bool conferenceCallInteractable = false;

    public bool folder = false;
    public bool holding, holdingPolicy, holdingPhone, answeredPhone;
    public bool policy = false;
    public bool firstFolder = true;

    public bool firstPolicy = true;
    public bool withinAnswerDistance = false;
    public bool answered = false;
    public bool phoneActive = false;
    bool phoneCanvasOn = false;
    bool firstCallEnacted = false;

    public Text info;

    public GameObject pcCamera, chairCamera;
    public GameObject canvas, earthCanvas, marsCanvas, venusCanvas, moonCanvas;
    public GameObject earthCamera, marsCamera, venusCamera, folderCamera;
    public GameObject conferenceCamera;
    public GameObject prefab;
    public GameObject obj;
    public GameObject phonePanel;
    public GameObject robotPanel;
    public GameObject earthCharacter;

    public Transform spawnPos;

    Color red = Color.red;
    Color green = Color.green;

    public Light doorLight1;
    public Light doorLight2;

    public int uses = 0;

    Stats statsScript;
    RobotDialogueTrigger robotDialogueTrigger;
    RobotDialogueManager robotDialogueManager;
    DialogueManager dialogueManager;
    DialogueTrigger dialogueTrigger;
    FolderScript folderScript;
    PolicyScript policyScript;
    Phone phoneScript;
    PolicyChoices policyChoices;
    public InteractionScript interactionScript;

    AudioSource trashAudio, faxAudio;

    public AudioSource conferenceCallAudio;

    public AudioClip trashFX, faxFX, conferenceCallFX;

    public Renderer chair, folderR, phone, conf;

    public Animator bin;

    void Start()
    {
        robotDialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();
        robotDialogueManager = FindObjectOfType<RobotDialogueManager>();
        phoneScript = FindObjectOfType<Phone>();
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();
        dialogueManager = FindObjectOfType<DialogueManager>();

        robotPanel = GameObject.Find("RobotPanel");

        trashAudio = GameObject.FindGameObjectWithTag("Bin").GetComponent<AudioSource>();
        faxAudio = GameObject.FindGameObjectWithTag("Fax").GetComponent<AudioSource>();
        conferenceCallAudio = GameObject.FindGameObjectWithTag("ConferenceCall").GetComponent<AudioSource>();

        doorLight1.color = red;
        doorLight2.color = red;


        paper = (GameObject)Resources.Load("Policy", typeof(GameObject));

        if (GameObject.Find("GameInfoObject DDL") != null)
        {
            gameInfoObject = GameObject.Find("GameInfoObject DDL");
            pcCamera.GetComponent<CameraScript>().statsScript = GameObject.Find("GameInfoObject DDL").GetComponent<Stats>();
        }
        else
        {
            gameInfoObject = GameObject.Find("GameInfoObject");
        }

        statsScript = gameInfoObject.GetComponent<Stats>();
        policyChoices = gameInfoObject.GetComponent<PolicyChoices>();

        if (statsScript.day > 1)
        {
            Load();
        }
        else
        {
            robotDialogueTrigger.TriggerRobotDialogue1();
        }
    }

    void Update()
    {
        if (GameObject.Find("Pause") == null)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        //Sets up a raycast for the position of the mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        //If the ray hits an object
        if (Physics.Raycast(ray, out hit))
        {
            //Get the distance to the object from the current position
            float dist = Vector3.Distance(transform.position, hit.collider.gameObject.transform.position);

            if (hit.collider.gameObject.tag == "Chair" && pcIntractable)
            {
                //If the distance to the object is less than 2.5
                if (dist <= 2.5f)
                {
                    info.text = "Press 'E' to sit";
                    info.gameObject.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        info.gameObject.SetActive(false);
                        chairCamera.SetActive(true);
                        chair.material.SetFloat("Vector1_B78C4234", 100f);
                    }
                }
            }
            else if (hit.collider.gameObject.tag == "Folder" && policyIntractable)
            {
                if (hit.collider.transform.parent.gameObject.name == "EarthFolder" && firstFolder)
                {
                    //If the distance to the object is less than 2.5
                    if (dist <= 2.5f)
                    {
                        info.text = "Press 'E' to open";
                        info.gameObject.SetActive(true);
                    }

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        RotationScript rot = hit.collider.transform.parent.gameObject.GetComponent<RotationScript>();

                        rot.startPos = GameObject.Find("EarthStartPos").transform;
                        rot.endPos = GameObject.Find("EndPos").transform;
                        rot.startTime = Time.time;
                        rot.journeyLength = Vector3.Distance(rot.startPos.position, rot.endPos.position);

                        folderCamera = earthCamera;

                        StartCoroutine(FolderOpen(rot));

                        marsCanvas.SetActive(false);
                        venusCanvas.SetActive(false);

                        folderR.material.SetFloat("Vector1_B78C4234", 100f);
                    }


                }
                else if (!firstFolder)
                {
                    //If the distance to the object is less than 2.5
                    if (dist <= 2.5f)
                    {
                        info.text = "Press 'E' to open";
                        info.gameObject.SetActive(true);
                    }

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        RotationScript rot = hit.collider.transform.parent.gameObject.GetComponent<RotationScript>();

                        rot.endPos = GameObject.Find("EndPos").transform;

                        if (hit.collider.transform.parent.gameObject.name == "EarthFolder")
                        {
                            rot.startPos = GameObject.Find("EarthStartPos").transform;
                            folderCamera = earthCamera;
                            marsCanvas.SetActive(false);
                            venusCanvas.SetActive(false);
                        }
                        else if (hit.collider.transform.parent.gameObject.name == "MarsFolder")
                        {
                            rot.startPos = GameObject.Find("MarsStartPos").transform;
                            folderCamera = marsCamera;
                            earthCanvas.SetActive(false);
                            venusCanvas.SetActive(false);
                        }
                        else if (hit.collider.transform.parent.gameObject.name == "VenusFolder")
                        {
                            rot.startPos = GameObject.Find("VenusStartPos").transform;
                            folderCamera = venusCamera;
                            earthCanvas.SetActive(false);
                            marsCanvas.SetActive(false);
                        }

                        rot.startTime = Time.time;
                        rot.journeyLength = Vector3.Distance(rot.startPos.position, rot.endPos.position);

                        StartCoroutine(FolderOpen(rot));
                    }
                }
            }
            else if (hit.collider.gameObject.tag == "Fax" && holding)
            {
                if (dist <= 2.5f)
                {
                    info.text = "Press 'E' to enact";
                    info.gameObject.SetActive(true);

                    //If the player hits F then Destroy the Policy, descrease the time and the stats, 
                    //Update the PC screen and set holding to false AND set answered to false so the
                    //phone can ring again
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(prefab);
                        holding = !holding;

                        for (int i = 0; i < policyScript.decreases.Length; i++)
                        {
                            statsScript.stats[i] += policyScript.decreases[i];
                        }

                        folderScript.buttons = policyScript.buttonAmount;
                        folderScript.type = policyScript.type;

                        policyChoices.movementChoice = policyScript.movement;
                        policyChoices.planetType = policyScript.pfm;

                        folderScript.DisableButton();
                        statsScript.UpdateScreen();
                        answered = false;
                        statsScript.TimeForward();

                        faxAudio.clip = faxFX;
                        faxAudio.PlayOneShot(faxFX);

                        if (policy)
                        {
                            statsScript.chosenPolicies.Add(policyScript.chosenPolicy);
                            statsScript.chosenPlanets.Add(policyScript.planet);

                            statsScript.actionsText = statsScript.actionsText + "\n" + policyScript.chosenPolicy + " for " + policyScript.planet;

                            uses++;
                            policy = false;
                        }
                        else if (holdingPhone)
                        {
                            statsScript.phonecallAccept.Add(phoneScript.phonecall);

                            statsScript.actionsText = statsScript.actionsText + "\n" + "Phone call from " + phoneScript.phonecall + " accepted";

                            holdingPhone = false;
                        }

                        if (firstPolicy)
                        {
                            phoneActive = true;
                            phoneScript.firstCall = true;
                            phoneScript.dayOne = true;
                            firstFolder = false;
                            robotDialogueTrigger.TriggerRobotDialogue10();
                            firstPolicy = false;
                        }

                        if (firstCallEnacted)
                        {
                            robotDialogueTrigger.TriggerRobotDialogue12();
                            statsScript.phone1Accept = true;
                            firstCallEnacted = false;
                        }

                        if (uses == 2)
                        {
                            phoneIntractable = true;
                            phoneActive = true;
                            phoneScript.firstCall = false;
                            uses = 0;
                        }

                        if (phoneScript.calls == 2)
                        {
                            robotDialogueTrigger.TriggerRobotDialogue13();
                            statsScript.phone2Accept = true;
                            conferenceCallAudio.clip = conferenceCallFX;
                            conferenceCallAudio.Play();
                            phoneScript.calls = 0;
                            phoneScript.dayOne = false;
                            doorLight1.color = green;
                            doorLight2.color = green;
                        }
                    }
                }


            }
            else if (hit.collider.gameObject.tag == "Bin" && holding)
            {
                //If the distance to the bin is less than 1
                if (dist <= 2.5f)
                {
                    info.text = "Press 'E' to scrap";
                    info.gameObject.SetActive(true);

                    //If the player hits E then Destroy the Policy, descrease the time, 
                    //set holding to false AND set answered to false so the
                    //phone can ring again
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(prefab);
                        holding = !holding;
                        bin.Play("Bin");

                        if (holdingPhone)
                        {
                            statsScript.phonecallDecline.Add(phoneScript.phonecall);

                            statsScript.actionsText = statsScript.actionsText + "\n" + "Phone call from " + phoneScript.phonecall + " declined";

                            holdingPhone = false;

                            if (firstCallEnacted)
                            {
                                robotDialogueTrigger.TriggerRobotDialogue12();
                                statsScript.phone1Accept = false;
                                firstCallEnacted = false;
                            }
                        }

                        policyIntractable = true;
                        statsScript.TimeForward();

                        trashAudio.clip = trashFX;
                        trashAudio.PlayOneShot(trashFX);

                        if (answered)
                        {
                            for (int i = 0; i < policyScript.scrap.Length; i++)
                            {
                                statsScript.stats[i] += policyScript.scrap[i];
                            }

                            answered = false;
                        }

                        if (policy)
                        {
                            if (uses == 1)
                            {
                                uses++;
                            }

                            policy = false;
                        }



                        if (uses == 2)
                        {
                            phoneIntractable = true;
                            phoneActive = true;
                            phoneScript.firstCall = false;
                            uses = 0;
                        }

                        if (phoneScript.calls == 2)
                        {
                            robotDialogueTrigger.TriggerRobotDialogue13();
                            statsScript.phone2Accept = false;
                            conferenceCallAudio.clip = conferenceCallFX;
                            conferenceCallAudio.Play();
                            phoneScript.calls = 0;
                            phoneScript.dayOne = false;
                            doorLight1.color = green;
                            doorLight2.color = green;
                        }
                    }
                }
            }
            //If the phone is ringing and If the object hit is the phone and the distance to it is less than 2.5 then 
            //show the player a message to allow them to answer the phone
            else if (phoneScript.isRinging == true && hit.collider.gameObject.tag == "Phone" && dist <= 2.5f && phoneIntractable == true)
            {
                info.text = "Press 'E' to answer";
                info.gameObject.SetActive(true);

                //If the phone is ringing
                if (Input.GetKeyDown(KeyCode.E))
                {
                    info.gameObject.SetActive(false);
                    answered = true;
                    phoneScript.newAudio = true;
                    phoneScript.callMissed = false;
                    phoneScript.ringTimerActive = false;
                    phoneScript.isRinging = false;
                    phonePanel.SetActive(true);
                    phoneCanvasOn = true;
                    statsScript.TimeForward();
                    phone.material.SetFloat("Vector1_B78C4234", 100f);
                    phoneIntractable = false;
                }
            }
            //If the conference call is hit, it is interactable and the distance is less than 2.5, then display info text
            else if (hit.collider.gameObject.tag == "ConferenceCall" && conferenceCallInteractable == true && dist <= 2.5f)
            {
                info.text = "Press 'E' to start call";
                info.gameObject.SetActive(true);

                //If the player presses E, start conference call
                if (Input.GetKeyDown(KeyCode.E))
                {
                    earthCanvas.SetActive(false);
                    marsCanvas.SetActive(false);
                    venusCanvas.SetActive(false);
                    moonCanvas.SetActive(false);

                    conferenceCallAudio.Stop();
                    conferenceCamera.SetActive(true);
                    dialogueManager.speakerPanel.SetActive(true);
                    info.gameObject.SetActive(false);
                    earthCharacter.SetActive(true);
                    robotDialogueManager.conferencePhoneRing = false;
                    dialogueTrigger.TriggerDialogue();
                    folder = true;
                    statsScript.TimeForward();
                    gameObject.SetActive(false);
                    conf.material.SetFloat("Vector1_B78C4234", 100f);
                }
            }
            //Any other object remove the info
            else
            {
                info.gameObject.SetActive(false);
            }
        }
        //Any other object remove the info
        else
        {
            info.gameObject.SetActive(false);
        }

        //If the phone canvas is active i.e. the user has picked up the phone
        if (phoneCanvasOn)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                answeredPhone = true;
            }

            if ((Input.GetMouseButtonDown(0)) && answeredPhone)
            {
                phonePanel.SetActive(false);

                phoneScript.stopAudio = true;

                prefab = Instantiate(paper, spawnPos.position, GameObject.Find("MainCamera").transform.rotation);
                prefab.transform.parent = GameObject.Find("SpawnPos").transform;
                holding = true;
                holdingPhone = true;

                PolicyScript();

                policyScript.UpdatePolicy(phoneScript.faxChanges, phoneScript.faxChangedNames);
                policyScript.UpdateBin(phoneScript.binChanges, phoneScript.binChangedNames);

                phoneCanvasOn = false;
                answeredPhone = false;

                if (phoneScript.firstCall)
                {
                    robotDialogueTrigger.TriggerRobotDialogue11();
                    firstCallEnacted = true;
                    statsScript.phone1Answered = true;
                }
                else
                {
                    statsScript.phone2Answered = true;
                }
            }
        }

        if(GameObject.Find("SpeakerPanel") == null && GameObject.Find("AnswerPanel") == null && !earthCanvas.activeInHierarchy && !folder)
        {
            earthCanvas.SetActive(true);
            marsCanvas.SetActive(true);
            venusCanvas.SetActive(true);
            moonCanvas.SetActive(true);
        }
    }

    IEnumerator FolderOpen(RotationScript rot)
    {
        policyIntractable = false;

        folderScript = folderCamera.GetComponent<FolderScript>();
        rot.enabled = true;     

        yield return new WaitForSeconds(1.25f);

        rot.enabled = false;
        folderScript.enabled = true;
        folder = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        folderScript.anim.Play("Open");

        this.transform.position = folderScript.playerSpawn.transform.position;

        folderCamera.SetActive(true);
        gameObject.SetActive(false);

        if (firstPolicy)
        {
            robotDialogueTrigger.TriggerRobotDialogue8();
        }
    }

    //Used to setup the policy script when the object is created
    public void PolicyScript()
    {
        policyScript = prefab.GetComponent<PolicyScript>();

        earthCanvas.SetActive(true);
        marsCanvas.SetActive(true);
        venusCanvas.SetActive(true);
        moonCanvas.SetActive(true);
    }

    public void Load()
    {
        interactionScript.enabled = true;

        if (GameObject.Find("GameInfoObject DDL"))
        {
            GameObject.Destroy(GameObject.Find("EarthFolder"));
            GameObject.Destroy(GameObject.Find("MarsFolder"));
            GameObject.Destroy(GameObject.Find("VenusFolder"));
            GameObject.Destroy(GameObject.Find("GameInfoObject"));

            policyChoices.UpdatePolicies();
        }

        if(statsScript.day == 2)
        {
            robotDialogueTrigger.TriggerRobotDialogue2_1();
        }
        else if(statsScript.day == 3)
        {
            robotDialogueTrigger.TriggerRobotDialogue3_1();
        }
        else if (statsScript.day == 4)
        {
            robotDialogueTrigger.TriggerRobotDialogue4_1();
        }
        else if (statsScript.day == 5)
        {
            robotDialogueTrigger.TriggerRobotDialogue5_1();
        }

        this.enabled = false;
    }
}

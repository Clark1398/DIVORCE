﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(Phone))]

public class InteractionScript : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject prefab;
    public Transform spawnPos;
    public GameObject phonePanel;
    public Text info;
    GameObject paper;

    [Header("Cameras")]
    public GameObject pcCamera, chairCamera;
    public GameObject conferenceCamera;

    [Header("Canvas")]
    public GameObject conferenceCanvas;

    Phone phoneScript;
    public Stats statsScript;
    PolicyScript policyScript;
    public FolderScript folderScript;
    DialogueTrigger dialogueTrigger;
    RobotDialogueTrigger robotDialogueTrigger;
    RobotDialogueManager robotDialogueManager;
    DialogueManager dialogueManager;
    public ContactScript contactScript;
    public MoonFolderScript moonFolderScript;

    [Header("Booleans")]
    public bool holding;
    bool holdingPaper;
    public bool holdingPolicy, holdingContact, holdingPhone, answeredPhone;
    public bool withinAnswerDistance;
    public bool answered;
    bool phoneCanvasOn;
    public bool folder;
    public bool pcActive;
    public bool contact;
    public bool door;
    public bool dayFivePrefab;
    bool dayFive;
    bool countdown;

    bool triggerOnce;
    bool triggerOnce2;
    bool triggerOnce3;
    bool triggerOnce4;

    float dist;
    public int uses;
    public int contactUses;
    float timer = 2f;

    string item;

    public bool conferenceCallInteractable = false;
    public bool phoneInteractable = false;
    public bool folderInteractable;
    public bool chairInteractable;

    public bool policy = false;

    public GameObject earthCanvas, marsCanvas, venusCanvas, moonCanvas;
    public GameObject earthCamera, marsCamera, venusCamera, folderCamera;
    public GameObject robotPanel;
    public GameObject marsCharacter;
    public GameObject earthCharacter;
    public GameObject venusCharacter;

    PolicyChoices policyChoices;

    AudioSource trashAudio, faxAudio;

    public AudioSource conferenceCallAudio, pcAudio;

    public AudioClip trashFX, faxFX, typingFX, conferenceCallFX;

    Color red = Color.red;
    Color green = Color.green;

    public Light doorLight1;
    public Light doorLight2;

    public Animator bin;

    public Renderer phone, confCall, chair;

    //Used to setup the objects
    void Start()
    {
        if (GameObject.Find("GameInfoObject DDL") != null)
        {
            statsScript = GameObject.Find("GameInfoObject DDL").GetComponent<Stats>();
            pcCamera.GetComponent<CameraScript>().statsScript = GameObject.Find("GameInfoObject DDL").GetComponent<Stats>();
        }
        else
        {
            statsScript = FindObjectOfType<Stats>();
        }

        info.gameObject.SetActive(false);
        
        policyChoices = FindObjectOfType<PolicyChoices>();
        robotDialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();
        phoneScript = FindObjectOfType<Phone>();
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        folderScript = FindObjectOfType<FolderScript>();
        robotDialogueManager = FindObjectOfType<RobotDialogueManager>();

        trashAudio = GameObject.FindGameObjectWithTag("Bin").GetComponent<AudioSource>();
        faxAudio = GameObject.FindGameObjectWithTag("Fax").GetComponent<AudioSource>();
        pcAudio = GameObject.FindGameObjectWithTag("Fax").GetComponent<AudioSource>();
        conferenceCallAudio = GameObject.FindGameObjectWithTag("ConferenceCall").GetComponent<AudioSource>();

        marsCharacter.SetActive(false);
        earthCharacter.SetActive(false);
        venusCharacter.SetActive(false);

        paper = (GameObject)Resources.Load("Policy", typeof(GameObject));

        doorLight1.color = red;
        doorLight2.color = red;

        if (statsScript.day > 1)
        {
            folderInteractable = false;
            chairInteractable = false;
        }

        uses = 0;
        contactUses = 0;

        triggerOnce = true;
        triggerOnce2 = true;
        triggerOnce3 = true;
        triggerOnce4 = true;
    }

    void Update()
    {
        if (earthCamera == null)
        {
            earthCamera = statsScript.earthCam;
            marsCamera = statsScript.marsCam;
            venusCamera = statsScript.venusCam;
        }

        if (earthCanvas == null)
        {
            if (GameObject.Find("Earth Folder Canvas DDL") == null)
            {
                earthCanvas = GameObject.Find("Earth Folder Canvas");
                marsCanvas = GameObject.Find("Mars Folder Canvas");
                venusCanvas = GameObject.Find("Venus Folder Canvas");    
            }
            else
            {
                earthCanvas = GameObject.Find("Earth Folder Canvas DDL");
                marsCanvas = GameObject.Find("Mars Folder Canvas DDL");
                venusCanvas = GameObject.Find("Venus Folder Canvas DDL");
            }

            moonCanvas = GameObject.Find("Moon Folder Canvas");
        }

        if (statsScript.newDay)
        {
            statsScript.NewDay();
            statsScript.newDay = false;
        }

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

            if (hit.collider.gameObject.tag == "Chair" && !holding && chairInteractable)
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

                        if(chairCamera.GetComponent<ChairCameraScript>().moonFolderFirst == true)
                        {
                            chair.material.SetFloat("Vector1_B78C4234", 100f);
                        }
                    }
                }
            }
            else if (hit.collider.gameObject.tag == "Folder" && !holding && folderInteractable)
            {
                //If the distance to the object is less than 2.5
                if (dist <= 2.5f)
                {
                    info.text = "Press 'E' to open";
                    info.gameObject.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        RotationScript rot = hit.collider.transform.parent.gameObject.GetComponent<RotationScript>();

                        rot.endPos = GameObject.Find("EndPos").transform;

                        info.gameObject.SetActive(false);

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

                        folder = true;
                        rot.startTime = Time.time;
                        rot.journeyLength = Vector3.Distance(rot.startPos.position, rot.endPos.position);
                        folderCamera.GetComponent<FolderScript>().playerSpawn = GameObject.Find("PlayerPoint");
                        StartCoroutine(FolderOut(rot));
                        folderCamera.GetComponent<FolderScript>().enabled = true;
                    }
                }
            }
            else if (hit.collider.gameObject.tag == "Fax" && holding)
            {
                if (dist <= 2.5f)
                {
                    info.text = "Press 'E' to fax";
                    info.gameObject.SetActive(true);

                    //If the player hits E then Destroy the Policy, descrease the time and the stats, 
                    //Update the PC screen and set holding to false AND set answered to false so the
                    //phone can ring again
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(prefab);
                        holding = !holding;

                        if (holdingPolicy)
                        {
                            for (int i = 0; i < policyScript.decreases.Length; i++)
                            {
                                statsScript.stats[i] += policyScript.decreases[i];
                            }

                            if (policyScript.planet != "Moon")
                            {
                                folderScript.buttons = policyScript.buttonAmount;
                                folderScript.type = policyScript.type;
                                folderScript.DisableButton();
                                folderScript = null;
                            }
                            else
                            {
                                moonFolderScript.buttons = policyScript.buttonAmount;
                                moonFolderScript.type = policyScript.type;
                                moonFolderScript.DisableButton();
                                moonFolderScript = null;
                            }

                            if (policyChoices.movementChoice != "")
                            {
                                policyChoices.movementChoice = policyScript.movement;
                                policyChoices.planetType = policyScript.pfm;
                            }

                            if (policy)
                            {
                                uses++;
                                statsScript.chosenPolicies.Add(policyScript.chosenPolicy);
                                statsScript.chosenPlanets.Add(policyScript.planet);

                                statsScript.actionsText = statsScript.actionsText + "\n" + policyScript.chosenPolicy + " for " + policyScript.planet;

                                if (statsScript.day == 2)
                                {
                                    if (uses == 1)
                                    {
                                        robotDialogueTrigger.TriggerRobotDialogue2_7();
                                    }
                                }

                                policy = false;
                            }

                            holdingPolicy = false;
                        }
                        else if (holdingContact)
                        {
                            prefab.GetComponent<ContactScript>().Enact();

                            contactUses++;

                            if (statsScript.day == 2)
                            {
                                if (contactUses == 1)
                                {
                                    robotDialogueTrigger.TriggerRobotDialogue2_10();
                                }
                            }

                            holdingContact = false;
                        }
                        else if (holdingPhone)
                        {
                            for (int i = 0; i < policyScript.decreases.Length; i++)
                            {
                                statsScript.stats[i] += policyScript.decreases[i];
                            }

                            statsScript.phonecallAccept.Add(phoneScript.phonecall);

                            statsScript.actionsText = statsScript.actionsText + "\n" + "Phone call from " + phoneScript.phonecall + " accepted";

                            if (statsScript.day == 2)
                            {
                                if (phoneScript.calls == 2)
                                {
                                    phoneScript.calls = 0;
                                }
                            }

                            holdingPhone = false;
                        }

                        if (statsScript.day == 5)
                        {
                            if (dayFive)
                            {
                                countdown = true;
                                statsScript.dayFiveFax = true;
                                dayFive = false;
                            }
                        }

                        statsScript.UpdateScreen();
                        statsScript.TimeForward();

                        faxAudio.clip = faxFX;
                        faxAudio.PlayOneShot(faxFX);
                    }
                }


            }
            else if (hit.collider.gameObject.tag == "Bin" && holding)
            {
                //If the distance to the bin is less than 1
                if (dist <= 2.5f)
                {
                    info.text = "Press 'E' to bin";
                    info.gameObject.SetActive(true);

                    //If the player hits F then Destroy the Policy, descrease the time, 
                    //set holding to false AND set answered to false so the
                    //phone can ring again
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(prefab);
                        holding = !holding;
                        bin.Play("Bin");

                        statsScript.TimeForward();

                        trashAudio.clip = trashFX;
                        trashAudio.PlayOneShot(trashFX);

                        if (holdingPhone)
                        {
                            for (int i = 0; i < policyScript.scrap.Length; i++)
                            {
                                statsScript.stats[i] += policyScript.scrap[i];
                            }

                            statsScript.phonecallDecline.Add(phoneScript.phonecall);

                            statsScript.actionsText = statsScript.actionsText + "\n" + "Phone call from " + phoneScript.phonecall + " declined";

                            if (statsScript.day == 2)
                            {
                                if (phoneScript.calls == 2)
                                {
                                    statsScript.wifeCounter++;
                                    phoneScript.calls = 0;
                                }
                            }

                            holdingPhone = false;
                        }

                        if (policy)
                        {
                            uses++;

                            if (statsScript.day == 2)
                            {
                                if (uses == 1)
                                {
                                    robotDialogueTrigger.TriggerRobotDialogue2_7();
                                }
                            }

                            policy = false;
                        }

                        if (holdingContact)
                        {
                            contactUses++;

                            if (statsScript.day == 2)
                            {
                                if (contactUses == 1)
                                {
                                    robotDialogueTrigger.TriggerRobotDialogue2_10();
                                }
                            }
                            holdingContact = false;
                        }

                        if (statsScript.day == 5)
                        {
                            if (dayFive)
                            {
                                countdown = true;
                                statsScript.dayFiveBin = true;
                                dayFive = false;
                            }
                        }
                    }
                }
            }
            //If the phone is ringing and If the object hit is the phone and the distance to it is less than 2.5 then 
            //show the player a message to allow them to answer the phone
            else if (phoneScript.isRinging == true && hit.collider.gameObject.tag == "Phone" && dist <= 2.5f && phoneInteractable == true && !holding)
            {
                info.text = "Press 'E' to answer";
                info.gameObject.SetActive(true);

                //If the phone is ringing
                if (Input.GetKeyDown(KeyCode.E))
                {

                    phone.material.SetFloat("Vector1_B78C4234", 100f);

                    if (phoneScript.calls == 1)
                    {
                        info.gameObject.SetActive(false);
                        answered = true;
                        phoneScript.newAudio = true;
                        phoneScript.callMissed = false;
                        phoneScript.ringTimerActive = false;
                        phoneScript.isRinging = false;
                        phonePanel.SetActive(true);
                        phoneCanvasOn = true;
                        phoneInteractable = false;
                    }
                    else
                    {
                        info.gameObject.SetActive(false);
                        answered = true;
                        phoneScript.newAudio = true;
                        phoneScript.callMissed = false;
                        phoneScript.ringTimerActive = false;
                        phoneScript.isRinging = false;
                        phonePanel.SetActive(true);
                        phoneCanvasOn = true;
                        phoneInteractable = false;
                        statsScript.TimeForward();
                    }
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
                    confCall.material.SetFloat("Vector1_B78C4234", 100f);

                    earthCanvas.SetActive(false);
                    marsCanvas.SetActive(false);
                    venusCanvas.SetActive(false);
                    moonCanvas.SetActive(false);

                    conferenceCallAudio.Stop();
                    conferenceCamera.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    info.gameObject.SetActive(false);
                    dialogueManager.speakerPanel.SetActive(true);
                    robotDialogueManager.conferencePhoneRing = false;
                    statsScript.TimeForward();
                    gameObject.SetActive(false);
                    dialogueTrigger.TriggerDialogue();

                    if (statsScript.day == 2)
                    {
                        marsCharacter.SetActive(true);
                    }
                    else if (statsScript.day == 3)
                    {
                        venusCharacter.SetActive(true);
                    }
                    else if (statsScript.day == 4)
                    {
                        earthCharacter.SetActive(true);
                    }
                }
            }
            else if (hit.collider.gameObject.tag == "Door" && door)
            {
                //If the distance to the object is less than 2.5
                if (dist <= 2.5f)
                {
                    info.text = "Press 'E' to leave office";
                    info.gameObject.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    statsScript.conferenceIgnore = true;
                    statsScript.wifeCounter2++;
                    statsScript.time -= 2;
                    door = false;
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

        if (GameObject.Find("SpeakerPanel") == null && GameObject.Find("AnswerPanel") == null && !earthCanvas.activeInHierarchy && !folder)
        {
            earthCanvas.SetActive(true);
            marsCanvas.SetActive(true);
            venusCanvas.SetActive(true);
            moonCanvas.SetActive(true);
        }

        //If the phone canvas is active i.e. the user has picked up the phone
        if (phoneCanvasOn)
        {
            if(Input.GetKeyUp(KeyCode.E))
            {
                answeredPhone = true;
            }

            if ((Input.GetMouseButtonDown(0)) && answeredPhone)
            {
                answeredPhone = false;

                if (statsScript.day == 2)
                {
                    if (phoneScript.calls == 1)
                    {
                        phonePanel.SetActive(false);
                        phoneScript.stopAudio = true;
                        robotDialogueTrigger.TriggerRobotDialogue2_3();
                        phoneCanvasOn = false;
                    }
                    else if (phoneScript.calls == 2)
                    {
                        robotDialogueTrigger.TriggerRobotDialogue2_13();
                        holding = true;
                        holdingPhone = true;
                        phonePanel.SetActive(false);
                        phoneScript.stopAudio = true;

                        prefab = Instantiate(paper, spawnPos.position, GameObject.Find("MainCamera").transform.rotation);
                        prefab.transform.parent = GameObject.Find("SpawnPos").transform;

                        PolicyScript();

                        policyScript.UpdatePolicy(phoneScript.faxChanges, phoneScript.faxChangedNames);
                        policyScript.UpdateBin(phoneScript.binChanges, phoneScript.binChangedNames);

                        phoneCanvasOn = false;
                    }
                }

                else if (statsScript.day == 3)
                {
                    if (phoneScript.calls == 1)
                    {
                        phonePanel.SetActive(false);
                        phoneScript.stopAudio = true;
                        robotDialogueTrigger.TriggerRobotDialogue3_3();
                        phoneCanvasOn = false;

                        chairInteractable = true;
                        folderInteractable = true;
                    }
                    else if (phoneScript.calls == 2 || phoneScript.calls == 3)
                    {
                        holding = true;
                        holdingPhone = true;
                        phonePanel.SetActive(false);
                        phoneScript.stopAudio = true;

                        prefab = Instantiate(paper, spawnPos.position, GameObject.Find("MainCamera").transform.rotation);
                        prefab.transform.parent = GameObject.Find("SpawnPos").transform;

                        PolicyScript();

                        policyScript.UpdatePolicy(phoneScript.faxChanges, phoneScript.faxChangedNames);
                        policyScript.UpdateBin(phoneScript.binChanges, phoneScript.binChangedNames);

                        phoneCanvasOn = false;
                    }
                }

                else if (statsScript.day == 4)
                {
                    if (phoneScript.calls == 1)
                    {
                        phonePanel.SetActive(false);
                        phoneScript.stopAudio = true;
                        robotDialogueTrigger.TriggerRobotDialogue4_5();
                        phoneCanvasOn = false;

                        chairInteractable = true;
                        folderInteractable = true;
                    }
                    else if (phoneScript.calls > 1)
                    {
                        holding = true;
                        holdingPhone = true;
                        phonePanel.SetActive(false);
                        phoneScript.stopAudio = true;

                        prefab = Instantiate(paper, spawnPos.position, GameObject.Find("MainCamera").transform.rotation);
                        prefab.transform.parent = GameObject.Find("SpawnPos").transform;

                        PolicyScript();

                        policyScript.UpdatePolicy(phoneScript.faxChanges, phoneScript.faxChangedNames);
                        policyScript.UpdateBin(phoneScript.binChanges, phoneScript.binChangedNames);

                        phoneCanvasOn = false;
                    }
                }
            }
        }

        if (statsScript.day == 2)
        {
            if (statsScript.time == 5)
            {
                if (triggerOnce)
                {
                    robotDialogueTrigger.TriggerRobotDialogue2_11();
                    triggerOnce = false;
                }
            }
            if (statsScript.time == 4)
            {
                if (triggerOnce2)
                {
                    robotDialogueTrigger.TriggerRobotDialogue2_12();
                    phoneScript.phoneIsActive = true;
                    triggerOnce2 = false;
                }
            }
            if (statsScript.time == 2)
            {
                if (triggerOnce3)
                {
                    robotDialogueTrigger.TriggerRobotDialogue2_14();
                    conferenceCallInteractable = true;
                    conferenceCallAudio.clip = conferenceCallFX;
                    conferenceCallAudio.Play();
                    doorLight1.color = green;
                    doorLight2.color = green;
                    chairInteractable = false;
                    folderInteractable = false;
                    triggerOnce3 = false;
                }
            }
        }

        if (statsScript.day == 3)
        {
            if (statsScript.time == 9)
            {
                if (triggerOnce)
                {
                    robotDialogueTrigger.TriggerRobotDialogue3_5();
                    triggerOnce = false;
                }
            }
            if (statsScript.time == 8)
            {
                if (triggerOnce2)
                {
                    phoneScript.phoneIsActive = true;
                    phoneInteractable = true;
                    triggerOnce2 = false;
                }
            }
            if (statsScript.time == 4)
            {
                if (triggerOnce3)
                {
                    phoneScript.phoneIsActive = true;
                    phoneInteractable = true;
                    triggerOnce3 = false;
                }
            }
            if (statsScript.time == 2)
            {
                if (triggerOnce4)
                {
                    conferenceCallInteractable = true;
                    conferenceCallAudio.clip = conferenceCallFX;
                    folderInteractable = false;
                    chairInteractable = false;
                    conferenceCallAudio.Play();
                    doorLight1.color = green;
                    doorLight2.color = green;
                    robotDialogueTrigger.TriggerRobotDialogue3_6();
                    triggerOnce4 = false;
                }
            }
        }

        if (statsScript.day == 4)
        {
            if (statsScript.time == 8)
            {
                if (triggerOnce)
                {
                    robotDialogueTrigger.TriggerRobotDialogue4_3();
                    triggerOnce = false;
                }
            }
            if (statsScript.time == 4)
            {
                if (triggerOnce2)
                {
                    phoneScript.phoneIsActive = true;
                    phoneInteractable = true;
                    triggerOnce2 = false;
                }
            }
            if (statsScript.time == 2)
            {
                if (triggerOnce3)
                {
                    conferenceCallInteractable = true;
                    conferenceCallAudio.clip = conferenceCallFX;
                    conferenceCallAudio.Play();
                    doorLight1.color = green;
                    doorLight2.color = green;
                    chairInteractable = false;
                    folderInteractable = false;
                    triggerOnce3 = false;
                }
            }
        }

        if (dayFivePrefab)
        {
            holding = true;

            prefab = Instantiate(paper, spawnPos.position, GameObject.Find("MainCamera").transform.rotation);
            prefab.transform.parent = GameObject.Find("SpawnPos").transform;

            //PolicyScript();
            robotDialogueTrigger.TriggerRobotDialogue5_2();

            dayFive = true;
            dayFivePrefab = false;
        }

        if (countdown)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                statsScript.time = 0;
            }
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

    IEnumerator FolderOut(RotationScript rot)
    {
        rot.enabled = true;
        folderInteractable = false;

        yield return new WaitForSeconds(1.25f);

        folderScript = folderCamera.GetComponent<FolderScript>();

        rot.enabled = false;
        folder = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        folderScript.anim.Play("Open");

        this.transform.position = folderScript.playerSpawn.transform.position;

        folderCamera.SetActive(true);
        folderScript.enabled = true;
        gameObject.SetActive(false);
        folderInteractable = true;
    }

}

                //GameObject folderCamera = earthFolderCamera;

                //switch (hit.collider.transform.parent.transform.parent.gameObject.name)
                //{
                //    case "Earth Folder":
                //        folderCamera = earthFolderCamera;
                //        folderScript = earthFolderCamera.GetComponent<FolderScript>();

                //        GameObject.Find("Mars Folder Canvas").SetActive(false);
                //        GameObject.Find("Venus Folder Canvas").SetActive(false);
                //        GameObject.Find("Moon Folder Canvas").SetActive(false);
                //        break;

                //    case "Mars Folder":
                //        folderCamera = marsFolderCamera;
                //        folderScript = marsFolderCamera.GetComponent<FolderScript>();

                //        GameObject.Find("Earth Folder Canvas").SetActive(false);
                //        GameObject.Find("Venus Folder Canvas").SetActive(false);
                //        GameObject.Find("Moon Folder Canvas").SetActive(false);
                //        break;

                //    case "Venus Folder":
                //        folderCamera = venusFolderCamera;
                //        folderScript = venusFolderCamera.GetComponent<FolderScript>();

                //        GameObject.Find("Mars Folder Canvas").SetActive(false);
                //        GameObject.Find("Earth Folder Canvas").SetActive(false);
                //        GameObject.Find("Moon Folder Canvas").SetActive(false);
                //        break;
                //}

                //RotationScript rot = hit.collider.transform.parent.transform.parent.gameObject.GetComponent<RotationScript>();

                //rot.endPos = GameObject.Find("FolderEndPos").transform;
                //rot.startTime = Time.time;
                //rot.journeyLength = Vector3.Distance(rot.startPos.position, rot.endPos.position);

                //StartCoroutine(FolderOut(rot));

                //folderCamera.SetActive(true);

                //GameObject.Find("MainCamera").transform.LookAt(hit.collider.gameObject.transform);
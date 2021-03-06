﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour {

    [Header("Statistics")]
    public float[] stats = new float[8];
    public string[] statNames = new string[8];
    public string[] statDisplay = new string[8];

    [Header("Text")]
    public Text names, nums;
    public Text PCnames, PCnums;
    public Text whiteboardText, familyText;

    [Header("Sliders")]
    public Slider auto, rev, pubs, cabs, syst, earth, venus, mars;

    [Header("Lists")]
    string[] tasks = new string[4];

    public List<string> chosenPlanets = new List<string>();
    public List<string> chosenPolicies = new List<string>();

    public List<string> contactNames = new List<string>();
    public List<string> contactPlanets = new List<string>();

    public List<string> phonecallAccept = new List<string>();
    public List<string> phonecallDecline = new List<string>();

    public List<string> connferenceCallAccept = new List<string>();
    public List<string> connferenceCallDecline = new List<string>();

    [Header("Outbound Contacts")]
    public string conPlanet, con;
    public float[] contactApprove = new float[8];
    public float[] contactDecline = new float[8];
    int conNum = 0;
    public Text healthEarth, travelEarth, workEarth, healthMars, travelMars, workMars, healthVenus, travelVenus, workVenus;
    public string hEText, tEText, wEText, hMText, tMText, wMText, hVText, tVText, wVText, actionsText;

    public bool conferenceAccept = false;
    public bool conferenceIgnore = false; 
    public bool conferenceAcceptWithHaggle = false;

    public bool phone1Answered = false;
    public bool phone2Answered = false;

    public bool phone1Accept;
    public bool phone2Accept;

    public bool dayFiveBin;
    public bool dayFiveFax;

    public bool newDay;

    GameObject bigHand;
    public GameObject pcCamera, earthCam, marsCam, venusCam, moonCam, player, moonCanvas, pause;

    public int time;
    public int day;

    public int wifeCounter;
    public int wifeCounter2;

    public int policyCounter;

    public string[] gameOverText = new string[8];
    public string gameOver;

    PauseScript pauseScript;

    void Awake()
    {
        names = GameObject.Find("Text_Name").GetComponent<Text>();
        nums = GameObject.Find("Text_Numbers").GetComponent<Text>();

        whiteboardText = GameObject.Find("WhiteboardText").GetComponent<Text>();
        familyText = GameObject.Find("FamilyText").GetComponent<Text>();

        pcCamera = GameObject.Find("PC Camera");

        bigHand = GameObject.Find("Small Hand");

        auto = GameObject.Find("AutonomySlider").GetComponent<Slider>();
        rev = GameObject.Find("RevenueSlider").GetComponent<Slider>();
        pubs = GameObject.Find("PublicSupportSlider").GetComponent<Slider>();
        cabs = GameObject.Find("CabinetSupportSlider").GetComponent<Slider>();
        syst = GameObject.Find("SystemTensionSlider").GetComponent<Slider>();
        earth = GameObject.Find("EarthRelationshipSlider").GetComponent<Slider>();
        mars = GameObject.Find("MarsRelationshipSlider").GetComponent<Slider>();
        venus = GameObject.Find("VenusRelationshipSlider").GetComponent<Slider>();

        pause = GameObject.Find("Pause");
        pause.SetActive(false);
        pauseScript = pause.GetComponent<PauseScript>();
        pauseScript.isPaused = false;

        if (GameObject.Find("LoadObject") != null)
        {
            LoadGame loadScript = GameObject.Find("LoadObject").GetComponent<LoadGame>();

            day = loadScript.day;
            time = loadScript.time;

            stats[0] = loadScript.statistics[0];
            stats[1] = loadScript.statistics[1];
            stats[2] = loadScript.statistics[2];
            stats[3] = loadScript.statistics[3];
            stats[4] = loadScript.statistics[4];
            stats[5] = loadScript.statistics[5];
            stats[6] = loadScript.statistics[6];
            stats[7] = loadScript.statistics[7];

            hEText = loadScript.text[0];
            tEText = loadScript.text[1];
            wEText = loadScript.text[2];
            hMText = loadScript.text[3];
            tMText = loadScript.text[4];
            wMText = loadScript.text[5];
            hVText = loadScript.text[6];
            tVText = loadScript.text[7];
            wVText = loadScript.text[8];

            foreach (string m in loadScript.policies)
            {
                chosenPolicies.Add(m);
            }

            foreach (string m in loadScript.policyPlanet)
            {
                chosenPlanets.Add(m);
            }

            foreach (string m in loadScript.contact)
            {
                contactNames.Add(m);
            }

            foreach (string m in loadScript.contactPlanet)
            {
                contactPlanets.Add(m);
            }

            foreach (string m in loadScript.phoneCallAccept)
            {
                phonecallAccept.Add(m);
            }

            foreach (string m in loadScript.phoneCallDecline)
            {
                phonecallDecline.Add(m);
            }

            foreach (string m in loadScript.conferenceCallAccept)
            {
                connferenceCallAccept.Add(m);
            }

            foreach (string m in loadScript.conferenceCallDecline)
            {
                connferenceCallDecline.Add(m);
            }

            loadScript.UpdateObjects(moonCam.GetComponent<MoonFolderScript>(), pcCamera.GetComponent<CameraScript>(), earthCam.GetComponent<FolderScript>(), marsCam.GetComponent<FolderScript>(), venusCam.GetComponent<FolderScript>());
        }
    }

    //Sets up the PC Screen initally to display the stats on screen
    void Start()
    {
        for (int i = 0; i < statDisplay.Length; i++)
        {
            statDisplay[i] = statNames[i] + " (%)";
        }

        statDisplay[1] = statNames[1] + " (Billion)";

        hEText = "Open";
        tEText = "Open";
        wEText = "Open";

        hMText = "Open";
        tMText = "Open";
        wMText = "Open";

        hVText = "Open";
        tVText = "Open";
        wVText = "Open";

        gameOverText[0] = "Your decisions and actions have torn the people apart. Constant disagreements result in a civil war erupting that overtakes the entirety of the Moon. It is just a matter of time before this conflict destroys the civilization that has been built over the past few decades";
        gameOverText[1] = "Your actions have drained the Moon’s resources dry. The constant spending resulted in a short period of prosperity, but what followed was horror. Poverty rose to an all time high… emergency services shut down soon after and it all ended with starvation, which lead to violence and crime roaming the streets.";
        gameOverText[2] = "Although your intentions were good, the result of your actions wasn’t. The people did not appreciate the way you ran things, yet you did not change your approach. Soon the riots began, people raging in the streets requesting your resignation. What followed was a bit more civilized than expected as a petition to remove you from office was put together, which eventually ended your political career.";
        gameOverText[3] = "You did your best, but unfortunately the cabinet decided they had made the wrong choice with you. A few days after you came into office you were forcefully brought out of it. Such an event can cause even the best of political careers to end…";
        gameOverText[4] = "Your unwillingness to compromise and co-operate with the other planets within the Solar System caused too much tension. This tension only grew as time progressed and eventually exploded into a galactic war that made the entire system unsafe. Your actions were the cause of countless unneeded deaths… if only you had considered what their consequences might be…";
        gameOverText[5] = "It appears the independence vote was not a good idea after all. Not only did it anger Earth initially, but your actions pushed them over the ledge, resulting in them declaring war on the Moon. As a newly established planetary body, you have no hope of winning, which would result in a forceful colonization or domination.";
        gameOverText[6] = "Not relying on others is one thing, but completely disregarding them is another. Your actions have caused Mars, a planet with an established aggressive demeanor and violent history, to declare war on the Moon. That’s when hope was lost… a newly established planetary body stood no chance against the firepower of a planet that has been pouring resources in its military for centuries.";
        gameOverText[7] = "You made history! Never before had Venus declared war on anyone, but you got them to finally do it! And although that is not something they specialize in, you still had no chance against an established planet of that size… The independent Moon was short lived due to your poor decision making.";

        NewDay();
    }

    public void NewDay()
    {
        if(day == 1)
        {
            tasks[0] = "Increase Earth's Opinion to atleast 50%";
            tasks[1] = "Increase Mars' Opinion to atleast 60%  ";
            tasks[2] = "Increase Autonomy to atleast 30%    ";
            tasks[3] = "Increase Public Support to atleast 60% ";
        }
        else if (day == 2)
        {
            tasks[0] = "Increase Revenue to 2..5 mil moon bucks";
            tasks[1] = "Decrease System Tension to atleast 20%";
            tasks[2] = "Increase Venus' Opinion to atleast 55% ";
            tasks[3] = "Organise Healthcare for citizens abroad";
        }
        else if (day == 3)
        {
            tasks[0] = "Increase Mars' Opinion to atleast 65%  ";
            tasks[1] = "Increase Venus' Opinion to atleast 65% ";
            tasks[2] = "Increase Public Support to atleast 65% ";
            tasks[3] = "Decrease System Tension to atleast 15% ";
        }
        else if (day == 4)
        {
            tasks[0] = "Increase Earth's Opinion to atleast 65%";
            tasks[1] = "Have at leat 2..6 mil moon bucks     ";
            tasks[2] = "Increase Autonomy to atleast 50%     ";
            tasks[3] = "Organise travel for citizens to Earth  ";
        }
        else
        {
            tasks[0] = "Increase Earth's Opinion to atleast 70%";
            tasks[1] = "Increase Mars' Opinion to atleast 70%  ";
            tasks[2] = "Increase Venus' Opinion to atleast 70% ";
            tasks[3] = "Increase Public Support to atleast 70% ";
        }

        if (whiteboardText != null)
        {
            whiteboardText.text = "Day " + day + "\n" + "\n" + tasks[0] + "\n" + tasks[1] + "\n" + tasks[2] + "\n" + tasks[3];
        }
    }

    public void Family()
    {
        if (familyText != null)
        {
            if (day == 2)
            {
                familyText.text = "Wife's request: Ignore the request from Earth over the phone";
            }
            else if (day == 3)
            {
                familyText.text = "Wife's request: Leave the office at 5PM to make dinner";
            }
            else if (day == 4)
            {
                familyText.text = "Wife's request: Organise travel for Moon citizens to Mars";
            }
        }
    }

    void Tasks()
    {
        if(day == 1)
        {
            if(stats[5] >= 50)
            {
                stats[3] += 5;
            }
            else
            {
                stats[3] -= 5;
            }

            if (stats[6] >= 60)
            {
                stats[3] += 5;
            }
            else
            {
                stats[3] -= 5;
            }

            if (stats[2] >= 60)
            {
                stats[3] += 5;
            }
            else
            {
                stats[3] -= 5;
            }

            if (stats[0] >= 30)
            {
                stats[3] += 5;
            }
            else
            {
                stats[3] -= 5;
            }
        }
    }

    //Updates stats on the screen when called
    public void UpdateScreen()
    { 
        names.text = statDisplay[0] + "\n";
        nums.text = stats[0] + "\n";

        if (PCnames != null)
        {
            PCnames.text = statDisplay[0] + "\n";
            PCnums.text = stats[0] + "\n";
        }

        for (int i = 1; i < statNames.Length; i++)
        {
            names.text = names.text + "\n" + statDisplay[i] + "\n";
            nums.text = nums.text + "\n" + stats[i] + "\n";

            if (PCnames != null)
            {
                PCnames.text = PCnames.text + "\n" + statDisplay[i] + "\n";
                PCnums.text = PCnums.text + "\n" + stats[i] + "\n";
            }
        }

        if (healthEarth != null)
        {
            healthEarth.text = hEText;
            travelEarth.text = tEText;
            workEarth.text = wEText;
        }

        if (healthMars != null)
        {
            healthMars.text = hMText;
            travelMars.text = tMText;
            workMars.text = wMText;
        }

        if (healthVenus != null)
        {
            healthVenus.text = hVText;
            travelVenus.text = tVText;
            workVenus.text = wVText;
        }

        auto.value = stats[0];
        rev.value = stats[1];
        pubs.value = stats[2];
        cabs.value = stats[3];
        syst.value = stats[4];
        earth.value = stats[5];
        mars.value = stats[6];
        venus.value = stats[7];
    }

    public void TimeForward()
    {
        if(bigHand == null)
        {
            bigHand = GameObject.Find("Small Hand");
        }

        bigHand.transform.rotation = bigHand.transform.rotation * Quaternion.Euler(0f, 30f, 0f);
        time--;
    }

    void Update()
    {
        for (int i = 0; i < stats.Length; i++)
        {
            if (stats[i] < 0 && i != 4)
            {
                stats[i] = 0;
            }
            else if (i == 4 && stats[i] > 100)
            {
                stats[i] = 100;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !pause.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pause.SetActive(true);
            pauseScript.isPaused = true;
            Time.timeScale = 0;
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            time = 0;
        }

        if (time <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            time = 10;

            if (SceneManager.GetActiveScene().name == "DIVORCE")
            {
                GameObject.Find("GameInfoObject").name = "GameInfoObject DDL";
                GameObject.Find("EarthFolder").name = "Earth Folder DDL";
                GameObject.Find("MarsFolder").name = "Mars Folder DDL";
                GameObject.Find("VenusFolder").name = "Venus Folder DDL";

                if (player.GetComponent<DayOneScript>().enabled)
                {
                    DayOneScript dos = player.GetComponent<DayOneScript>();
                    dos.earthCanvas.name = "Earth Folder Canvas DDL";
                    dos.marsCanvas.name = "Mars Folder Canvas DDL";
                    dos.venusCanvas.name = "Venus Folder Canvas DDL";

                    dos.earthCanvas.SetActive(true);
                    dos.marsCanvas.SetActive(true);
                    dos.venusCanvas.SetActive(true);
                }
                else
                {
                    InteractionScript ins = player.GetComponent<InteractionScript>();
                    ins.earthCanvas.name = "Earth Folder Canvas DDL";
                    ins.marsCanvas.name = "Mars Folder Canvas DDL";
                    ins.venusCanvas.name = "Venus Folder Canvas DDL";

                    ins.earthCanvas.SetActive(true);
                    ins.marsCanvas.SetActive(true);
                    ins.venusCanvas.SetActive(true);
                }

                DontDestroyOnLoad(GameObject.Find("GameInfoObject DDL"));
                DontDestroyOnLoad(GameObject.Find("Earth Folder DDL"));
                DontDestroyOnLoad(GameObject.Find("Mars Folder DDL"));
                DontDestroyOnLoad(GameObject.Find("Venus Folder DDL"));
            }
            else
            {
                return;
            }

            for (int i = 0; i < stats.Length; i++)
            {
                if ((stats[i] <= 0 && i != 4) || (i == 4 && stats[i] >= 100))
                {
                    gameOver = gameOverText[i];
                    SceneManager.LoadScene("GameOver");
                    return;
                }
            }

            if (day == 1)
            {
                if (stats[5] >= 50)
                {
                    stats[3] += 5;
                }
                else
                {
                    stats[3] -= 5;
                }

                if (stats[6] >= 60)
                {
                    stats[3] += 5;
                }
                else
                {
                    stats[3] -= 5;
                }

                if (stats[2] >= 60)
                {
                    stats[3] += 5;
                }
                else
                {
                    stats[3] -= 5;
                }

                if (stats[0] >= 30)
                {
                    stats[3] += 5;
                }
                else
                {
                    stats[3] -= 5;
                }
            }
            else if (day == 2)
            {
                if (stats[1] >= 2.5)
                {
                    stats[3] += 5;
                }
                else
                {
                    stats[3] -= 5;
                }

                if (stats[4] <= 20)
                {
                    stats[3] += 5;
                }
                else
                {
                    stats[3] -= 5;
                }

                if (stats[7] >= 55)
                {
                    stats[3] += 5;
                }
                else
                {
                    stats[3] -= 5;
                }

                if (hEText == "Approved" || hMText == "Approved" || hVText == "Approved")
                {
                    stats[3] += 5;
                }
                else
                {
                    stats[3] -= 5;
                }
            }
            else if (day == 3)
            {
                if (stats[6] >= 65)
                {
                    stats[3] += 5;
                }
                else
                {
                    stats[3] -= 5;
                }

                if (stats[7] >= 65)
                {
                    stats[3] += 5;
                }
                else
                {
                    stats[3] -= 5;
                }

                if (stats[2] >= 65)
                {
                    stats[3] += 5;
                }
                else
                {
                    stats[3] -= 5;
                }

                if (stats[4] >= 15)
                {
                    stats[3] += 5;
                }
                else
                {
                    stats[3] -= 5;
                }
            }
            else if (day == 4)
            {
                if (stats[5] >= 70)
                {
                    stats[3] += 5;
                }
                else
                {
                    stats[3] -= 5;
                }

                if (stats[1] >= 2.6)
                {
                    stats[3] += 5;
                }
                else
                {
                    stats[3] -= 5;
                }

                if (stats[0] >= 50)
                {
                    stats[3] += 5;
                }
                else
                {
                    stats[3] -= 5;
                }

                if (tEText == "Approved")
                {
                    stats[3] += 5;
                }
                else
                {
                    stats[3] -= 5;
                }
            }
            else if (day == 5)
            {
                Debug.Log("Day");     
                SceneManager.LoadScene("EndOfWeek");
                return;
            }

            if (day > 1)
            {
                for (int k = conNum; k < contactNames.Count; k++)
                {
                    if (contactPlanets[k] == "Earth" && stats[5] > 60)
                    {
                        for (int i = 0; i < stats.Length; i++)
                        {
                            contactApprove[i] += stats[i];
                        }

                        if(contactNames[k] == "Healthcare")
                        {
                            hEText = "Approved";
                        }
                        else if(contactNames[k] == "Travel")
                        {
                            tEText = "Approved";
                        }
                        else if (contactNames[k] == "Worker Rights")
                        {
                            wEText = "Approved";
                        }
                    }
                    else if (contactPlanets[k] == "Earth" && stats[5] <= 60)
                    {
                        for (int i = 0; i < stats.Length; i++)
                        {
                            contactDecline[i] += stats[i];
                        }

                        if (contactNames[k] == "Healthcare")
                        {
                            hEText = "Declined";
                        }
                        else if (contactNames[k] == "Travel")
                        {
                            tEText = "Declined";
                        }
                        else if (contactNames[k] == "Worker Rights")
                        {
                            wEText = "Declined";
                        }
                    }
                    else if (contactPlanets[k] == "Mars" && stats[6] > 60)
                    {
                        for (int i = 0; i < stats.Length; i++)
                        {
                            contactApprove[i] += stats[i];
                        }

                        if (contactNames[k] == "Healthcare")
                        {
                            hMText = "Approved";
                        }
                        else if (contactNames[k] == "Travel")
                        {
                            tMText = "Approved";
                        }
                        else if (contactNames[k] == "Worker Rights")
                        {
                            wMText = "Approved";
                        }
                    }
                    else if (contactPlanets[k] == "Mars" && stats[6] <= 60)
                    {
                        for (int i = 0; i < stats.Length; i++)
                        {
                            contactDecline[i] += stats[i];
                        }

                        if (contactNames[k] == "Healthcare")
                        {
                            hMText = "Declined";
                        }
                        else if (contactNames[k] == "Travel")
                        {
                            tMText = "Declined";
                        }
                        else if (contactNames[k] == "Worker Rights")
                        {
                            wMText = "Declined";
                        }
                    }
                    else if (contactPlanets[k] == "Venus" && stats[7] > 60)
                    {
                        for (int i = 0; i < stats.Length; i++)
                        {
                            contactApprove[i] += stats[i];
                        }

                        if (contactNames[k] == "Healthcare")
                        {
                            hVText = "Approved";
                        }
                        else if (contactNames[k] == "Travel")
                        {
                            tVText = "Approved";
                        }
                        else if (contactNames[k] == "Worker Rights")
                        {
                            wVText = "Approved";
                        }
                    }
                    else if (contactPlanets[k] == "Venus" && stats[7] <= 60)
                    {
                        for (int i = 0; i < stats.Length; i++)
                        {
                            contactDecline[i] += stats[i];
                        }

                        if (contactNames[k] == "Healthcare")
                        {
                            hVText = "Declined";
                        }
                        else if (contactNames[k] == "Travel")
                        {
                            tVText = "Declined";
                        }
                        else if (contactNames[k] == "Worker Rights")
                        {
                            wVText = "Declined";
                        }
                    }

                    conNum = k++;
                }

                for (int i = 0; i < stats.Length; i++)
                {
                    contactApprove[i] = 0;
                    contactDecline[i] = 0;
                }
            }

            day++;
            newDay = true;

            SceneManager.LoadScene("End Of Day");

        }

        if (SceneManager.GetActiveScene().name == "DIVORCE")
        {
            if (player == null)
            {
                player = GameObject.Find("PlayerController");
            }

            if (pause == null)
            {
                pause = GameObject.Find("DialogueManager").GetComponent<DialogueManager>().pause;
                pause.SetActive(false);
            }

            if (names == null)
            {
                names = GameObject.Find("Text_Name").GetComponent<Text>();
                nums = GameObject.Find("Text_Numbers").GetComponent<Text>();

                bigHand = GameObject.Find("Small Hand");
            }

            if (pcCamera == null)
            {
                pcCamera = player.GetComponent<InteractionScript>().pcCamera;
            }

            if (PCnames == null && pcCamera != null)
            {
                pcCamera.SetActive(true);
                pcCamera.GetComponent<CameraScript>().statsPage.SetActive(true);

                PCnames = GameObject.Find("Text_Name_PC").GetComponent<Text>();
                PCnums = GameObject.Find("Text_Numbers_PC").GetComponent<Text>();

                pcCamera.GetComponent<CameraScript>().statsPage.SetActive(false);
                pcCamera.SetActive(false);
            }

            if (auto == null)
            {
                auto = GameObject.Find("AutonomySlider").GetComponent<Slider>();
                rev = GameObject.Find("RevenueSlider").GetComponent<Slider>();
                pubs = GameObject.Find("PublicSupportSlider").GetComponent<Slider>();
                cabs = GameObject.Find("CabinetSupportSlider").GetComponent<Slider>();
                syst = GameObject.Find("SystemTensionSlider").GetComponent<Slider>();
                earth = GameObject.Find("EarthRelationshipSlider").GetComponent<Slider>();
                mars = GameObject.Find("MarsRelationshipSlider").GetComponent<Slider>();
                venus = GameObject.Find("VenusRelationshipSlider").GetComponent<Slider>();

                UpdateScreen();
            }

            if (whiteboardText == null)
            {
                whiteboardText = GameObject.Find("WhiteboardText").GetComponent<Text>();
                familyText = GameObject.Find("FamilyText").GetComponent<Text>();
                NewDay();
            }

            if(moonCanvas == null)
            {
                moonCanvas = GameObject.Find("Moon Folder Canvas");
            }

            if(moonCam == null && GameObject.Find("Moon Folder Camera") != null)
            {
                moonCam = GameObject.Find("Moon Folder Camera");
            }

            if (day == 1)
            {
                moonCanvas.SetActive(false);
            }
        }
    }

    public void Submitted()
    {
        if (conPlanet == "Earth")
        {
            if(con == "Healthcare")
            {
                healthEarth.text = "Submitted";
                hEText = "Submitted";
            }
            else if (con == "Travel")
            {
                travelEarth.text = "Submitted";
                tEText = "Submitted";
            }
            else if(con == "Worker Rights")
            {
                workVenus.text = "Submitted";
                wVText = "Submitted";
            }
        }
        else if (conPlanet == "Mars")
        {
            if (con == "Healthcare")
            {
                healthMars.text = "Submitted";
                hMText = "Submitted";
            }
            else if (con == "Travel")
            {
                travelMars.text = "Submitted";
                tMText = "Submitted";
            }
            else if (con == "Worker Rights")
            {
                workMars.text = "Submitted";
                wMText = "Submitted";
            }
        }
        else if(conPlanet == "Venus")
        {
            if (con == "Healthcare")
            {
                healthVenus.text = "Submitted";
                hVText = "Submitted";
            }
            else if (con == "Travel")
            {
                travelVenus.text = "Submitted";
                tVText = "Submitted";
            }
            else if (con == "Worker Rights")
            {
                workVenus.text = "Submitted";
                wVText = "Submitted";
            }
        }
    }
      
    public void SaveGame()
    {
        SaveLoad.SavePlayer(this);
    }
}
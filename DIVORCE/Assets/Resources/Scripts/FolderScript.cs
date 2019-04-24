﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderScript : MonoBehaviour {

    InteractionScript interactionScript;
    DayOneScript dayOneScript;
    RobotDialogueTrigger dialogueTrigger;
    public Stats statsScript;

    public AudioSource audioSource;

    [Header ("Animations")]
    public Animator anim, animP1, animP2;

    [Header ("Game Objects")]
    public GameObject frontPage, taxPage, tradePage, impPage, expPage, movePage, player, playerSpawn, current, other, canvas1, canvas2, canvas3, lastPage;
    GameObject prefab, page1, page2, page3, page4, pageMain ;

    [Header ("Text Objects")]
    public Text taxText, tradeText, impText, expText, moveText, currentText;

    List<float> changes = new List<float>();
    List<string> changedNames = new List<string>();

    [Header ("Button Type")]
    public string type, buttonClicked;

    [Header("Amount of Buttons")]
    public int buttons;

    [Header("Planet")]
    public string planet;

    void Awake()
    {
        //Sets the current page to be false as long as the variable is holding an object
        if (current != null)
        {
            current.SetActive(false);
        }

        statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();

        //Set it to the front page
        current = frontPage;
        current.SetActive(true);

        player = statsScript.player;

        //Sets up the interaction from the player
        if (statsScript.day == 1)
        {
            dayOneScript = player.GetComponent<DayOneScript>();
        }
        else
        {
            interactionScript = player.GetComponent<InteractionScript>();
        }

        canvas3 = statsScript.moonCanvas;

        if (canvas3 != null)
        {
            canvas3.SetActive(false);
        }

        taxText.text = "";
        tradeText.text = "";
        impText.text = "";
        expText.text = "";
        moveText.text = "";

        dialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();
    }

    void Update()
    {
        if(player == null)
        {
            player = statsScript.player;
            interactionScript = player.GetComponent<InteractionScript>();
        }

        if(canvas1.activeInHierarchy)
        {
            canvas1.SetActive(false);
        }

        if(canvas2.activeInHierarchy)
        {
            canvas2.SetActive(false);
        }

        if(statsScript == null)
        {
            statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();
        }

        if(canvas3 == null && statsScript.day != 1)
        {
            canvas3 = GameObject.Find("Moon Folder Canvas");
            canvas3.SetActive(false);
        }

        if (statsScript.day > 1 || (dayOneScript != null && dayOneScript.firstPolicy == false))
        {
            //If the player hits F while in the folder
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (dayOneScript != null && dayOneScript.enabled == true)
                {
                    dayOneScript.policyIntractable = true;
                    dayOneScript.folder = false;
                }
                else
                {
                    interactionScript.folder = false;
                }
                Reset();

                canvas1.SetActive(true);
                canvas2.SetActive(true);

                if (canvas3 != null)
                {
                    canvas3.SetActive(true);
                }

                //Sets the current page active to false
                current.SetActive(false);

                //Resets the current page to the front page and activates it
                current = frontPage;
                current.SetActive(true);

                //Activate the player

                player.SetActive(true);

                RotationScript rot = this.transform.parent.GetComponent<RotationScript>();

                rot.endPos = GameObject.Find(planet + "StartPos").transform;
                rot.startTime = Time.time;
                rot.journeyLength = Vector3.Distance(rot.startPos.position, rot.endPos.position);

                StartCoroutine(FolderIn(rot));
                StartCoroutine(TurnBack(animP1));
                StartCoroutine(TurnBack(animP2));
            }
        }

        //If the current variable has no object attachted to it
        if(current == null)
        {
            //Set it to the front page
            current = frontPage;
            current.SetActive(true);
        }
    }

    #region FRONT PAGE

    public void Tax()
    {
        current.SetActive(false);
        lastPage = current;
        current = taxPage;
        currentText = taxText;
        type = "Tax";
        buttons = 4;
        current.SetActive(true);

        pageMain = GameObject.Find("Main Tax");
        page1 = GameObject.Find("No Tax");
        page2 = GameObject.Find("Low Tax");
        page3 = GameObject.Find("High Tax");
        page4 = GameObject.Find("Very High Tax");

        pageMain.SetActive(true);
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);

        StartCoroutine(TurnPage(animP1));
    }

    public void Trade()
    {
        current.SetActive(false);
        lastPage = current;
        current = tradePage;
        currentText = tradeText;
        type = "Trade";
        buttons = 2;
        current.SetActive(true);

        pageMain = GameObject.Find("Main Trade");
        page1 = GameObject.Find("Open Trade");
        page2 = GameObject.Find("Close Trade");

        pageMain.SetActive(true);
        page1.SetActive(false);
        page2.SetActive(false);

        StartCoroutine(TurnPage(animP1));
    }

    public void Import()
    {
        current.SetActive(false);
        lastPage = current;
        current = impPage;
        currentText = impText;
        type = "Import";
        buttons = 2;
        current.SetActive(true);

        pageMain = GameObject.Find("Main Import");
        page1 = GameObject.Find("Open Import");
        page2 = GameObject.Find("Close Import");

        pageMain.SetActive(true);
        page1.SetActive(false);
        page2.SetActive(false);

        StartCoroutine(TurnPage(animP1));
    }

    public void Export()
    {
        current.SetActive(false);
        lastPage = current;
        current = expPage;
        currentText = expText;
        type = "Export";
        buttons = 2;
        current.SetActive(true);

        pageMain = GameObject.Find("Main Export");
        page1 = GameObject.Find("Open Export");
        page2 = GameObject.Find("Close Export");

        pageMain.SetActive(true);
        page1.SetActive(false);
        page2.SetActive(false);

        StartCoroutine(TurnPage(animP1));
    }

    public void Movement()
    {
        current.SetActive(false);
        lastPage = current;
        current = movePage;
        currentText = moveText;
        type = "Movement";
        buttons = 3;
        current.SetActive(true);

        pageMain = GameObject.Find("MainMovement");
        page1 = GameObject.Find("Workers");
        page2 = GameObject.Find("Tourists");
        page3 = GameObject.Find("Students");

        pageMain.SetActive(true);
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);

        StartCoroutine(TurnPage(animP1));
    }

    #endregion

    #region TAX

    public void OpenNoTax()
    {
        pageMain.SetActive(false);
        page1.SetActive(true);

        StartCoroutine(TurnPage(animP2));
    }

    public void NoTax()
    {
        changes.Add(-0.5f);
        changes.Add(-10f);
        changes.Add(15f);

        changedNames.Add("Revenue");
        changedNames.Add("System_Tension");
        changedNames.Add(planet + "_Relationship");

        buttonClicked = "No Tax";

        ReturnToPlayer();
    }

    public void OpenLowTax()
    {
        pageMain.SetActive(false);
        page2.SetActive(true);

        StartCoroutine(TurnPage(animP2));
    }

    public void LowTax()
    {
        changes.Add(-0.3f);
        changes.Add(10f);

        changedNames.Add("Revenue");
        changedNames.Add(planet + "_Relationship");

        buttonClicked = "Low Tax";

        ReturnToPlayer();
    }

    public void OpenHighTax()
    {
        pageMain.SetActive(false);
        page3.SetActive(true);

        StartCoroutine(TurnPage(animP2));
    }

    public void HighTax()
    {
        changes.Add(0.3f);
        changes.Add(-10f);

        changedNames.Add("Revenue");
        changedNames.Add(planet + "_Relationship");

        buttonClicked = "High Tax";

        ReturnToPlayer();
    }

    public void OpenVeryHighTax()
    {
        pageMain.SetActive(false);
        page4.SetActive(true);

        StartCoroutine(TurnPage(animP2));
    }

    public void VeryHighTax()
    {
        changes.Add(0.5f);
        changes.Add(-5f);
        changes.Add(-15f);

        changedNames.Add("Revenue");
        changedNames.Add("System_Tension");
        changedNames.Add(planet + "_Relationship");

        buttonClicked = "Very High Tax";

        ReturnToPlayer();
    }

    public void TaxBack()
    {
        pageMain.SetActive(true);
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);

        StartCoroutine(TurnBack(animP2));
    }

    #endregion

    #region TRADE ROUTES

    public void OpenTradePage()
    {
        pageMain.SetActive(false);
        page1.SetActive(true);

        StartCoroutine(TurnPage(animP2));
    }

    public void OpenTrade()
    {
        changes.Add(-10f);
        changes.Add(0.2f);
        changes.Add(-5f);
        changes.Add(10f);

        changedNames.Add("Autonomy");
        changedNames.Add("Revenue");
        changedNames.Add("System_Tension");
        changedNames.Add(planet + "_Relationship");

        buttonClicked = "Open Trade";

        ReturnToPlayer();
    }

    public void CloseTradePage()
    {
        pageMain.SetActive(false);
        page2.SetActive(true);

        StartCoroutine(TurnPage(animP2));
    }

    public void CloseTrade()
    {
        changes.Add(10f);
        changes.Add(-0.2f);
        changes.Add(5f);
        changes.Add(-10f);

        changedNames.Add("Autonomy");
        changedNames.Add("Revenue");
        changedNames.Add("System_Tension");
        changedNames.Add(planet + "_Relationship");

        buttonClicked = "Closed Trade";

        ReturnToPlayer();
    }

    public void TradeBack()
    {
        pageMain.SetActive(true);
        page1.SetActive(false);
        page2.SetActive(false);

        StartCoroutine(TurnBack(animP2));
    }

    #endregion

    #region IMPORT

    public void OpenImportPage()
    {
        pageMain.SetActive(false);
        page1.SetActive(true);

        StartCoroutine(TurnPage(animP2));
    }

    public void OpenImport()
    {
        changes.Add(-10f);
        changes.Add(-0.2f);
        changes.Add(10f);
        changes.Add(10f);

        changedNames.Add("Autonomy");
        changedNames.Add("Revenue");
        changedNames.Add("Public_Support");
        changedNames.Add(planet + "_Relationship");

        buttonClicked = "Open Import";

        ReturnToPlayer();
    }

    public void CloseImportPage()
    {
        pageMain.SetActive(false);
        page2.SetActive(true);

        StartCoroutine(TurnPage(animP2));
    }

    public void CloseImport()
    {
        changes.Add(10f);
        changes.Add(0.2f);
        changes.Add(-10f);

        changedNames.Add("Autonomy");
        changedNames.Add("Revenue");
        changedNames.Add(planet + "_Relationship");

        buttonClicked = "Closed Import";

        ReturnToPlayer();
    }

    public void ImportBack()
    {
        pageMain.SetActive(true);
        page1.SetActive(false);
        page2.SetActive(false);

        StartCoroutine(TurnBack(animP2));
    }

    #endregion

    #region EXPORT

    public void OpenExportPage()
    {
        pageMain.SetActive(false);
        page1.SetActive(true);

        StartCoroutine(TurnPage(animP2));
    }

    public void OpenExport()
    {
        changes.Add(0.4f);
        changes.Add(10f);

        changedNames.Add("Revenue");
        changedNames.Add(planet + "_Relationship");

        buttonClicked = "Open Export";

        ReturnToPlayer();
    }

    public void CloseExportPage()
    {
        pageMain.SetActive(false);
        page2.SetActive(true);

        StartCoroutine(TurnPage(animP2));
    }

    public void CloseExport()
    {
        changes.Add(10f);
        changes.Add(-10f);
        changes.Add(-0.2f);

        changedNames.Add("Autonomy");
        changedNames.Add(planet + "_Relationship");
        changedNames.Add("Revenue");

        buttonClicked = "Closed Export";

        ReturnToPlayer();
    }

    public void ExportBack()
    {
        pageMain.SetActive(true);
        page1.SetActive(false);
        page2.SetActive(false);

        StartCoroutine(TurnBack(animP2));
    }

    #endregion

    #region MOVEMENT    

    public void Workers()
    {
        pageMain.SetActive(false);
        page1.SetActive(true);

        StartCoroutine(TurnPage(animP2));
    }

    public void WorkersFree()
    {
        changes.Add(-5f);
        changes.Add(-10f);
        changes.Add(-5f);
        changes.Add(5f);

        changedNames.Add("Autonomy");
        changedNames.Add("Public_Support");
        changedNames.Add("System_Tension");
        changedNames.Add(planet + "_Relationship");

        buttonClicked = "Free Worker Movement";

        MovementBack();
        ReturnToPlayer();
    }

    public void WorkersNo()
    {
        changes.Add(5f);
        changes.Add(5f);
        changes.Add(5f);
        changes.Add(-10f);

        changedNames.Add("Autonomy");
        changedNames.Add("Public_Support");
        changedNames.Add("System_Tension");
        changedNames.Add(planet + "_Relationship");

        buttonClicked = "No Worker Movement";

        MovementBack();
        ReturnToPlayer();
    }

    public void Tourists()
    {
        pageMain.SetActive(false);
        page2.SetActive(true);

        StartCoroutine(TurnPage(animP2));
    }

    public void TouristsFree()
    {
        changes.Add(0.2f);
        changes.Add(-5f);
        changes.Add(-5f);
        changes.Add(5f);

        changedNames.Add("Revenue");
        changedNames.Add("Public_Support");
        changedNames.Add("System_Tension");
        changedNames.Add(planet + "_Relationship");

        buttonClicked = "Free Tourist Movement";

        MovementBack();
        ReturnToPlayer();
    }

    public void TouristsNo()
    {
        changes.Add(-0.2f);
        changes.Add(5f);
        changes.Add(-5f);

        changedNames.Add("Revenue");
        changedNames.Add("Autonomy");
        changedNames.Add(planet + "_Relationship");

        buttonClicked = "No Tourist Movement";

        MovementBack();
        ReturnToPlayer();
    }

    public void Students()
    {
        pageMain.SetActive(false);
        page3.SetActive(true);

        StartCoroutine(TurnPage(animP2));
    }

    public void StudentsFree()
    {
        changes.Add(-5f);
        changes.Add(0.2f);
        changes.Add(-5f);
        changes.Add(5f);

        changedNames.Add("Autonomy");
        changedNames.Add("Revenue");
        changedNames.Add("Public_Support");
        changedNames.Add(planet + "_Relationship");

        buttonClicked = "Free Student Movement";

        MovementBack();
        ReturnToPlayer();
    }

    public void StudentsNo()
    {
        changes.Add(5f);
        changes.Add(-0.2f);
        changes.Add(5f);
        changes.Add(-5f);

        changedNames.Add("Autonomy");
        changedNames.Add("Revenue");
        changedNames.Add("Public_Support");
        changedNames.Add(planet + "_Relationship");

        buttonClicked = "No Student Movement";

        MovementBack();
        ReturnToPlayer();
    }

    public void MovementBack()
    {
        pageMain.SetActive(true);
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);

        StartCoroutine(TurnBack(animP2));
    }

    #endregion

    //Called when the player hits the back button on the main pages
    public void Back()
    {      
        //Sets the current to be deactivated
        current.SetActive(false);

        current = frontPage;

        current.SetActive(true);

        Reset();

        StartCoroutine(TurnBack(animP1));
    }

    //Disables the buttons on a page if the player has selected a policy
    public void DisableButton()
    {
        //Sets the last page to active in order to deactivate the buttons
        lastPage.SetActive(true);

        //Sets a text object to be displayed to the player to inform them of their choice
        currentText.gameObject.SetActive(true);
        currentText.text = buttonClicked + " is the chosen policy";

        //For each of the buttons on said page
        for(int i = 1; i <= buttons; i++)
        {
            //Deactivate the button
            GameObject.Find(type + "Button" + i).GetComponent<Button>().interactable = false;
        }

        //Set the last page to be inactive
        lastPage.SetActive(false);
    }

    //Resets the pages 
    void Reset()
    {
        if (pageMain != null)
        {
            pageMain.SetActive(true);
        }

        if (page1 != null)
        {
            page1.SetActive(true);
        }

        if (page2 != null)
        {
            page2.SetActive(true);
        }

        if (page3 != null)
        {
            page3.SetActive(true);
        }

        if (page4 != null)
        {
            page4.SetActive(true);
        }
    }

    //Returns the player to the character when they choose a policy
    void ReturnToPlayer()
    {
        statsScript.TimeForward();

        //Gets the policy page prefab from the resources folder
        prefab = (GameObject)Resources.Load("Policy", typeof(GameObject));

        //Activate the player
        player.SetActive(true);

        RotationScript rot = this.transform.parent.GetComponent<RotationScript>();

        rot.startPos = GameObject.Find("EndPos").transform;
        rot.endPos = GameObject.Find(planet + "StartPos").transform;
        rot.startTime = Time.time;
        rot.journeyLength = Vector3.Distance(rot.startPos.position, rot.endPos.position);

        StartCoroutine(FolderIn(rot));
        StartCoroutine(TurnBack(animP1));
        StartCoroutine(TurnBack(animP2));

        //Sets the current page active to false
        current.SetActive(false);

        //Resets the current page to the front page and activates it
        lastPage = current;
        current = frontPage;
        current.SetActive(true);

        PolicyScript policyScript;

        if (statsScript.day > 1)
        {
            //Sets up the prefab to be spawned on the player
            interactionScript.prefab = Instantiate(prefab, interactionScript.spawnPos.transform.position, GameObject.Find("MainCamera").transform.rotation);
            interactionScript.prefab.transform.parent = GameObject.Find("SpawnPos").transform;
            interactionScript.holdingPolicy = true;
            interactionScript.holding = true;
            interactionScript.policy = true;
            interactionScript.folder = false;

            //Calls the folder and policy methods within the interaction script
            interactionScript.PolicyScript();

            policyScript = interactionScript.prefab.GetComponent<PolicyScript>();
        }
        else
        {
            if (dayOneScript.firstFolder)
            {
                dialogueTrigger.TriggerRobotDialogue9();
            }

            dayOneScript.prefab = Instantiate(prefab, dayOneScript.spawnPos.position, GameObject.Find("MainCamera").transform.rotation);
            dayOneScript.prefab.transform.parent = GameObject.Find("SpawnPos").transform;
            dayOneScript.policy = true;
            dayOneScript.holding = true;
            dayOneScript.folder = false;

            dayOneScript.PolicyScript();

            policyScript = dayOneScript.prefab.GetComponent<PolicyScript>();

            //if (dayOneScript.uses == 2)
            //{
            //    firstUse = false;
            //}
        }

        //Sets up the stats for the policy script
        policyScript.UpdatePolicy(changes, changedNames);
        policyScript.type = type;
        policyScript.chosenPolicy = buttonClicked;
        policyScript.buttonAmount = buttons;
        policyScript.planet = planet;

        if (type == "Movement")
        {    
            policyScript.movement = buttonClicked;
            policyScript.pfm = planet;
        }

        //Clears the lists onced they have been used
        changedNames.Clear();
        changes.Clear();

        canvas1.SetActive(true);
        canvas2.SetActive(true);

        if (canvas3 != null)
        {
            canvas3.SetActive(true);
        }

        Reset();
    }

    IEnumerator FolderIn(RotationScript rot)
    {
        anim.Play("Close");

        yield return new WaitForSeconds(1f);

        rot.Run();
        rot.enabled = true;

        yield return new WaitForSeconds(1.25f);

        rot.enabled = false;

        //Deactivate the camera for the folder
        gameObject.SetActive(false);
    }

    IEnumerator TurnPage(Animator animP)
    {
        current.SetActive(false);

        audioSource.Play();

        animP.Play("Page Turn");

        yield return new WaitForSeconds(0.25f);

        current.SetActive(true);

    }

    IEnumerator TurnBack(Animator animP)
    {
        audioSource.Play();

        animP.Play("Page Back");

        new WaitForSeconds(0.5f);

        current.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        current.SetActive(true);
    }
}

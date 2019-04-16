using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndOfDayScript : MonoBehaviour
{
    Stats statsScript;
    //PolicyChoices policyChoices;

    public int noOfTasks = 0;

    [Header("Day One")]
    public string task1Complete_1;
    public string task1Fail_1;
    public string task2Complete_1;
    public string task2Fail_1;
    public string task3Complete_1;
    public string task3Fail_1;
    public string task4Complete_1;
    public string task4Fail_1;

    public string conferenceAccept_1;
    public string conferenceDecline_1;

    [Header("Day Two")]
    public string task1Complete_2;
    public string task1Fail_2;
    public string task2Complete_2;
    public string task2Fail_2;
    public string task3Complete_2;
    public string task3Fail_2;

    public string wifeAccept_2;
    public string wifeDecline_2;

    //public string A_2;
    //public string B_2;
    //public string C_2;
    //public string D_2;

    //public string phone1A;
    //public string phone1B;

    //public string phone2A;
    //public string phone2B;
    //public string phone2C;

    //public string[] policyName;
    //public string[] policyDescription;
    //List<int> description = new List<int>();

    public Text task1_1Text;
    public Text task2_1Text;
    public Text task3_1Text;
    public Text task4_1Text;

    public Text task1_2Text;
    public Text task2_2Text;
    public Text task3_2Text;

    //public Text policy1Text;
    //public Text policyText_2;

    //public Text phone1Text;
    //public Text phone2Text;

    public Text conferenceText;
    //public Text conferenceText_2;

    public Text wifeText;

    public Text contactText;

    public Button saveButton;

    public GameObject day1Panel;
    public GameObject day2Panel;

    public GameObject loadingPanel;
    public GameObject savePanel;

    bool save;

    bool task1;
    bool task2;
    bool task3;
    bool task4;
    bool wife;
    bool conferenceCall;
    bool lastCheck;

    void Start()
    {
        statsScript = GameObject.FindObjectOfType<Stats>();
        //policyChoices = GameObject.FindObjectOfType<PolicyChoices>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        loadingPanel.gameObject.SetActive(false);
        savePanel.gameObject.SetActive(false);

        save = false;

        saveButton.onClick.AddListener(statsScript.SaveGame);

        noOfTasks = 0;

        wifeText.gameObject.SetActive(false);
        contactText.gameObject.SetActive(false);
        conferenceText.gameObject.SetActive(false);

        task1 = true;
        task2 = false;
        task3 = false;
        task4 = false;
        wife = false;
        conferenceCall = false;
        lastCheck = false;

        if (statsScript.day - 1 == 1)
        {
            day1Panel.gameObject.SetActive(true);
            day2Panel.gameObject.SetActive(false);

            task1_1Text.gameObject.SetActive(true);
            task2_1Text.gameObject.SetActive(false);
            task3_1Text.gameObject.SetActive(false);
            task4_1Text.gameObject.SetActive(false);

            CheckTasks();
            CheckConferenceCall();
        }
        else if (statsScript.day - 1 == 2)
        {
            day1Panel.gameObject.SetActive(false);
            day2Panel.gameObject.SetActive(true);

            task1_2Text.gameObject.SetActive(true);
            task2_2Text.gameObject.SetActive(false);
            task3_2Text.gameObject.SetActive(false);

            CheckTasks();
            CheckWife();
            CheckContacts();
        }
    }

    public void CheckTasks()
    {
        if (statsScript.day - 1 == 1)
        {
            if (statsScript.stats[5] >= 50)
            {
                task1_1Text.text = task1Complete_1;
            }
            else
            {
                task1_1Text.text = task1Fail_1;
            }

            if (statsScript.stats[6] >= 60)
            {
                task2_1Text.text = task2Complete_1;
            }
            else
            {
                task2_1Text.text = task2Fail_1;
            }

            if (statsScript.stats[2] >= 60)
            {
                task3_1Text.text = task3Complete_1;
            }
            else
            {
                task3_1Text.text = task3Fail_1;
            }

            if (statsScript.stats[0] >= 30)
            {
                task4_1Text.text = task4Complete_1;
            }
            else
            {
                task4_1Text.text = task4Fail_1;
            }
        }
        else if (statsScript.day - 1 == 2)
        {
            if (statsScript.stats[1] >= 2.5)
            {
                task1_2Text.text = task1Complete_2;
            }
            else
            {
                task1_2Text.text = task1Fail_2;
            }

            if (statsScript.stats[4] <= 20)
            {
                task2_2Text.text = task2Complete_2;
            }
            else
            {
                task2_2Text.text = task2Fail_2;
            }

            if (statsScript.stats[7] >= 55)
            {
                task3_2Text.text = task3Complete_2;
            }
            else
            {
                task3_2Text.text = task3Fail_2;
            }

        }
        else if (statsScript.day - 1 == 3)
        {
            if (statsScript.stats[6] >= 65)
            {
                noOfTasks++;
            }

            if (statsScript.stats[7] >= 65)
            {
                noOfTasks++;
            }

            if (statsScript.stats[2] >= 65)
            {
                noOfTasks++;
            }

            if (statsScript.stats[4] >= 15)
            {
                noOfTasks++;
            }
        }
        else if (statsScript.day - 1 == 4)
        {
            if (statsScript.stats[5] >= 70)
            {
                noOfTasks++;
            }

            if (statsScript.stats[1] >= 2.6)
            {
                noOfTasks++;
            }

            if (statsScript.stats[0] >= 50)
            {
                noOfTasks++;
            }

            if (statsScript.tEText == "Approved")
            {
                noOfTasks++;
            }
        }
    }

    //public void CheckPolicy()
    //{
    //    foreach (string j in statsScript.chosenPolicies)
    //    {
    //        for (int i = 0; i < policyName.Length; i++)
    //        {
    //            if (j == policyName[i])
    //            {
    //                description.Add(i);
    //            }
    //        }
    //    }

    //    if (statsScript.day - 1 == 1)
    //    {
    //        if (statsScript.chosenPolicies.Count == 1)
    //        {
    //            policy1Text.text = "You also took your first steps into shaping the future of the independent moon by enacting the " + statsScript.chosenPolicies[0] + " policy for Earth, which means " + policyDescription[description[0]];
    //            statsScript.policyCounter = 1;
    //        }
    //        else if (statsScript.chosenPolicies.Count == 2)
    //        {
    //            policy1Text.text = "You also took your first steps into shaping the future of the independent moon by enacting the " + statsScript.chosenPolicies[0] + " policy for Earth, which means " + policyDescription[description[0]] + " Following that, you enacted the " + statsScript.chosenPolicies[1] + " policy for " + statsScript.chosenPlanets[1] + ", which means " + policyDescription[description[1]];
    //            statsScript.policyCounter = 2;
    //        }
    //        else if (statsScript.chosenPolicies.Count == 3)
    //        {
    //            policy1Text.text = "You also took your first steps into shaping the future of the independent moon by enacting the " + statsScript.chosenPolicies[0] + " policy for Earth, which means " + policyDescription[description[0]] + " Following that, you enacted the " + statsScript.chosenPolicies[1] + " policy for " + statsScript.chosenPlanets[1] + ", which means " + policyDescription[description[1]] + " After that, you enacted the " + statsScript.chosenPolicies[2] + " policy for " + statsScript.chosenPlanets[2] + ", which means " + policyDescription[description[2]];
    //            statsScript.policyCounter = 3;
    //        }
    //    }

    //    else if (statsScript.day - 1 == 2)
    //    {
    //        if (statsScript.policyCounter == 1)
    //        {
    //            if (statsScript.chosenPolicies.Count == 2)
    //            {
    //                policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[1] + " policy for " + statsScript.chosenPlanets[1] + ", which means " + policyDescription[description[1]];
    //                statsScript.policyCounter = 2;
    //            }
    //            else if (statsScript.chosenPolicies.Count == 3)
    //            {
    //                policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[1] + " policy for " + statsScript.chosenPlanets[1] + ", which means " + policyDescription[description[1]] + " You then enacted the " + statsScript.chosenPolicies[2] + " policy for " + statsScript.chosenPlanets[2] + ", which means " + policyDescription[description[2]];
    //                statsScript.policyCounter = 3;
    //            }
    //            else if (statsScript.chosenPolicies.Count == 4)
    //            {
    //                policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[1] + " policy for " + statsScript.chosenPlanets[1] + ", which means " + policyDescription[description[1]] + " You then enacted the " + statsScript.chosenPolicies[2] + " policy for " + statsScript.chosenPlanets[2] + ", which means " + policyDescription[description[2]] + "As you had some free time, you also enacted the " + statsScript.chosenPolicies[3] + " policy for " + statsScript.chosenPlanets[3] + ", which means " + policyDescription[description[3]];
    //                statsScript.policyCounter = 4;
    //            }
    //        }
    //        else if (statsScript.policyCounter == 2)
    //        {
    //            if (statsScript.chosenPolicies.Count == 3)
    //            {
    //                policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[2] + " policy for " + statsScript.chosenPlanets[2] + ", which means " + policyDescription[description[2]];
    //                statsScript.policyCounter = 3;
    //            }
    //            else if (statsScript.chosenPolicies.Count == 4)
    //            {
    //                policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[2] + " policy for " + statsScript.chosenPlanets[2] + ", which means " + policyDescription[description[2]] + " You then enacted the " + statsScript.chosenPolicies[3] + " policy for " + statsScript.chosenPlanets[3] + ", which means " + policyDescription[description[3]];
    //                statsScript.policyCounter = 4;
    //            }
    //            else if (statsScript.chosenPolicies.Count == 5)
    //            {
    //                policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[2] + " policy for " + statsScript.chosenPlanets[2] + ", which means " + policyDescription[description[2]] + " You then enacted the " + statsScript.chosenPolicies[3] + " policy for " + statsScript.chosenPlanets[3] + ", which means " + policyDescription[description[3]] + "As you had some free time, you also enacted the " + statsScript.chosenPolicies[4] + " policy for " + statsScript.chosenPlanets[4] + ", which means " + policyDescription[description[4]];
    //                statsScript.policyCounter = 5;
    //            }
    //        }
    //        else if (statsScript.policyCounter == 3)
    //        {
    //            if (statsScript.chosenPolicies.Count == 4)
    //            {
    //                policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[3] + " policy for " + statsScript.chosenPlanets[3] + ", which means " + policyDescription[description[3]];
    //                statsScript.policyCounter = 4;
    //            }
    //            else if (statsScript.chosenPolicies.Count == 5)
    //            {
    //                policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[3] + " policy for " + statsScript.chosenPlanets[3] + ", which means " + policyDescription[description[3]] + " You then enacted the " + statsScript.chosenPolicies[4] + " policy for " + statsScript.chosenPlanets[4] + ", which means " + policyDescription[description[4]];
    //                statsScript.policyCounter = 5;
    //            }
    //            else if (statsScript.chosenPolicies.Count == 6)
    //            {
    //                policy1Text.text = "You then enacted some policies; where you enacted the " + statsScript.chosenPolicies[3] + " policy for " + statsScript.chosenPlanets[3] + ", which means " + policyDescription[description[3]] + " You then enacted the " + statsScript.chosenPolicies[4] + " policy for " + statsScript.chosenPlanets[4] + ", which means " + policyDescription[description[4]] + "As you had some free time, you also enacted the " + statsScript.chosenPolicies[5] + " policy for " + statsScript.chosenPlanets[5] + ", which means " + policyDescription[description[5]];
    //                statsScript.policyCounter = 6;
    //            }
    //        }
    //    }
    //}

    //public void CheckPhone()
    //{
    //    if (statsScript.phone1Answered == true && statsScript.phone1Accept == true)
    //    {
    //        phone1Text.text = "Immediately after that, you " + phone1A; 
    //    }
    //    else if (statsScript.phone1Answered == true && statsScript.phone1Accept == false)
    //    {
    //        phone1Text.text = "Immediately after that, you " + phone1B;
    //    }

    //    if (statsScript.phone2Answered == true && statsScript.phone2Accept == true)
    //    {
    //        phone2Text.text = phone2A;
    //    }
    //    else if (statsScript.phone2Answered == true && statsScript.phone2Accept == false)
    //    {
    //        phone2Text.text = phone2B;
    //    }
    //    else if (statsScript.phone2Answered == false)
    //    {
    //        phone2Text.text = phone2C;
    //    }
    //}

    public void CheckConferenceCall()
    {
        if (statsScript.day - 1 == 1)
        {
            //Checks if player chose to open or close the border during the conference call
            if (statsScript.conferenceAccept == true)
            {
                conferenceText.text = conferenceAccept_1;
            }
            else if (statsScript.conferenceAccept == false)
            {
                conferenceText.text = conferenceDecline_1;
            }
        }
        else if (statsScript.day - 1 == 2)
        {
            //if (statsScript.conferenceAccept == true)
            //{
            //    conferenceText_2.text = "Your negotiations with the Martians went " + conferenceA_2;
            //}
            //else
            //{
            //    conferenceText_2.text = "Your negotiations with the Martians went " + conferenceB_2;
            //}
        }
    }

    public void CheckWife()
    {
        if (statsScript.day - 1 == 2)
        {
            if (statsScript.wifeCounter == 1)
            {
                wifeText.text = wifeAccept_2;

                statsScript.actionsText = statsScript.actionsText + "\n" + "Wife's requested accepted";
            }
            else
            {
                wifeText.text = wifeDecline_2;

                statsScript.actionsText = statsScript.actionsText + "\n" + "Wife's requested declined";
            }
        }
    }

    public void CheckContacts()
    {
        if (statsScript.day - 1 == 2)
        {
            if (statsScript.hEText == "Approved" && statsScript.hMText == "Approved" && statsScript.hVText == "Approved")
            {
                contactText.text = "As for the healthcare matter, fortunately, your request for it to Earth, Venus and Mars got accepted, which is great! Now our citizens will have one less thing to worry about when travelling there, this will certainly improve the public’s opinion of you, though it might diminish our sense of autonomy.";
            }
            else if (statsScript.hEText == "Approved" && statsScript.hMText == "Approved")
            {
                contactText.text = "As for the healthcare matter, fortunately, your request for it to Earth and Mars got accepted, which is great! Now our citizens will have one less thing to worry about when travelling there, this will certainly improve the public’s opinion of you, though it might diminish our sense of autonomy.";
            }
            else if (statsScript.hEText == "Approved" && statsScript.hVText == "Approved")
            {
                contactText.text = "As for the healthcare matter, fortunately, your request for it to Earth and Venus got accepted, which is great! Now our citizens will have one less thing to worry about when travelling there, this will certainly improve the public’s opinion of you, though it might diminish our sense of autonomy.";
            }
            else if (statsScript.hMText == "Approved" && statsScript.hVText == "Approved")
            {
                contactText.text = "As for the healthcare matter, fortunately, your request for it to Mars and Venus got accepted, which is great! Now our citizens will have one less thing to worry about when travelling there, this will certainly improve the public’s opinion of you, though it might diminish our sense of autonomy.";
            }
            else if (statsScript.hEText == "Approved")
            {
                contactText.text = "As for the healthcare matter, fortunately, your request for it to Earth got accepted, which is great! Now our citizens will have one less thing to worry about when travelling there, this will certainly improve the public’s opinion of you, though it might diminish our sense of autonomy.";
            }
            else if (statsScript.hMText == "Approved")
            {
                contactText.text = "As for the healthcare matter, fortunately, your request for it to Mars got accepted, which is great! Now our citizens will have one less thing to worry about when travelling there, this will certainly improve the public’s opinion of you, though it might diminish our sense of autonomy.";
            }
            else if (statsScript.hVText == "Approved")
            {
                contactText.text = "As for the healthcare matter, fortunately, your request for it to Venus got accepted, which is great! Now our citizens will have one less thing to worry about when travelling there, this will certainly improve the public’s opinion of you, though it might diminish our sense of autonomy.";
            }

            else if (statsScript.hEText != "Approved" && statsScript.hMText != "Approved" && statsScript.hVText != "Approved")
            {
                contactText.text = "As for the healthcare matter, unfortunately none of the requests you sent for it got accepted, which is bad… Not only will the cabinet disapprove, but the people won’t be happy about it too. For future reference, when you send an outbound contact to a planet, you might want to ensure your relationship with them is decent at the end of the day.";
            }
        }
    }
    
    public void Continue()
    {
        if (task1)
        {
            if (statsScript.day - 1 == 1)
            {
                task1_1Text.gameObject.SetActive(false);
                task2_1Text.gameObject.SetActive(true);
            }
            else if (statsScript.day - 1 == 2)
            {
                task1_2Text.gameObject.SetActive(false);
                task2_2Text.gameObject.SetActive(true);
            }

            task2 = true;
            task1 = false;
        }
        else if (task2)
        {
            if (statsScript.day - 1 == 1)
            {
                task2_1Text.gameObject.SetActive(false);
                task3_1Text.gameObject.SetActive(true);
            }
            else if (statsScript.day - 1 == 2)
            {
                task2_2Text.gameObject.SetActive(false);
                task3_2Text.gameObject.SetActive(true);
            }

            task3 = true;
            task2 = false;
        }
        else if (task3)
        {
            if (statsScript.day - 1 == 1)
            {
                task3_1Text.gameObject.SetActive(false);
                task4_1Text.gameObject.SetActive(true);
            }
            else if (statsScript.day - 1 == 2)
            {
                task3_2Text.gameObject.SetActive(false);
                contactText.gameObject.SetActive(true);
            }

            task4 = true;
            task3 = false;
        }
        else if (task4)
        {
            if (statsScript.day - 1 == 1)
            {
                task4_1Text.gameObject.SetActive(false);
                conferenceText.gameObject.SetActive(true);
            }
            else if (statsScript.day - 1 == 2)
            {
                contactText.gameObject.SetActive(false);
                wifeText.gameObject.SetActive(true);
            }

            lastCheck = true;
            task4 = false;
        }
        else if (lastCheck)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            statsScript.phone1Accept = false;
            statsScript.phone1Answered = false;
            statsScript.phone2Accept = false;
            statsScript.phone1Answered = false;
            statsScript.conferenceAccept = false;
            statsScript.conferenceAcceptWithHaggle = false;
            loadingPanel.gameObject.SetActive(true);
            SceneManager.LoadScene("DIVORCE");
        }
    }

    public void SaveGame()
    {
        statsScript.SaveGame();
        save = true;
        savePanel.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (save)
        {
            if (Input.GetMouseButtonDown(0))
            {
                savePanel.gameObject.SetActive(false);
                save = false;
            }
        }
    }
}

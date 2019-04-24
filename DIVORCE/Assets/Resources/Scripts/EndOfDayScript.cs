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
    [TextArea(3, 154)]
    public string task1Complete_1;
    [TextArea(3, 154)]
    public string task1Fail_1;
    [TextArea(3, 154)]
    public string task2Complete_1;
    [TextArea(3, 154)]
    public string task2Fail_1;
    [TextArea(3, 154)]
    public string task3Complete_1;
    [TextArea(3, 154)]
    public string task3Fail_1;
    [TextArea(3, 154)]
    public string task4Complete_1;
    [TextArea(3, 154)]
    public string task4Fail_1;

    [TextArea(3, 154)]
    public string conferenceAccept_1;
    [TextArea(3, 154)]
    public string conferenceDecline_1;

    [Header("Day Two")]
    [TextArea(3, 154)]
    public string task1Complete_2;
    [TextArea(3, 154)]
    public string task1Fail_2;
    [TextArea(3, 154)]
    public string task2Complete_2;
    [TextArea(3, 154)]
    public string task2Fail_2;
    [TextArea(3, 154)]
    public string task3Complete_2;
    [TextArea(3, 154)]
    public string task3Fail_2;

    [TextArea(3, 154)]
    public string wifeAccept_1;
    [TextArea(3, 154)]
    public string wifeDecline_1;

    [TextArea(3, 154)]
    public string conferenceAccept_2;
    [TextArea(3, 154)]
    public string conferenceDecline_2;

    [Header("Day Three")]
    [TextArea(3, 154)]
    public string task1Complete_3;
    [TextArea(3, 154)]
    public string task1Fail_3;
    [TextArea(3, 154)]
    public string task2Complete_3;
    [TextArea(3, 154)]
    public string task2Fail_3;
    [TextArea(3, 154)]
    public string task3Complete_3;
    [TextArea(3, 154)]
    public string task3Fail_3;
    [TextArea(3, 154)]
    public string task4Complete_3;
    [TextArea(3, 154)]
    public string task4Fail_3;

    [TextArea(3, 154)]
    public string wifeAccept_2;
    [TextArea(3, 154)]
    public string wifeDecline_2;

    [TextArea(3, 154)]
    public string conferenceAccept_3;
    [TextArea(3, 154)]
    public string conferenceDecline_3;
    [TextArea(3, 154)]
    public string conferenceIgnore;

    [Header("Day Four")]
    [TextArea(3, 154)]
    public string task1Complete_4;
    [TextArea(3, 154)]
    public string task1Fail_4;
    [TextArea(3, 154)]
    public string task2Complete_4;
    [TextArea(3, 154)]
    public string task2Fail_4;
    [TextArea(3, 154)]
    public string task3Complete_4;
    [TextArea(3, 154)]
    public string task3Fail_4;

    [TextArea(3, 154)]
    public string contactAccept;
    [TextArea(3, 154)]
    public string contactDecline;
    [TextArea(3, 154)]
    public string contactNotSubmitted;

    [TextArea(3, 154)]
    public string wifeAccept_3;
    [TextArea(3, 154)]
    public string wifeDecline_3;

    [TextArea(3, 154)]
    public string conferenceAccept_4;
    [TextArea(3, 154)]
    public string conferenceDecline_4;

    [Header("Text Areas")]
    public Text task1_1Text;
    public Text task2_1Text;
    public Text task3_1Text;
    public Text task4_1Text;

    public Text task1_2Text;
    public Text task2_2Text;
    public Text task3_2Text;

    public Text task1_3Text;
    public Text task2_3Text;
    public Text task3_3Text;
    public Text task4_3Text;

    public Text task1_4Text;
    public Text task2_4Text;
    public Text task3_4Text;


    public Text conference1Text;
    public Text conference2Text;
    public Text conference3Text;
    public Text conference4Text;

    public Text wife1Text;
    public Text wife2Text;
    public Text wife3Text;

    public Text contactText;
    public Text contact2Text;

    [Header("UI")]
    public Button saveButton;

    public GameObject day1Panel;
    public GameObject day2Panel;
    public GameObject day3Panel;
    public GameObject day4Panel;

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

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        loadingPanel.gameObject.SetActive(false);
        savePanel.gameObject.SetActive(false);

        save = false;

        saveButton.onClick.AddListener(statsScript.SaveGame);

        noOfTasks = 0;

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
            day3Panel.gameObject.SetActive(false);
            day4Panel.gameObject.SetActive(false);

            task1_1Text.gameObject.SetActive(true);
            task2_1Text.gameObject.SetActive(false);
            task3_1Text.gameObject.SetActive(false);
            task4_1Text.gameObject.SetActive(false);

            conference1Text.gameObject.SetActive(false);

            CheckTasks();
            CheckConferenceCall();
        }
        else if (statsScript.day - 1 == 2)
        {
            day1Panel.gameObject.SetActive(false);
            day2Panel.gameObject.SetActive(true);
            day3Panel.gameObject.SetActive(false);
            day4Panel.gameObject.SetActive(false);

            task1_2Text.gameObject.SetActive(true);
            task2_2Text.gameObject.SetActive(false);
            task3_2Text.gameObject.SetActive(false);

            wife1Text.gameObject.SetActive(false);
            contactText.gameObject.SetActive(false);
            conference2Text.gameObject.SetActive(false);

            CheckTasks();
            CheckWife();
            CheckContacts();
            CheckConferenceCall();
        }
        else if (statsScript.day - 1 == 3)
        {
            day1Panel.gameObject.SetActive(false);
            day2Panel.gameObject.SetActive(false);
            day3Panel.gameObject.SetActive(true);
            day4Panel.gameObject.SetActive(false);

            task1_3Text.gameObject.SetActive(true);
            task2_3Text.gameObject.SetActive(false);
            task3_3Text.gameObject.SetActive(false);
            task4_3Text.gameObject.SetActive(false);

            wife2Text.gameObject.SetActive(false);
            conference3Text.gameObject.SetActive(false);

            CheckTasks();
            CheckWife();
            CheckConferenceCall();
        }
        else if (statsScript.day - 1 == 4)
        {
            day1Panel.gameObject.SetActive(false);
            day2Panel.gameObject.SetActive(false);
            day3Panel.gameObject.SetActive(false);
            day4Panel.gameObject.SetActive(true);

            task1_4Text.gameObject.SetActive(true);
            task2_4Text.gameObject.SetActive(false);
            task3_4Text.gameObject.SetActive(false);

            wife3Text.gameObject.SetActive(false);
            contact2Text.gameObject.SetActive(false);
            conference4Text.gameObject.SetActive(false);

            CheckTasks();
            CheckWife();
            CheckContacts();
            CheckConferenceCall();
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
                task1_3Text.text = task1Complete_3;
            }
            else
            {
                task1_3Text.text = task1Fail_3;
            }

            if (statsScript.stats[2] >= 65)
            {
                task2_3Text.text = task2Complete_3;
            }
            else
            {
                task2_3Text.text = task2Fail_3;
            }

            if (statsScript.stats[7] >= 65)
            {
                task3_3Text.text = task3Complete_3;
            }
            else
            {
                task3_3Text.text = task3Fail_3;
            }

            if (statsScript.stats[4] <= 15)
            {
                task4_3Text.text = task4Complete_3;
            }
            else
            {
                task4_3Text.text = task4Fail_3;
            }
        }
        else if (statsScript.day - 1 == 4)
        {
            if (statsScript.stats[5] >= 65)
            {
                task1_4Text.text = task1Complete_4;
            }
            else
            {
                task1_4Text.text = task1Fail_4;
            }

            if (statsScript.stats[1] >= 2.6)
            {
                task2_4Text.text = task2Complete_4;
            }
            else
            {
                task2_4Text.text = task2Fail_4;
            }

            if (statsScript.stats[0] >= 50)
            {
                task3_4Text.text = task3Complete_4;
            }
            else
            {
                task3_4Text.text = task3Fail_4;
            }
        }
    }

    public void CheckConferenceCall()
    {
        if (statsScript.day - 1 == 1)
        {
            //Checks if player chose to open or close the border during the conference call
            if (statsScript.conferenceAccept == true)
            {
                conference1Text.text = conferenceAccept_1;
            }
            else if (statsScript.conferenceAccept == false)
            {
                conference1Text.text = conferenceDecline_1;
            }
        }
        else if (statsScript.day - 1 == 2)
        {
            if (statsScript.conferenceAccept == true)
            {
                conference2Text.text = conferenceAccept_2;
            }
            else if (statsScript.conferenceAccept == false)
            {
                conference2Text.text = conferenceDecline_2;
            }
        }
        else if (statsScript.day - 1 == 3)
        {
            if (statsScript.conferenceIgnore == true)
            {
                conference3Text.text = conferenceIgnore;
            }
            else if (statsScript.conferenceAccept == true)
            {
                conference3Text.text = conferenceAccept_3;
            }
            else if (statsScript.conferenceAccept == false)
            {
                conference3Text.text = conferenceDecline_3;
            }
        }
        else if (statsScript.day - 1 == 4)
        {
            if (statsScript.conferenceAccept == true)
            {
                conference4Text.text = conferenceAccept_4;
            }
            else if (statsScript.conferenceAccept == false)
            {
                conference4Text.text = conferenceDecline_4;
            }
        }
    }

    public void CheckWife()
    {
        if (statsScript.day - 1 == 2)
        {
            if (statsScript.wifeCounter > 0)
            {
                wife1Text.text = wifeAccept_1;

                statsScript.actionsText = statsScript.actionsText + "\n" + "Wife's requested accepted";
            }
            else
            {
                wife1Text.text = wifeDecline_1;

                statsScript.actionsText = statsScript.actionsText + "\n" + "Wife's requested declined";
            }
        }
        if (statsScript.day - 1 == 3)
        {
            if (statsScript.wifeCounter2 > 0)
            {
                wife2Text.text = wifeAccept_2;

                statsScript.actionsText = statsScript.actionsText + "\n" + "Wife's requested accepted";
            }
            else
            {
                wife2Text.text = wifeDecline_2;

                statsScript.actionsText = statsScript.actionsText + "\n" + "Wife's requested declined";
            }
        }

        if (statsScript.day - 1 == 4)
        {
            if (statsScript.tMText == "Approved")
            {
                wife3Text.text = wifeAccept_3;

                statsScript.actionsText = statsScript.actionsText + "\n" + "Wife's requested accepted";
            }
            else
            {
                wife3Text.text = wifeDecline_3;

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

        if (statsScript.day - 1 == 4)
        {
            if (statsScript.tEText == "Approved")
            {
                contact2Text.text = contactAccept;
            }
            else if (statsScript.tEText == "Declined")
            {
                contact2Text.text = contactDecline;
            }
            else
            {
                contact2Text.text = contactNotSubmitted;
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
            else if (statsScript.day - 1 == 3)
            {
                task1_3Text.gameObject.SetActive(false);
                task2_3Text.gameObject.SetActive(true);
            }
            else if (statsScript.day - 1 == 4)
            {
                task1_4Text.gameObject.SetActive(false);
                task2_4Text.gameObject.SetActive(true);
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
            else if (statsScript.day - 1 == 3)
            {
                task2_3Text.gameObject.SetActive(false);
                task3_3Text.gameObject.SetActive(true);
            }
            else if (statsScript.day - 1 == 4)
            {
                task2_4Text.gameObject.SetActive(false);
                task3_4Text.gameObject.SetActive(true);
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
            else if (statsScript.day - 1 == 3)
            {
                task3_3Text.gameObject.SetActive(false);
                task4_3Text.gameObject.SetActive(true);
            }
            else if (statsScript.day - 1 == 4)
            {
                task3_4Text.gameObject.SetActive(false);
                contact2Text.gameObject.SetActive(true);
            }

            task4 = true;
            task3 = false;
        }
        else if (task4)
        {
            if (statsScript.day - 1 == 1)
            {
                task4_1Text.gameObject.SetActive(false);
                conference1Text.gameObject.SetActive(true);
                lastCheck = true;
            }
            else if (statsScript.day - 1 == 2)
            {
                contactText.gameObject.SetActive(false);
                wife1Text.gameObject.SetActive(true);
                wife = true;
            }
            else if (statsScript.day - 1 == 3)
            {
                task4_3Text.gameObject.SetActive(false);
                wife2Text.gameObject.SetActive(true);
                wife = true;
            }
            else if (statsScript.day - 1 == 4)
            {
                contact2Text.gameObject.SetActive(false);
                wife3Text.gameObject.SetActive(true);
                wife = true;
            }
            task4 = false;
        }
        else if (wife)
        {
            if (statsScript.day - 1 == 2)
            {
                wife1Text.gameObject.SetActive(false);
                conference2Text.gameObject.SetActive(true);
            }
            if (statsScript.day - 1 == 3)
            {
                wife2Text.gameObject.SetActive(false);
                conference3Text.gameObject.SetActive(true);
            }
            if (statsScript.day - 1 == 4)
            {
                wife3Text.gameObject.SetActive(false);
                conference4Text.gameObject.SetActive(true);
            }

            lastCheck = true;
            wife = false;
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

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Code used in Dialogue, Dialogue Manager, Dialogue Trigger, Robot Dialogue, Robot Dialogue Manager and Robot Dialogue Trigger was used and expanded upon from a video tutorial
// "How to make a dialogue system in Unity" - Brackeys https://www.youtube.com/watch?v=_nRzoTzeyxU

public class DialogueManager : MonoBehaviour {

    public Text planetText;
    public Text dialogueText;

    public GameObject speakerPanel;
    public GameObject answerPanel;
    public GameObject pause;

    public Stats statsScript;
    DialogueTrigger dialogueTrigger;
    RobotDialogueTrigger robotDialogueTrigger;
    DayOneScript dayOneScript;
    InteractionScript interactionScript;

    public GameObject conferenceCall;
    public GameObject player;

    public Button option1;
    public Button option2;
    public Button option3;
    public Button continueButton;

    private Queue<string> sentences;
    private Queue<string> sentences2;
    private Queue<string> sentences3;
    private Queue<string> sentences4;
    private Queue<string> sentences5;
    private Queue<string> sentences7;
    private Queue<string> sentences9;

    private Queue<AudioClip> audio1;
    private Queue<AudioClip> audio2;
    private Queue<AudioClip> audio3;
    private Queue<AudioClip> audio4;
    private Queue<AudioClip> audio5;
    private Queue<AudioClip> audio7;
    private Queue<AudioClip> audio9;

    AudioSource audioSource;

    [Header("Day One Audio")]

    public AudioClip[] audioClip1;
    public AudioClip[] audioClip2;
    public AudioClip[] audioClip3;
    public AudioClip[] audioClip4;
    public AudioClip[] audioClip5;
    public AudioClip[] audioClip7;
    public AudioClip[] audioClip9;

    [Header("Day Two Audio")]

    public AudioClip[] audioClip2_1;
    public AudioClip[] audioClip2_2;
    public AudioClip[] audioClip2_3;
    public AudioClip[] audioClip2_4;
    public AudioClip[] audioClip2_5;
    public AudioClip[] audioClip2_6;
    public AudioClip[] audioClip2_7;
    public AudioClip[] audioClip2_8;
    public AudioClip[] audioClip2_9;
    public AudioClip[] audioClip2_10;

    [Header("Day Three Audio")]

    public AudioClip[] audioClip3_1;
    public AudioClip[] audioClip3_2;
    public AudioClip[] audioClip3_3;
    public AudioClip[] audioClip3_4;
    public AudioClip[] audioClip3_5;
    public AudioClip[] audioClip3_6;
    public AudioClip[] audioClip3_7;
    public AudioClip[] audioClip3_8;
    public AudioClip[] audioClip3_9;
    public AudioClip[] audioClip3_10;

    [Header("Day Four Audio")]

    public AudioClip[] audioClip4_1;
    public AudioClip[] audioClip4_2;
    public AudioClip[] audioClip4_3;
    public AudioClip[] audioClip4_4;
    public AudioClip[] audioClip4_5;
    public AudioClip[] audioClip4_6;
    public AudioClip[] audioClip4_7;
    public AudioClip[] audioClip4_8;
    public AudioClip[] audioClip4_9;
    public AudioClip[] audioClip4_10;

    public string[] answers1;
    public string[] answers2;

    bool dialogue2Visited;
    bool dialogue4Visited;
    bool dialogue5Visited;
    bool dialogue10Visited;
    bool dialogue8Visited;


    private Queue<string> call2sentences1;
    private Queue<string> call2sentences2;
    private Queue<string> call2sentences3;
    private Queue<string> call2sentences4;
    private Queue<string> call2sentences5;
    private Queue<string> call2sentences6;
    private Queue<string> call2sentences7;
    private Queue<string> call2sentences8;
    private Queue<string> call2sentences9;
    private Queue<string> call2sentences10;

    private Queue<AudioClip> audio2_1;
    private Queue<AudioClip> audio2_2;
    private Queue<AudioClip> audio2_3;
    private Queue<AudioClip> audio2_4;
    private Queue<AudioClip> audio2_5;
    private Queue<AudioClip> audio2_6;
    private Queue<AudioClip> audio2_7;
    private Queue<AudioClip> audio2_8;
    private Queue<AudioClip> audio2_9;
    private Queue<AudioClip> audio2_10;

    private Queue<string> sentences3_1;
    private Queue<string> sentences3_2;
    private Queue<string> sentences3_3;
    private Queue<string> sentences3_4;
    private Queue<string> sentences3_5;
    private Queue<string> sentences3_6;
    private Queue<string> sentences3_7;
    private Queue<string> sentences3_8;
    private Queue<string> sentences3_9;
    private Queue<string> sentences3_10;

    private Queue<AudioClip> audio3_1;
    private Queue<AudioClip> audio3_2;
    private Queue<AudioClip> audio3_3;
    private Queue<AudioClip> audio3_4;
    private Queue<AudioClip> audio3_5;
    private Queue<AudioClip> audio3_6;
    private Queue<AudioClip> audio3_7;
    private Queue<AudioClip> audio3_8;
    private Queue<AudioClip> audio3_9;
    private Queue<AudioClip> audio3_10;

    private Queue<string> sentences4_1;
    private Queue<string> sentences4_2;
    private Queue<string> sentences4_3;
    private Queue<string> sentences4_4;
    private Queue<string> sentences4_5;
    private Queue<string> sentences4_6;
    private Queue<string> sentences4_7;
    private Queue<string> sentences4_8;
    private Queue<string> sentences4_9;
    private Queue<string> sentences4_10;

    private Queue<AudioClip> audio4_1;
    private Queue<AudioClip> audio4_2;
    private Queue<AudioClip> audio4_3;
    private Queue<AudioClip> audio4_4;
    private Queue<AudioClip> audio4_5;
    private Queue<AudioClip> audio4_6;
    private Queue<AudioClip> audio4_7;
    private Queue<AudioClip> audio4_8;
    private Queue<AudioClip> audio4_9;
    private Queue<AudioClip> audio4_10;

    //bool conferenceDialogue2Visited;
    //bool conferenceDialogue4Visited;

    // Use this for initialization
    void Awake ()
    {
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();
        robotDialogueTrigger = FindObjectOfType<RobotDialogueTrigger>();
        dayOneScript = FindObjectOfType<DayOneScript>();
        interactionScript = FindObjectOfType<InteractionScript>();
        statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();

        audioSource = GameObject.FindGameObjectWithTag("ConferenceCall").GetComponent<AudioSource>();

        sentences = new Queue<string>();
        sentences2 = new Queue<string>();
        sentences3 = new Queue<string>();
        sentences4 = new Queue<string>();
        sentences5 = new Queue<string>();
        sentences7 = new Queue<string>();
        sentences9 = new Queue<string>();

        audio1 = new Queue<AudioClip>();
        audio2 = new Queue<AudioClip>();
        audio3 = new Queue<AudioClip>();
        audio4 = new Queue<AudioClip>();
        audio5 = new Queue<AudioClip>();
        audio7 = new Queue<AudioClip>();
        audio9 = new Queue<AudioClip>();

        call2sentences1 = new Queue<string>();
        call2sentences2 = new Queue<string>();
        call2sentences3 = new Queue<string>();
        call2sentences4 = new Queue<string>();
        call2sentences5 = new Queue<string>();
        call2sentences6 = new Queue<string>();
        call2sentences7 = new Queue<string>();
        call2sentences8 = new Queue<string>();
        call2sentences9 = new Queue<string>();
        call2sentences10 = new Queue<string>();

        audio2_1 = new Queue<AudioClip>();
        audio2_2 = new Queue<AudioClip>();
        audio2_3 = new Queue<AudioClip>();
        audio2_4 = new Queue<AudioClip>();
        audio2_5 = new Queue<AudioClip>();
        audio2_6 = new Queue<AudioClip>();
        audio2_7 = new Queue<AudioClip>();
        audio2_8 = new Queue<AudioClip>();
        audio2_9 = new Queue<AudioClip>();
        audio2_10 = new Queue<AudioClip>();

        sentences3_1 = new Queue<string>();
        sentences3_2 = new Queue<string>();
        sentences3_3 = new Queue<string>();
        sentences3_4 = new Queue<string>();
        sentences3_5 = new Queue<string>();
        sentences3_6 = new Queue<string>();
        sentences3_7 = new Queue<string>();
        sentences3_8 = new Queue<string>();
        sentences3_9 = new Queue<string>();
        sentences3_10 = new Queue<string>();

        audio3_1 = new Queue<AudioClip>();
        audio3_2 = new Queue<AudioClip>();
        audio3_3 = new Queue<AudioClip>();
        audio3_4 = new Queue<AudioClip>();
        audio3_5 = new Queue<AudioClip>();
        audio3_6 = new Queue<AudioClip>();
        audio3_7 = new Queue<AudioClip>();
        audio3_8 = new Queue<AudioClip>();
        audio3_9 = new Queue<AudioClip>();
        audio3_10 = new Queue<AudioClip>();

        sentences4_1 = new Queue<string>();
        sentences4_2 = new Queue<string>();
        sentences4_3 = new Queue<string>();
        sentences4_4 = new Queue<string>();
        sentences4_5 = new Queue<string>();
        sentences4_6 = new Queue<string>();
        sentences4_7 = new Queue<string>();
        sentences4_8 = new Queue<string>();
        sentences4_9 = new Queue<string>();
        sentences4_10 = new Queue<string>();

        audio4_1 = new Queue<AudioClip>();
        audio4_2 = new Queue<AudioClip>();
        audio4_3 = new Queue<AudioClip>();
        audio4_4 = new Queue<AudioClip>();
        audio4_5 = new Queue<AudioClip>();
        audio4_6 = new Queue<AudioClip>();
        audio4_7 = new Queue<AudioClip>();
        audio4_8 = new Queue<AudioClip>();
        audio4_9 = new Queue<AudioClip>();
        audio4_10 = new Queue<AudioClip>();

        dialogue2Visited = false;
        dialogue4Visited = false;
        dialogue5Visited = false;
        dialogue10Visited = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(statsScript == null)
        {
            statsScript = GameObject.Find("GameInfoObject").GetComponent<Stats>();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (statsScript.day == 1 || statsScript.day == 4)
        {
            planetText.text = dialogue.planet1;
            
        }
        else if (statsScript.day == 2)
        {
            planetText.text = dialogue.planet2;
        }
        else if (statsScript.day == 3)
        {
            planetText.text = dialogue.planet3;
        }
        continueButton.onClick.AddListener(DisplayNextSentence);

        statsScript.actionsText = statsScript.actionsText + "\n" + "Had conference call with " + planetText.text;

        sentences.Clear();
        audio1.Clear();

        if (statsScript.day == 1)
        {
            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip1)
            {
                audio1.Enqueue(clip);
            }
        }
        else if (statsScript.day == 2)
        {
            foreach (string sentence in dialogue.call2sentences1)
            {
                call2sentences1.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip2_1)
            {
                audio2_1.Enqueue(clip);
            }
        }
        else if (statsScript.day == 3)
        {
            foreach (string sentence in dialogue.sentences3_1)
            {
                sentences3_1.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip3_1)
            {
                audio3_1.Enqueue(clip);
            }
        }
        else if (statsScript.day == 4)
        {
            foreach (string sentence in dialogue.sentences4_1)
            {
                sentences4_1.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip4_1)
            {
                audio4_1.Enqueue(clip);
            }
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (statsScript.day == 1)
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio1.Count > 0)
            {
                AudioClip audio = audio1.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 2)
        {
            if (call2sentences1.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = call2sentences1.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio2_1.Count > 0)
            {
                AudioClip audio = audio2_1.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 3)
        {
            if (sentences3_1.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences3_1.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio3_1.Count > 0)
            {
                AudioClip audio = audio3_1.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 4)
        {
            if (sentences4_1.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences4_1.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio4_1.Count > 0)
            {
                AudioClip audio = audio4_1.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);

        option1.GetComponentInChildren<Text>().text = answers1[0];
        option2.GetComponentInChildren<Text>().text = answers1[1];
        option3.GetComponentInChildren<Text>().text = answers1[2];

        if (statsScript.day == 1)
        {
            option1.onClick.AddListener(dialogueTrigger.TriggerDialogue4);

            if (statsScript.stats[5] >= 40)
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue2);
            }
            else
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue3);
            }

            if (statsScript.stats[5] >= 39)
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue7);
            }
            else
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue9);
            }
        }
        else if (statsScript.day == 2)
        {
            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(dialogueTrigger.TriggerDialogue9);

            option2.onClick.RemoveAllListeners();
            if (statsScript.stats[6] >= 34)
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue2);
            }
            else
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue3);
            }

            option3.onClick.RemoveAllListeners();
            if (statsScript.stats[6] >= 34)
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue6);
            }
            else
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue10);
            }
        }
        else if (statsScript.day == 3)
        {
            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(dialogueTrigger.TriggerDialogue9);

            option2.onClick.RemoveAllListeners();
            if (statsScript.stats[7] >= 40)
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue2);
            }
            else
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue3);
            }

            option3.onClick.RemoveAllListeners();
            if (statsScript.stats[7] >= 34)
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue6);
            }
            else
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue10);
            }
        }
        else if (statsScript.day == 4)
        {
            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(dialogueTrigger.TriggerDialogue9);

            option2.onClick.RemoveAllListeners();
            if (statsScript.stats[5] >= 40)
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue2);
            }
            else
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue3);
            }

            option3.onClick.RemoveAllListeners();
            if (statsScript.stats[5] >= 34)
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue6);
            }
            else
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue10);
            }
        }
    }

    public void StartDialogue2(Dialogue dialogue)
    {
        if (statsScript.day == 1 || statsScript.day == 4)
        {
            statsScript.stats[5] -= 5;
        }
        else if (statsScript.day == 2)
        {
            statsScript.stats[6] -= 5;
        }
        else if (statsScript.day == 3)
        {
            statsScript.stats[7] -= 5;
        }

        statsScript.conferenceAcceptWithHaggle = true;
        dialogue2Visited = true;
        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(DisplayNextSentence2);

        sentences2.Clear();
        call2sentences2.Clear();
        audio2.Clear();

        if (statsScript.day == 1)
        {
            foreach (string sentence2 in dialogue.sentences2)
            {
                sentences2.Enqueue(sentence2);
            }

            foreach (AudioClip clip in audioClip2)
            {
                audio2.Enqueue(clip);
            }
        }
        else if (statsScript.day == 2)
        {
            foreach (string sentence in dialogue.call2sentences2)
            {
                call2sentences2.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip2_2)
            {
                audio2_2.Enqueue(clip);
            }
        }
        else if (statsScript.day == 3)
        {
            foreach (string sentence in dialogue.sentences3_2)
            {
                sentences3_2.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip3_2)
            {
                audio3_2.Enqueue(clip);
            }
        }
        else if (statsScript.day == 4)
        {
            foreach (string sentence in dialogue.sentences4_2)
            {
                sentences4_2.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip4_2)
            {
                audio4_2.Enqueue(clip);
            }
        }

        DisplayNextSentence2();
    }

    public void DisplayNextSentence2()
    {
        if (statsScript.day == 1)
        {
            if (sentences2.Count == 0)
            {
                EndDialogue2();
                return;
            }

            string sentence2 = sentences2.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence2));

            audioSource.Stop();

            if (audio2.Count > 0)
            {
                AudioClip audio = audio2.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 2)
        {
            if (call2sentences2.Count == 0)
            {
                EndDialogue2();
                return;
            }

            string sentence = call2sentences2.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio2_2.Count > 0)
            {
                AudioClip audio = audio2_2.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 3)
        {
            if (sentences3_2.Count == 0)
            {
                EndDialogue2();
                return;
            }

            string sentence = sentences3_2.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio3_2.Count > 0)
            {
                AudioClip audio = audio3_2.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 4)
        {
            if (sentences4_2.Count == 0)
            {
                EndDialogue2();
                return;
            }

            string sentence = sentences4_2.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio4_2.Count > 0)
            {
                AudioClip audio = audio4_2.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
    }

    public void EndDialogue2()
    {
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);

        option1.GetComponentInChildren<Text>().text = answers2[0];
        option2.GetComponentInChildren<Text>().text = answers2[1];
        option3.GetComponentInChildren<Text>().text = answers2[2];

        if (statsScript.day == 1)
        {
            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(dialogueTrigger.TriggerDialogue4);

            option2.onClick.RemoveAllListeners();

            if (statsScript.stats[5] >= 40)
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue5);
            }
            else
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue3);
            }

            option3.onClick.RemoveAllListeners();

            if (statsScript.stats[5] >= 40)
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue7);
            }
            else
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue9);
            }
        }
        else if (statsScript.day == 2)
        {
            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(dialogueTrigger.TriggerDialogue9);

            option2.onClick.RemoveAllListeners();
            if (statsScript.stats[6] >= 34)
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue4);
            }
            else
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue5);
            }

            option3.onClick.RemoveAllListeners();
            if (statsScript.stats[6] >= 34)
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue7);
            }
            else
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue10);
            }
        }
        else if (statsScript.day == 3)
        {
            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(dialogueTrigger.TriggerDialogue9);

            option2.onClick.RemoveAllListeners();
            if (statsScript.stats[7] >= 34)
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue4);
            }
            else
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue5);
            }

            option3.onClick.RemoveAllListeners();
            if (statsScript.stats[7] >= 34)
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue7);
            }
            else
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue10);
            }
        }
        else if (statsScript.day == 4)
        {
            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(dialogueTrigger.TriggerDialogue9);

            option2.onClick.RemoveAllListeners();
            if (statsScript.stats[5] >= 34)
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue4);
            }
            else
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue5);
            }

            option3.onClick.RemoveAllListeners();
            if (statsScript.stats[5] >= 34)
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue7);
            }
            else
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue10);
            }
        }
    }

    public void StartDialogue3(Dialogue dialogue)
    {
        if (statsScript.day == 1)
        {
            statsScript.stats[5] -= 5;
            dialogue2Visited = true;
        }
        else if (statsScript.day == 2)
        {
            statsScript.stats[6] -= 5;
        }
        else if (statsScript.day == 3)
        {
            statsScript.stats[7] -= 5;
        }
        else if (statsScript.day == 4)
        {
            statsScript.stats[5] -= 5;
        }

        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(DisplayNextSentence3);

        sentences3.Clear();
        call2sentences3.Clear();
        audio3.Clear();

        if (statsScript.day == 1)
        {
            foreach (string sentence3 in dialogue.sentences3)
            {
                sentences3.Enqueue(sentence3);
            }

            foreach (AudioClip clip in audioClip3)
            {
                audio3.Enqueue(clip);
            }
        }
        else if (statsScript.day == 2)
        {
            foreach (string sentence in dialogue.call2sentences3)
            {
                call2sentences3.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip2_3)
            {
                audio2_3.Enqueue(clip);
            }
        }
        else if (statsScript.day == 3)
        {
            foreach (string sentence in dialogue.sentences3_3)
            {
                sentences3_3.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip3_3)
            {
                audio3_3.Enqueue(clip);
            }
        }
        else if (statsScript.day == 4)
        {
            foreach (string sentence in dialogue.sentences4_3)
            {
                sentences4_3.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip4_3)
            {
                audio4_3.Enqueue(clip);
            }
        }

        DisplayNextSentence3();
    }

    public void DisplayNextSentence3()
    {
        if (statsScript.day == 1)
        {
            if (sentences3.Count == 0)
            {
                EndDialogue3();
                return;
            }

            string sentence3 = sentences3.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence3));

            audioSource.Stop();

            if (audio3.Count > 0)
            {
                AudioClip audio = audio3.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 2)
        {
            if (call2sentences3.Count == 0)
            {
                EndDialogue3();
                return;
            }

            string sentence = call2sentences3.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio2_3.Count > 0)
            {
                AudioClip audio = audio2_3.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 3)
        {
            if (sentences3_3.Count == 0)
            {
                EndDialogue3();
                return;
            }

            string sentence = sentences3_3.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio3_3.Count > 0)
            {
                AudioClip audio = audio3_3.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 4)
        {
            if (sentences4_3.Count == 0)
            {
                EndDialogue3();
                return;
            }

            string sentence = sentences4_3.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio4_3.Count > 0)
            {
                AudioClip audio = audio4_3.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
    }

    public void EndDialogue3()
    {
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);
        option1.GetComponentInChildren<Text>().text = answers1[0];
        option2.gameObject.SetActive(false);
        option3.GetComponentInChildren<Text>().text = answers1[2];

        if (statsScript.day == 1)
        {
            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(dialogueTrigger.TriggerDialogue4);

            option3.onClick.RemoveAllListeners();
            option3.onClick.AddListener(dialogueTrigger.TriggerDialogue9);
        }
        else if (statsScript.day == 2 || statsScript.day == 3 || statsScript.day == 4)
        {
            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(dialogueTrigger.TriggerDialogue9);

            option3.onClick.RemoveAllListeners();
            option3.onClick.AddListener(dialogueTrigger.TriggerDialogue10);
        }
    }

    public void StartDialogue4(Dialogue dialogue)
    {
        if (statsScript.day == 1)
        {
            if (dialogue2Visited)
            {
                statsScript.stats[5] += 15;
                statsScript.stats[0] -= 10;
                statsScript.stats[4] -= 5;
                statsScript.stats[2] -= 5;
            }
            else if (dialogue10Visited)
            {
                statsScript.stats[5] += 15;
                statsScript.stats[0] -= 10;
                statsScript.stats[4] -= 10;
                statsScript.stats[1] += 0.2f;
                statsScript.stats[2] += 5;
            }
            else if (dialogue5Visited)
            {
                statsScript.stats[5] += 15;
                statsScript.stats[0] -= 10;
                statsScript.stats[4] -= 10;
                statsScript.stats[1] += 0.2f;
                statsScript.stats[2] += 5;
            }
            else
            {
                statsScript.stats[5] += 15;
                statsScript.stats[0] -= 10;
                statsScript.stats[4] -= 5;
                statsScript.stats[1] += 2;
                statsScript.stats[2] -= 5;
            }
        }
        else if (statsScript.day == 2)
        {
            statsScript.stats[6] -= 5;
        }
        else if (statsScript.day == 3)
        {
            statsScript.stats[7] -= 5;
        }
        else if (statsScript.day == 4)
        {
            statsScript.stats[5] -= 5;
        }

        dialogue4Visited = true;
        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(DisplayNextSentence4);

        sentences4.Clear();
        call2sentences4.Clear();
        audio4.Clear();

        if (statsScript.day == 1)
        {
            foreach (string sentence4 in dialogue.sentences4)
            {
                sentences4.Enqueue(sentence4);
            }

            foreach (AudioClip clip in audioClip4)
            {
                audio4.Enqueue(clip);
            }
        }
        else if (statsScript.day == 2)
        {
            foreach (string sentence in dialogue.call2sentences4)
            {
                call2sentences4.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip2_4)
            {
                audio2_4.Enqueue(clip);
            }
        }
        else if (statsScript.day == 3)
        {
            foreach (string sentence in dialogue.sentences3_4)
            {
                sentences3_4.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip3_4)
            {
                audio3_4.Enqueue(clip);
            }
        }
        else if (statsScript.day == 4)
        {
            foreach (string sentence in dialogue.sentences4_4)
            {
                sentences4_4.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip4_4)
            {
                audio4_4.Enqueue(clip);
            }
        }

        DisplayNextSentence4();
    }

    public void DisplayNextSentence4()
    {
        if (statsScript.day == 1)
        {
            if (sentences4.Count == 0)
            {
                EndDialogue4();
                return;
            }

            string sentence4 = sentences4.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence4));

            audioSource.Stop();

            if (audio4.Count > 0)
            {
                AudioClip audio = audio4.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 2)
        {
            if (call2sentences4.Count == 0)
            {
                EndDialogue4();
                return;
            }

            string sentence = call2sentences4.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio2_4.Count > 0)
            {
                AudioClip audio = audio2_4.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 3)
        {
            if (sentences3_4.Count == 0)
            {
                EndDialogue4();
                return;
            }

            string sentence = sentences3_4.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio3_4.Count > 0)
            {
                AudioClip audio = audio3_4.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 4)
        {
            if (sentences4_4.Count == 0)
            {
                EndDialogue4();
                return;
            }

            string sentence = sentences4_4.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio4_4.Count > 0)
            {
                AudioClip audio = audio4_4.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
    }

    public void EndDialogue4()
    {
        if (statsScript.day == 1)
        {
            conferenceCall.SetActive(false);
            player.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            robotDialogueTrigger.TriggerRobotDialogue14();
            statsScript.conferenceAccept = true;
            statsScript.connferenceCallAccept.Add("Earth Moonpath");
        }
        else
        {
            speakerPanel.SetActive(false);
            answerPanel.SetActive(true);

            option1.GetComponentInChildren<Text>().text = answers1[0];
            option2.gameObject.SetActive(false);
            option3.GetComponentInChildren<Text>().text = answers1[2];

            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(dialogueTrigger.TriggerDialogue9);

            option3.onClick.RemoveAllListeners();
            if (statsScript.day == 2)
            {
                if (statsScript.stats[6] >= 34)
                {
                    option3.onClick.AddListener(dialogueTrigger.TriggerDialogue8);
                }
                else
                {
                    option3.onClick.AddListener(dialogueTrigger.TriggerDialogue10);
                }
            }
            else if (statsScript.day == 3)
            {
                if (statsScript.stats[7] >= 34)
                {
                    option3.onClick.AddListener(dialogueTrigger.TriggerDialogue8);
                }
                else
                {
                    option3.onClick.AddListener(dialogueTrigger.TriggerDialogue10);
                }
            }
            else if (statsScript.day == 4)
            {
                if (statsScript.stats[5] >= 34)
                {
                    option3.onClick.AddListener(dialogueTrigger.TriggerDialogue8);
                }
                else
                {
                    option3.onClick.AddListener(dialogueTrigger.TriggerDialogue10);
                }
            }
        }
    }

    public void StartDialogue5(Dialogue dialogue)
    {
        if (statsScript.day == 1)
        {
            statsScript.stats[5] -= 5;
        }
        else if (statsScript.day == 2)
        {
            statsScript.stats[6] -= 5;
        }
        else if (statsScript.day == 3)
        {
            statsScript.stats[7] -= 5;
        }
        else if (statsScript.day == 4)
        {
            statsScript.stats[5] -= 5;
        }

        dialogue5Visited = true;
        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(DisplayNextSentence5);

        sentences5.Clear();
        call2sentences5.Clear();
        audio5.Clear();

        if (statsScript.day == 1)
        {
            foreach (string sentence5 in dialogue.sentences5)
            {
                sentences5.Enqueue(sentence5);
            }

            foreach (AudioClip clip in audioClip5)
            {
                audio5.Enqueue(clip);
            }
        }
        else if (statsScript.day == 2)
        {
            foreach (string sentence in dialogue.call2sentences5)
            {
                call2sentences5.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip2_5)
            {
                audio2_5.Enqueue(clip);
            }
        }
        else if (statsScript.day == 3)
        {
            foreach (string sentence in dialogue.sentences3_5)
            {
                sentences3_5.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip3_5)
            {
                audio3_5.Enqueue(clip);
            }
        }
        else if (statsScript.day == 4)
        {
            foreach (string sentence in dialogue.sentences4_5)
            {
                sentences4_5.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip4_5)
            {
                audio4_5.Enqueue(clip);
            }
        }

        DisplayNextSentence5();
    }

    public void DisplayNextSentence5()
    {
        if (statsScript.day == 1)
        {
            if (sentences5.Count == 0)
            {
                EndDialogue5();
                return;
            }

            string sentence5 = sentences5.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence5));

            audioSource.Stop();

            if (audio5.Count > 0)
            {
                AudioClip audio = audio5.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 2)
        {
            if (call2sentences5.Count == 0)
            {
                EndDialogue5();
                return;
            }

            string sentence = call2sentences5.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio2_5.Count > 0)
            {
                AudioClip audio = audio2_5.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 3)
        {
            if (sentences3_5.Count == 0)
            {
                EndDialogue5();
                return;
            }

            string sentence = sentences3_5.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio3_5.Count > 0)
            {
                AudioClip audio = audio3_5.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 4)
        {
            if (sentences4_5.Count == 0)
            {
                EndDialogue5();
                return;
            }

            string sentence = sentences4_5.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio4_5.Count > 0)
            {
                AudioClip audio = audio4_5.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
    }

    public void EndDialogue5()
    {
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);
        option1.GetComponentInChildren<Text>().text = answers1[0];
        option2.gameObject.SetActive(false);
        option3.GetComponentInChildren<Text>().text = answers1[2];

        if (statsScript.day == 1)
        {
            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(dialogueTrigger.TriggerDialogue4);

            option3.onClick.RemoveAllListeners();

            if (statsScript.stats[5] >= 40)
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue7);
                dialogue10Visited = true;
            }
            else
            {
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue9);
            }
        }
        else
        {
            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(dialogueTrigger.TriggerDialogue9);

            option3.onClick.RemoveAllListeners();
            option3.onClick.AddListener(dialogueTrigger.TriggerDialogue10);
        }
    }

    public void StartDialogue6(Dialogue dialogue)
    {
        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);

        if (statsScript.day == 2)
        {
            statsScript.stats[6] -= 5;
        }
        else if (statsScript.day == 3)
        {
            statsScript.stats[7] -= 5;
        }
        else if (statsScript.day == 4)
        {
            statsScript.stats[5] -= 5;
        }

        continueButton.onClick.AddListener(DisplayNextSentence6);

        call2sentences6.Clear();

        if (statsScript.day == 2)
        {
            foreach (string sentence in dialogue.call2sentences6)
            {
                call2sentences6.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip2_6)
            {
                audio2_6.Enqueue(clip);
            }
        }
        else if (statsScript.day == 3)
        {
            foreach (string sentence in dialogue.sentences3_6)
            {
                sentences3_6.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip3_6)
            {
                audio3_6.Enqueue(clip);
            }
        }
        else if (statsScript.day == 4)
        {
            foreach (string sentence in dialogue.sentences4_6)
            {
                sentences4_6.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip4_6)
            {
                audio4_6.Enqueue(clip);
            }
        }

        DisplayNextSentence6();
    }

    public void DisplayNextSentence6()
    {
        if (statsScript.day == 2)
        {
            if (call2sentences6.Count == 0)
            {
                EndDialogue6();
                return;
            }

            string sentence2_6 = call2sentences6.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence2_6));

            audioSource.Stop();

            if (audio2_6.Count > 0)
            {
                AudioClip audio = audio2_6.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 3)
        {
            if (sentences3_6.Count == 0)
            {
                EndDialogue6();
                return;
            }

            string sentence = sentences3_6.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio3_6.Count > 0)
            {
                AudioClip audio = audio3_6.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 4)
        {
            if (sentences4_6.Count == 0)
            {
                EndDialogue6();
                return;
            }

            string sentence = sentences4_6.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio4_6.Count > 0)
            {
                AudioClip audio = audio4_6.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
    }

    public void EndDialogue6()
    {
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);

        option1.GetComponentInChildren<Text>().text = answers1[0];
        option2.GetComponentInChildren<Text>().text = answers1[1];
        option3.GetComponentInChildren<Text>().text = answers1[2];

        option1.onClick.RemoveAllListeners();
        option1.onClick.AddListener(dialogueTrigger.TriggerDialogue9);

        option3.onClick.RemoveAllListeners();
        option3.onClick.AddListener(dialogueTrigger.TriggerDialogue10);

        if (statsScript.day == 2)
        {         
            option2.onClick.RemoveAllListeners();
            if (statsScript.stats[6] >= 34)
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue2);
            }
            else
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue3);
            }
        }
        else if (statsScript.day == 3)
        {
            option2.onClick.RemoveAllListeners();
            if (statsScript.stats[7] >= 40)
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue2);
            }
            else
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue3);
            }
        }
        else if (statsScript.day == 4)
        {
            option2.onClick.RemoveAllListeners();
            if (statsScript.stats[5] >= 40)
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue2);
            }
            else
            {
                option2.onClick.AddListener(dialogueTrigger.TriggerDialogue3);
            }
        }
    }

    public void StartDialogue7(Dialogue dialogue)
    {
        if (statsScript.day == 1)
        {
            statsScript.stats[5] -= 10;
        }
        else if (statsScript.day == 2)
        {
            statsScript.stats[6] -= 5;
        }
        else if (statsScript.day == 3)
        {
            statsScript.stats[7] -= 5;
        }
        else if (statsScript.day == 4)
        {
            statsScript.stats[5] -= 5;
        }

        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(DisplayNextSentence7);

        sentences7.Clear();
        call2sentences7.Clear();
        audio7.Clear();

        if (statsScript.day == 1)
        {
            foreach (string sentence7 in dialogue.sentences7)
            {
                sentences7.Enqueue(sentence7);
            }

            foreach (AudioClip clip in audioClip7)
            {
                audio7.Enqueue(clip);
            }
        }
        else if (statsScript.day == 2)
        {
            foreach (string sentence in dialogue.call2sentences7)
            {
                call2sentences7.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip2_7)
            {
                audio2_7.Enqueue(clip);
            }
        }
        else if (statsScript.day == 3)
        {
            foreach (string sentence in dialogue.sentences3_7)
            {
                sentences3_7.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip3_7)
            {
                audio3_7.Enqueue(clip);
            }
        }
        else if (statsScript.day == 4)
        {
            foreach (string sentence in dialogue.sentences4_7)
            {
                sentences4_7.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip4_7)
            {
                audio4_7.Enqueue(clip);
            }
        }

        DisplayNextSentence7();
    }

    public void DisplayNextSentence7()
    {
        if (statsScript.day == 1)
        {
            if (sentences7.Count == 0)
            {
                EndDialogue7();
                return;
            }

            string sentence7 = sentences7.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence7));

            audioSource.Stop();

            if (audio7.Count > 0)
            {
                AudioClip audio = audio7.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 2)
        {
            if (call2sentences7.Count == 0)
            {
                EndDialogue7();
                return;
            }

            string sentence = call2sentences7.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio2_7.Count > 0)
            {
                AudioClip audio = audio2_7.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 3)
        {
            if (sentences3_7.Count == 0)
            {
                EndDialogue7();
                return;
            }

            string sentence = sentences3_7.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio3_7.Count > 0)
            {
                AudioClip audio = audio3_7.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 4)
        {
            if (sentences4_7.Count == 0)
            {
                EndDialogue7();
                return;
            }

            string sentence = sentences4_7.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio4_7.Count > 0)
            {
                AudioClip audio = audio4_7.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
    }

    public void EndDialogue7()
    {
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);

        if (statsScript.day == 1)
        {
            if (dialogue5Visited)
            {
                option1.GetComponentInChildren<Text>().text = answers1[0];
                option2.GetComponentInChildren<Text>().text = answers1[1];
                option3.GetComponentInChildren<Text>().text = answers1[2];

                option1.onClick.RemoveAllListeners();
                option1.onClick.AddListener(dialogueTrigger.TriggerDialogue4);

                if (statsScript.stats[5] > 35)
                {
                    option2.onClick.AddListener(dialogueTrigger.TriggerDialogue2);
                }
                else
                {
                    option2.onClick.AddListener(dialogueTrigger.TriggerDialogue3);
                }

                option3.onClick.RemoveAllListeners();
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue9);
            }
            else if (dialogue10Visited)
            {
                option1.GetComponentInChildren<Text>().text = answers1[0];
                option2.gameObject.SetActive(false);
                option3.GetComponentInChildren<Text>().text = answers1[2];

                option1.onClick.RemoveAllListeners();
                option1.onClick.AddListener(dialogueTrigger.TriggerDialogue4);

                option3.onClick.RemoveAllListeners();
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue9);
            }
            else
            {
                option1.GetComponentInChildren<Text>().text = answers1[0];
                option2.GetComponentInChildren<Text>().text = answers1[1];
                option3.GetComponentInChildren<Text>().text = answers1[2];

                option1.onClick.RemoveAllListeners();
                option1.onClick.AddListener(dialogueTrigger.TriggerDialogue4);

                option2.onClick.RemoveAllListeners();
                if (statsScript.stats[5] > 40)
                {
                    option2.onClick.AddListener(dialogueTrigger.TriggerDialogue5);
                }
                else
                {
                    option2.onClick.AddListener(dialogueTrigger.TriggerDialogue3);
                }

                option3.onClick.RemoveAllListeners();
                option3.onClick.AddListener(dialogueTrigger.TriggerDialogue9);
            }
        }
        else
        {
            option1.GetComponentInChildren<Text>().text = answers2[0];
            option2.GetComponentInChildren<Text>().text = answers2[1];
            option3.GetComponentInChildren<Text>().text = answers2[2];

            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(dialogueTrigger.TriggerDialogue9);

            option3.onClick.RemoveAllListeners();
            option3.onClick.AddListener(dialogueTrigger.TriggerDialogue10);

            option2.onClick.RemoveAllListeners();
            if (statsScript.day == 2)
            {
                if (statsScript.stats[6] >= 30)
                {
                    option2.onClick.AddListener(dialogueTrigger.TriggerDialogue4);
                }
                else if (statsScript.stats[6] < 30)
                {
                    option2.onClick.AddListener(dialogueTrigger.TriggerDialogue5);
                }
            }
            else if (statsScript.day == 3)
            {
                if (statsScript.stats[7] >= 35)
                {
                    option2.onClick.AddListener(dialogueTrigger.TriggerDialogue4);
                }
                else
                {
                    option2.onClick.AddListener(dialogueTrigger.TriggerDialogue5);
                }
            }
            else if (statsScript.day == 4)
            {
                if (statsScript.stats[5] >= 35)
                {
                    option2.onClick.AddListener(dialogueTrigger.TriggerDialogue4);
                }
                else
                {
                    option2.onClick.AddListener(dialogueTrigger.TriggerDialogue5);
                }
            }
        }
    }

    public void StartDialogue8(Dialogue dialogue)
    {
        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);

        if (statsScript.day == 2)
        {
            statsScript.stats[6] -= 5;
        }
        else if (statsScript.day == 3)
        {
            statsScript.stats[7] -= 5;
        }
        else if (statsScript.day == 4)
        {
            statsScript.stats[5] -= 10;
        }

        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(DisplayNextSentence8);

        call2sentences8.Clear();

        if (statsScript.day == 2)
        {
            foreach (string sentence2_8 in dialogue.call2sentences8)
            {
                call2sentences8.Enqueue(sentence2_8);
            }

            foreach (AudioClip clip in audio2_8)
            {
                audio2_8.Enqueue(clip);
            }
        }
        else if (statsScript.day == 3)
        {
            foreach (string sentence in dialogue.sentences3_8)
            {
                sentences3_8.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip3_8)
            {
                audio3_8.Enqueue(clip);
            }
        }
        else if (statsScript.day == 4)
        {
            foreach (string sentence in dialogue.sentences4_8)
            {
                sentences4_8.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip4_8)
            {
                audio4_8.Enqueue(clip);
            }
        }

        DisplayNextSentence8();
    }

    public void DisplayNextSentence8()
    {
        if (statsScript.day == 2)
        {
            if (call2sentences8.Count == 0)
            {
                EndDialogue8();
                return;
            }

            string sentence2_8 = call2sentences8.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence2_8));

            audioSource.Stop();

            if (audio2_8.Count > 0)
            {
                AudioClip audio = audio2_8.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 3)
        {
            if (sentences3_8.Count == 0)
            {
                EndDialogue8();
                return;
            }

            string sentence = sentences3_8.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio3_8.Count > 0)
            {
                AudioClip audio = audio3_8.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 4)
        {
            if (sentences4_8.Count == 0)
            {
                EndDialogue8();
                return;
            }

            string sentence = sentences4_8.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio4_8.Count > 0)
            {
                AudioClip audio = audio4_8.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
    }

    public void EndDialogue8()
    {
        speakerPanel.SetActive(false);
        answerPanel.SetActive(true);

        option1.GetComponentInChildren<Text>().text = answers1[0];
        option2.gameObject.SetActive(false);
        option3.GetComponentInChildren<Text>().text = answers1[2];

        option1.onClick.RemoveAllListeners();
        option1.onClick.AddListener(dialogueTrigger.TriggerDialogue9);

        option3.onClick.RemoveAllListeners();
        option3.onClick.AddListener(dialogueTrigger.TriggerDialogue10);
    }

    public void StartDialogue9(Dialogue dialogue)
    {
        if (statsScript.day == 1)
        {
            if (dialogue5Visited)
            {
                statsScript.stats[5] -= 10;
                statsScript.stats[0] += 10;
                statsScript.stats[4] += 5;
                statsScript.stats[2] += 5;
            }
            else
            {
                statsScript.stats[5] -= 10;
                statsScript.stats[0] += 10;
                statsScript.stats[4] += 5;
                statsScript.stats[2] += 5;
            }
        }

        else if (statsScript.day == 2)
        {
            statsScript.stats[4] += 10;

            if (dialogue2Visited && dialogue4Visited)
            {
                statsScript.stats[1] += 0.5f;
                statsScript.stats[6] += 15;
            }
            else if (dialogue2Visited)
            {
                statsScript.stats[1] += 0.5f;
                statsScript.stats[6] += 15;
                statsScript.stats[2] -= 5;
            }
            else
            {
                statsScript.stats[1] += 0.3f;
                statsScript.stats[6] += 15;
                statsScript.stats[0] -= 5;
                statsScript.stats[2] -= 10;
            }
        }
        else if (statsScript.day == 3)
        {
            statsScript.stats[5] -= 10;

            if (dialogue2Visited && dialogue4Visited)
            {
                statsScript.stats[7] += 15;
                statsScript.stats[2] += 15;
                statsScript.stats[1] += 0.3f;
                statsScript.stats[6] -= 10;
                statsScript.stats[4] += 5;
            }
            else if (dialogue2Visited)
            {
                statsScript.stats[7] += 15;
                statsScript.stats[2] += 10;
                statsScript.stats[1] += 0.3f;
                statsScript.stats[6] -= 10;
                statsScript.stats[4] += 10;
            }
            else
            {
                statsScript.stats[7] += 15;
                statsScript.stats[2] += 10;
                statsScript.stats[6] -= 10;
                statsScript.stats[4] += 10;
            }
        }
        else if (statsScript.day == 3)
        {
            if (dialogue2Visited && dialogue4Visited)
            {
                statsScript.stats[5] += 10;
                statsScript.stats[2] -= 5;
                statsScript.stats[1] -= 1.25f;
                statsScript.stats[4] -= 15;
            }
            else if (dialogue2Visited)
            {
                statsScript.stats[5] += 15;
                statsScript.stats[2] -= 10;
                statsScript.stats[1] += 1.5f;
                statsScript.stats[4] -= 10;
            }
            else
            {
                statsScript.stats[5] += 15;
                statsScript.stats[2] -= 10;
                statsScript.stats[1] -= 2f;
                statsScript.stats[4] -= 10;
            }
        }

        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(DisplayNextSentence9);

        sentences9.Clear();
        call2sentences9.Clear();
        audio9.Clear();

        if (statsScript.day == 1)
        {
            foreach (string sentence9 in dialogue.sentences9)
            {
                sentences9.Enqueue(sentence9);
            }

            foreach (AudioClip clip in audioClip9)
            {
                audio9.Enqueue(clip);
            }
        }
        else if (statsScript.day == 2)
        {
            foreach (string sentence in dialogue.call2sentences9)
            {
                call2sentences9.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip2_9)
            {
                audio2_9.Enqueue(clip);
            }
        }
        else if (statsScript.day == 3)
        {
            foreach (string sentence in dialogue.sentences3_9)
            {
                sentences3_9.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip3_9)
            {
                audio3_9.Enqueue(clip);
            }
        }
        else if (statsScript.day == 4)
        {
            foreach (string sentence in dialogue.sentences4_9)
            {
                sentences4_9.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip4_9)
            {
                audio4_9.Enqueue(clip);
            }
        }

        DisplayNextSentence9();
    }

    public void DisplayNextSentence9()
    {
        if (statsScript.day == 1)
        {
            if (sentences9.Count == 0)
            {
                EndDialogue9();
                return;
            }

            string sentence9 = sentences9.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence9));

            audioSource.Stop();

            if (audio9.Count > 0)
            {
                AudioClip audio = audio9.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 2)
        {
            if (call2sentences9.Count == 0)
            {
                EndDialogue9();
                return;
            }

            string sentence = call2sentences9.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio2_9.Count > 0)
            {
                AudioClip audio = audio2_9.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 3)
        {
            if (sentences3_9.Count == 0)
            {
                EndDialogue9();
                return;
            }

            string sentence = sentences3_9.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio3_9.Count > 0)
            {
                AudioClip audio = audio3_9.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 4)
        {
            if (sentences4_9.Count == 0)
            {
                EndDialogue9();
                return;
            }

            string sentence = sentences4_9.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio4_9.Count > 0)
            {
                AudioClip audio = audio4_9.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
    }

    public void EndDialogue9()
    {
        conferenceCall.SetActive(false);
        player.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (statsScript.day == 1)
        {
            dayOneScript.conferenceCallInteractable = false;
            //dayOneScript.femaleHologram.SetActive(false);
            robotDialogueTrigger.TriggerRobotDialogue14();
            statsScript.conferenceAccept = false;
            statsScript.connferenceCallDecline.Add("Earth Moonpath");
        }
        else if (statsScript.day == 2)
        {
            statsScript.conferenceAccept = true;
            statsScript.connferenceCallAccept.Add("Mars Moon Metals");
            interactionScript.conferenceCallInteractable = false;
            //interactionScript.femaleHologram.SetActive(false);
            robotDialogueTrigger.TriggerRobotDialogue2_15();
        }
        else if (statsScript.day == 3)
        {
            statsScript.conferenceAccept = true;
            statsScript.connferenceCallAccept.Add("Venus Gun Trade");
            interactionScript.conferenceCallInteractable = false;
            //interactionScript.femaleHologram.SetActive(false);
            statsScript.time--;
        }
        else if (statsScript.day == 4)
        {
            statsScript.conferenceAccept = true;
            statsScript.connferenceCallAccept.Add("Earth Moon Bill");
            //interactionScript.conferenceCallInteractable = false;
            interactionScript.femaleHologram.SetActive(false);
            statsScript.time--;
        }
    }

    public void StartDialogue10(Dialogue dialogue)
    {
        speakerPanel.SetActive(true);
        answerPanel.SetActive(false);

        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(DisplayNextConferenceSentence10);

        if (statsScript.day == 2)
        {
            statsScript.stats[6] -= 15;
            statsScript.stats[0] += 10;
            statsScript.stats[2] += 10;

            call2sentences10.Clear();

            foreach (string sentence2_10 in dialogue.call2sentences10)
            {
                call2sentences10.Enqueue(sentence2_10);
            }

            foreach(AudioClip clip in audioClip2_10)
            {
                audio2_10.Enqueue(clip);
            }
        }
        else if (statsScript.day == 3)
        {
            statsScript.stats[5] += 5;
            statsScript.stats[6] += 5;
            statsScript.stats[7] -= 10;
            statsScript.stats[2] -= 5;

            sentences3_10.Clear();

            foreach (string sentence in dialogue.sentences3_10)
            {
                sentences3_10.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip3_10)
            {
                audio3_10.Enqueue(clip);
            }
        }
        else if (statsScript.day == 4)
        {
            statsScript.stats[2] += 10;
            statsScript.stats[5] -= 10;

            sentences4_10.Clear();

            foreach (string sentence in dialogue.sentences4_10)
            {
                sentences4_10.Enqueue(sentence);
            }

            foreach (AudioClip clip in audioClip4_10)
            {
                audio4_10.Enqueue(clip);
            }
        }

        DisplayNextConferenceSentence10();
    }

    public void DisplayNextConferenceSentence10()
    {
        if (statsScript.day == 2)
        {
            if (call2sentences10.Count == 0)
            {
                EndConferenceDialogue10();
                return;
            }

            string sentence2_10 = call2sentences10.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence2_10));

            audioSource.Stop();

            if (audio2_10.Count > 0)
            {
                AudioClip audio = audio2_10.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 3)
        {
            if (sentences3_10.Count == 0)
            {
                EndConferenceDialogue10();
                return;
            }

            string sentence = sentences3_10.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio3_10.Count > 0)
            {
                AudioClip audio = audio3_10.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
        else if (statsScript.day == 4)
        {
            if (sentences4_10.Count == 0)
            {
                EndConferenceDialogue10();
                return;
            }

            string sentence = sentences4_10.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (audio4_10.Count > 0)
            {
                AudioClip audio = audio4_10.Dequeue();
                audioSource.clip = audio;
                audioSource.PlayOneShot(audio);
            }
        }
    }

    public void EndConferenceDialogue10()
    {
        statsScript.conferenceAccept = false;
        conferenceCall.SetActive(false);
        //interactionScript.femaleHologram.SetActive(false);
        player.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        interactionScript.conferenceCallInteractable = false;
        if (statsScript.day == 2)
        {
            statsScript.connferenceCallDecline.Add("Mars Moon Metals");
            robotDialogueTrigger.TriggerRobotDialogue2_15();
        }
        else if (statsScript.day == 3)
        {
            statsScript.connferenceCallDecline.Add("Venus Gun Trade");
            statsScript.time--;
        }
        else if (statsScript.day == 4)
        {
            statsScript.connferenceCallDecline.Add("Earth Moon Bill");
            statsScript.time--;
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyChoices : MonoBehaviour {

    public GameObject es, ms, vs, gio, ec, mc, vc;

    public string planetType = "";
    public string movementChoice = "";

    InteractionScript ints;

    void Start()
    {

    }

    public void UpdatePolicies()
    {
        ints = FindObjectOfType<InteractionScript>();

        gio = GameObject.Find("GameInfoObject DDL");
        es = GameObject.Find("Earth Folder DDL");
        ms = GameObject.Find("Mars Folder DDL");
        vs = GameObject.Find("Venus Folder DDL");

        GameObject.Find("Earth Folder Canvas DDL").name = "Earth Folder Canvas";
        GameObject.Find("Mars Folder Canvas DDL").name = "Mars Folder Canvas";
        GameObject.Find("Venus Folder Canvas DDL").name = "Venus Folder Canvas";

        gio.name = "GameInfoObject";
        es.name = "EarthFolder";
        ms.name = "MarsFolder";
        vs.name = "VenusFolder";
    }

}

﻿using UnityEngine;
using System.Collections;

public class TopLeftZone : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {

            LeaveMeAlone.ZoneManager = 1;

        }
        if (col.gameObject.tag == "Bunny")
        {

            LeaveMeAlone.ZoneBunnyManager = 1;

        }
    }
}
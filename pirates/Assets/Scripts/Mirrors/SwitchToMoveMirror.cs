﻿using UnityEngine;
using System.Collections;

public class SwitchToMoveMirror : MonoBehaviour {
    public bool isSwitchDown;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            isSwitchDown = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            isSwitchDown = false;
        }
    }
}

﻿using UnityEngine;
using System.Collections;

public class switchScript : MonoBehaviour {
	public bool isSwitchDown = false;
	public static int switchNumber=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay2D(Collider2D collide)
	{
		if (collide.gameObject.tag == "puzzleObj")
		{
			isSwitchDown = true;
			Debug.Log("Swith Is Down");
		
			//Destroy(gameObject);
		}

	}
	void OnTriggerExit2D(Collider2D collide)
	{
		if (collide.gameObject.tag == "puzzleObj")
		{
			isSwitchDown = false;
			Debug.Log("Swith Is up");
		}
	}
}

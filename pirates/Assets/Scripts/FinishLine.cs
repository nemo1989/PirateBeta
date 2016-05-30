using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {
    public GameController controller;
	// Use this for initialization
	void OnTriggerEnter2D (Collider2D coll)
	{
		if (!controller.isItBlindLevel)
		{
			if (coll.gameObject.tag == "Player") {
				controller.win = true;
			}
		} else 
		{
			if (coll.gameObject.tag == "Blind") 
			{
				controller.win = true;
			}
		}
	}
}

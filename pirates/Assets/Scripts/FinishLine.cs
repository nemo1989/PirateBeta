using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {
    public GameController controller;
	// Use this for initialization
	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
            controller.win = true;
		}
	}
}

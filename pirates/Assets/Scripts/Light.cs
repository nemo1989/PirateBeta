using UnityEngine;
using System.Collections;

public class Light : MonoBehaviour {
	bool hasEntered = true;
    public GameController controller;

	void OnTriggerEnter2D(Collider2D colide)
	{
		if (colide.gameObject.tag == "Player") 
		{
			hasEntered = true;
		}
	}

	void OnTriggerStay2D(Collider2D colide)
	{

		if(colide.gameObject.tag == "Player")
			{
			Debug.Log("player is Safe");
			}

	}
	void OnTriggerExit2D(Collider2D colide)
	{

		if(colide.gameObject.tag == "Player")
			{
                controller.gameOver = true;
			hasEntered = false;
			}

	}
}

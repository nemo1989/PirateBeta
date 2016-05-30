using UnityEngine;
using System.Collections;

public class PickUpMirror : MonoBehaviour 
{
	public GameObject[] openDoor;
	public bool isTheFirstDoorOpen;
	// Use this for initialization
	void Start () 
	{

			if(isTheFirstDoorOpen)
			{
			if(openDoor.Length > 0)
			{
			openDoor [0].gameObject.GetComponent<Door> ().OpenDoor ();
			}
				if(openDoor.Length == 2)
				{
				openDoor [1].gameObject.GetComponent<Door> ().CloseDoor ();
			}
			}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			gameObject.SetActive(false);
			openDoor[0].gameObject.GetComponent<Door>().CloseDoor();
			if(openDoor.Length >1)
			{
			openDoor [1].gameObject.GetComponent<Door> ().OpenDoor ();
			}
		}

	}
}

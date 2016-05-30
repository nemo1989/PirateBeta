using UnityEngine;
using System.Collections;

public class OpenDoorForeva : MonoBehaviour {

	public GameObject openDoor;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		
		if (col.gameObject.tag == "Player" ||col.gameObject.tag == "Blind") 
		{
			openDoor.gameObject.GetComponent<Door>().OpenDoor();
			
			//			openDoor.gameObject.GetComponent<Animator>().SetBool("Open",true);
			//			openDoor.gameObject.GetComponent<BoxCollider2D>().enabled =false;
		}
	}
//	void OnTriggerExit2D(Collider2D col)
//	{
//		
//		if (col.gameObject.tag == "Player" ||col.gameObject.tag == "Blind") 
//		{
//			openDoor.gameObject.GetComponent<Door>().CloseDoor();
//			//			openDoor.gameObject.GetComponent<Animator>().SetBool("Open",false);
//			//			openDoor.gameObject.GetComponent<BoxCollider2D>().enabled =true;
//		}
//	}
}

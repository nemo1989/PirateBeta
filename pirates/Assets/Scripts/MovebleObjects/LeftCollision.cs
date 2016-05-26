using UnityEngine;
using System.Collections;

public class LeftCollision : MonoBehaviour {
	public movigObjectScript moveObj;
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "wall" || col.gameObject.tag == "puzzleObj") {
			moveObj.leftMoveable = false;
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "wall" || col.gameObject.tag == "puzzleObj") {
			moveObj.leftMoveable = true;
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "wall" || col.gameObject.tag == "puzzleObj") {
			moveObj.stopSpeedX ();
		}
	}
}

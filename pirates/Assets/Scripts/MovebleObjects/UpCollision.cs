using UnityEngine;
using System.Collections;

public class UpCollision : MonoBehaviour {
public movigObjectScript moveObj;

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "wall" || col.gameObject.tag == "puzzleObj") {
			moveObj.upMoveable = false;
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "wall" || col.gameObject.tag == "puzzleObj") {
			moveObj.upMoveable = true;
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "wall" || col.gameObject.tag == "puzzleObj") {
			moveObj.stopSpeedY ();
		}
	}
}

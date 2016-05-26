using UnityEngine;
using System.Collections;

public class RightCollision : MonoBehaviour {

	public movigObjectScript moveObj;
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "wall" || col.gameObject.tag == "puzzleObj")
		{
			moveObj.rightMoveable = false;
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "wall" || col.gameObject.tag == "puzzleObj")
		{
			moveObj.rightMoveable = true;
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "wall" || col.gameObject.tag == "puzzleObj") {
			moveObj.stopSpeedX ();
		}
	}
}

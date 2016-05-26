using UnityEngine;
using System.Collections;

public class DownCollision: MonoBehaviour {
	public movigObjectScript moveObj;
	void OnTriggerStay2D(Collider2D col)
	{
		if(col.gameObject.tag == "wall" || col.gameObject.tag == "puzzleObj")
		{
		moveObj.downMoveable = false;
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "wall" || col.gameObject.tag == "puzzleObj") 
		{
			moveObj.downMoveable = true;
		}
	}
	void OnTriggerEnter2D(Collider2D col )
	{
		if (col.gameObject.tag == "wall" || col.gameObject.tag == "puzzleObj") 
		{
			moveObj.stopSpeedY();
		}
	}
}

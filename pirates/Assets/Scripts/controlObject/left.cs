using UnityEngine;
using System.Collections;

public class left : MonoBehaviour {

	public ControlObject state;
	
	void OnTriggerStay2D(Collider2D colide)
	{
		if (colide.gameObject.tag == "Player")
		{
			state.state = ControlObject.ObjectState.LEFT;
		} 
		
	}
	void OnTriggerExit2D(Collider2D colide)
	{
		if (colide.gameObject.tag == "Player")
		{
			state.state = ControlObject.ObjectState.STOP;
		} 
		
	}
}

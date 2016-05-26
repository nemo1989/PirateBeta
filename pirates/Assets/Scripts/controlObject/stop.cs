using UnityEngine;
using System.Collections;

public class stop : MonoBehaviour {

	public ControlObject state;
	
	void OnTriggerStay2D(Collider2D colide)
	{
		if (colide.gameObject.tag == "Player")
		{
			state.state = ControlObject.ObjectState.STOP;
		} 
		
	}
}

using UnityEngine;
using System.Collections;

public class up : MonoBehaviour
{
	public ControlObject state;

void OnTriggerStay2D(Collider2D colide)
	{
		if (colide.gameObject.tag == "Player")
		{
			state.state = ControlObject.ObjectState.UP;
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

using UnityEngine;
using System.Collections;

public class ControlObject : MonoBehaviour {
	public enum ObjectState{UP,DOWN,LEFT,RIGHT,STOP};
	public ObjectState state = ObjectState.STOP;
	public float speed = 0.01f;
	// Use this for initialization
	void Start () {
		state = ObjectState.STOP;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (state == ObjectState.UP)
		{
			transform.position = new Vector3(transform.position.x,transform.position.y+speed,1);
		}
		 if (state == ObjectState.DOWN)
		{
			transform.position = new Vector3(transform.position.x,transform.position.y-speed,1);
		}
		 if (state == ObjectState.LEFT)
		{
			transform.position = new Vector3(transform.position.x-speed,transform.position.y,1);
		}

		 if (state == ObjectState.RIGHT)
		{
			transform.position = new Vector3(transform.position.x+speed,transform.position.y,1);
		}

		if (state == ObjectState.STOP)
		{
			transform.position = new Vector3(transform.position.x,transform.position.y,1);
		}
	
	}
}

using UnityEngine;
using System.Collections;

public class movigObjectScript : MonoBehaviour {
	float speed = 4f;
	public enum states{UP,DOWN,LEFT,RIGHT,STOP};
	public states moveDirection;
	bool locked = false;

	public bool isHit = false;
	public bool leftMoveable = true,rightMoveable = true,upMoveable =true,downMoveable =true;
	GameObject player;
	Move playerState;
	 float Xspeed;
	 float Yspeed ;
	// Use this for initialization
	void Start () {
		moveDirection = states.STOP;

		player = GameObject.FindGameObjectWithTag("Player");
		playerState = player.gameObject.GetComponent<Move> ();
	
	}
	
	public void stopSpeedX()
	{
		Xspeed = 0;
	}
	public void stopSpeedY()
	{
		Yspeed = 0;
	}
	void Update () {
		
	
		if (playerState.facing == Move.faceStates.FACERIGHT && isHit && rightMoveable)
		{
			Yspeed = 0;
			Xspeed = speed;
			isHit = false;
			moveDirection = states.RIGHT;
		}
		if (playerState.facing == Move.faceStates.FACEUP && isHit && upMoveable)
		{
			Yspeed = speed;
			Xspeed = 0;
			isHit = false;
			moveDirection = states.UP;
		}
		if (playerState.facing == Move.faceStates.FACELEFT && isHit && leftMoveable)
		{
			Yspeed = 0;
			Xspeed = -speed;
			isHit = false;
			moveDirection = states.LEFT;
		}
		if (playerState.facing == Move.faceStates.FACEDOWN && isHit && downMoveable)
		{
			Yspeed = -speed;
			Xspeed = 0;
			isHit = false;
			moveDirection = states.DOWN;
		}
		isHit = false;
		transform.position = new Vector2 (transform.position.x +Xspeed*Time.deltaTime, transform.position.y +Yspeed*Time.deltaTime);

	}





}

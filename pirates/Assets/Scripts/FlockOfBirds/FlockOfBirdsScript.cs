using UnityEngine;
using System.Collections;

public class FlockOfBirdsScript : MonoBehaviour {
	public Transform point1;
	public Transform point2;
	public float speed;
	float x;
	float y;
	bool moveLeft;
	public bool upDown;
	Animator anim;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		transform.position = point1.position;
		x = transform.position.x;
		y = transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		moveToPoints ();
		if (!upDown) {
			if (transform.position.x < x) {

				anim.SetBool ("isMovingLeft", true);

			} else {
				anim.SetBool ("isMovingLeft", false);
			}
			x = transform.position.x;
		} 
		else 
		{
			if (transform.position.y < y) 
			{
			
				anim.SetBool ("isMovingLeft", true);
			
			} 
			else 
			{
				anim.SetBool ("isMovingLeft", false);
			}

			y = transform.position.y;
		}
	}
	void moveToPoints()
	{
		if(point1 !=null)
		{
			if(!moveLeft)
			{
			transform.position = Vector2.MoveTowards(transform.position,point2.position,speed*Time.deltaTime);
				if(transform.position == point2.position)
				{
					moveLeft = true;
				}
			}
			if(moveLeft)
			{
				transform.position = Vector2.MoveTowards(transform.position,point1.position,speed*Time.deltaTime);
				if(transform.position == point1.position)
				{
					moveLeft = false;
				}
			}
		}
	}
}

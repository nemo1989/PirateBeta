using UnityEngine;
using System.Collections;

public class CaptainBullet : MonoBehaviour {


	public float speed = 4;
	Animator anim;
	float x;
	float y;
	public Transform[] points;
	public bool hasReachedDestination = false;
	public bool inRange = false;
	float backSpeed = 1f;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		x = transform.position.x;
		y = transform.position.y;
		if (points != null) 
		{
			//transform.position = points [0].position;
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		checkWhatDirectioToFace ();
		if (inRange)
		{
			AttackPlayer ();
		}
	}
	
	void AttackPlayer()
	{

	if (points == null || points[1] == null) 
	{
		return;
	}
	if ( !hasReachedDestination)
	{
		transform.position = Vector2.MoveTowards (transform.position, points[1].position, speed*Time.deltaTime);
			anim.SetBool("isAttacking",true);
		if(transform.position == points[1].position)
		{
			hasReachedDestination = true;
		}
	}
	if( hasReachedDestination)
	{
		transform.position = Vector2.MoveTowards(transform.position,points[0].position,backSpeed*Time.deltaTime);
			anim.SetBool("isAttacking",false);
		if(transform.position == points[0].position)
		{
			hasReachedDestination = false;
			
				inRange = false;
		}
	}
	
}
	
	void WalkAnimation(float x, float y, bool walking)
	{
		anim.SetFloat("speedX", x);
		anim.SetFloat("speedY", y);
		anim.SetBool("isWalking",walking);
	}
	void checkWhatDirectioToFace()
	{
		if (transform.position.y > y)
		{
			WalkAnimation (0, 3, true);
			
		} 
		else if (transform.position.y < y) 
		{
			WalkAnimation (0, -3, true);
			
		} 
		else if (transform.position.x > x)
		{
			WalkAnimation (3, 0, true);
			
		} 
		else if (transform.position.x < x)
		{
			WalkAnimation (-3, 0, true);
			
		} 
		else 
		{
			anim.SetBool("isWalking",false);
		}
		
		y = transform.position.y;
		x = transform.position.x;
	}
}

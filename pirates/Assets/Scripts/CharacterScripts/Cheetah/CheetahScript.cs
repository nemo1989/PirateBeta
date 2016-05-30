using UnityEngine;
using System.Collections;

public class CheetahScript : MonoBehaviour {

	public GameController controller;
	public int coins =0;
	public float speed = 4;
	//public Text CoinScore;
	Animator anim;
	Rigidbody2D rigi; 
	float x;
	float y;
	public bool isTraped;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		rigi = GetComponent<Rigidbody2D> ();
		x = transform.position.x;
		y = transform.position.y;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	
		
	}
	
	void FixedUpdate()
		
	{
		if (rigi.velocity.y > 0.7)
		{
			WalkAnimation (0, 3, true);
			
		} 
		else if (rigi.velocity.y < -0.7) 
		{
			WalkAnimation (0, -3, true);
			
		} 
		else if (rigi.velocity.x > 0.7)
		{
			WalkAnimation (3, 0, true);
			
		} 
		else if (rigi.velocity.x < -0.7)
		{
			WalkAnimation (-3, 0, true);
			
		} 
		else 
		{
			anim.SetBool("isWalking",false);
		}
		
		
	}
	

	
	void WalkAnimation(float x, float y, bool walking)
	{
		anim.SetFloat("speedX", x);
		anim.SetFloat("speedY", y);
		anim.SetBool("isWalking",walking);
	}

}

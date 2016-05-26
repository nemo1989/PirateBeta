using UnityEngine;
using System.Collections;

public class WalkingBombScript : MonoBehaviour {
	
	public float speed = 0;
	public bool hasExploded;
	public GameObject hitBox;
	AudioSource source;
	public AudioClip Explosion;
	Animator anim;
	float x;
	float y;
	bool hasPlayedClip;
	
	
	Rigidbody2D rigi2d;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		source = GetComponent<AudioSource> ();
		x = transform.position.x;
		y = transform.position.y;
		rigi2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		explode ();
		checkAndDestroy ();
	}
	
	void FixedUpdate()
	{
		if (transform.position.y > y)
		{
			WalkAnimation (0, 1, true);
			
		} 
		else if (transform.position.y < y) 
		{
			WalkAnimation (0, -1, true);
			
		} 
		else if (transform.position.x > x)
		{
			WalkAnimation (1, 0, true);
			
		} 
		else if (transform.position.x < x)
		{
			WalkAnimation (-1, 0, true);
			
		} 
		else 
		{
			anim.SetBool("isWalking",false);
		}
		
		y = transform.position.y;
		x = transform.position.x;
	}
	
	void WalkAnimation(float x, float y, bool walking)
	{
		anim.SetFloat("speedX", x);
		anim.SetFloat("speedY", y);
		anim.SetBool("isWalking",walking);
	}
	void explode()
	{
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Explode")) 
		{
			hitBox.gameObject.GetComponent<WalkingBombHitBox>().isExploding = true;
			if(!hasPlayedClip)
			{
			source.PlayOneShot(Explosion,1f);
				hasPlayedClip = true;
			}

		}
		anim.SetBool("Explode",hasExploded);
	}
	void checkAndDestroy()
	{
	
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Destroy")) 
		{
            
            
                Destroy(this.gameObject);
            
           
           
		}
	}
}

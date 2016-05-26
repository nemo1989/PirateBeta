using UnityEngine;
using System.Collections;

public class MoveDemo : MonoBehaviour 
{
	public Transform brick;
	public Transform brick_left;
	public Transform brick_right;
	public GameController controller;
	public enum faceStates{FACEUP,FACEDOWN,FACELEFT,FACERIGHT};
	public	CharacterStates playerStates;
	Animator anim;
	Rigidbody2D _rigibody2d;
	public float speed;
	public  faceStates facing =  faceStates.FACEDOWN;
	GameObject hitBox;
	AudioSource source;
	public AudioClip auidoWalkingSound;
	bool left,right,down,up;
	public bool isWalking;
	int randomrange;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		_rigibody2d = GetComponent <Rigidbody2D>();
		source = GetComponent<AudioSource>();
		hitBox =transform.Find("hitBoxRight").gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
		checkDirection();
		WalkingSound();
		
	}
	
	void FixedUpdate()
	{
		
		MoveCharacter();
	}
	
	void checkDirection()
	{
		if (playerStates.state == CharacterStates.playerStates.IDLE || playerStates.state == CharacterStates.playerStates.WALKING)
		{
			if (Input.GetKey(KeyCode.UpArrow) || up)
			{
				WalkAnimation(0, 1, true);
				
				MoveUpAction();
			}
			else if (Input.GetKey(KeyCode.DownArrow) || down)
			{
				WalkAnimation(0, -1, true);
				MoveDownAction();
				
			}
			else if (Input.GetKey(KeyCode.LeftArrow) || left)
			{
				WalkAnimation(-1, 0, true);
				MoveLeftAction();
				
			}
			else if (Input.GetKey(KeyCode.RightArrow) || right)
			{
				WalkAnimation(1, 0, true);
				MoveRightAction();
				
			}
			else
			{
				anim.SetBool("isWalking", false);
				isWalking = false;
				playerStates.state = CharacterStates.playerStates.IDLE;
			}
		}
		else
		{
			
			anim.SetBool("isWalking", false);
			isWalking = false;
		}
	}
	
	void MoveCharacter()
	{
		float dirX = anim.GetFloat ("speedx");
		float dirY = anim.GetFloat ("speedy");
		bool walking = anim.GetBool ("isWalking");
		if(walking)
		{
			_rigibody2d.velocity = new Vector2 (dirX,dirY)*speed*Time.fixedDeltaTime;
			playerStates.state = CharacterStates.playerStates.WALKING;
		}
		else 
		{
			_rigibody2d.velocity = Vector2.zero;
		}
		
	}
	
	void WalkAnimation(float x, float y, bool walking)
	{
		anim.SetFloat("speedx", x);
		anim.SetFloat("speedy", y);
		anim.SetBool("isWalking",walking);
	}
	
	void MoveRightAction()
	{
		if(facing == faceStates.FACEDOWN)
		{
			hitBox.transform.Rotate((Vector3.forward * 90),Space.World);
			rightWall();
		}
		if(facing == faceStates.FACELEFT)
		{
			hitBox.transform.Rotate((Vector3.forward * 180),Space.World);
			rightWall();
		}
		if(facing == faceStates.FACEUP)
		{
			
			hitBox.transform.Rotate((Vector3.forward * -90),Space.World);
			rightWall();
			
		}
		facing =faceStates.FACERIGHT;
	}
	void MoveLeftAction()
	{

		if(facing == faceStates.FACEDOWN)
		{
			hitBox.transform.Rotate((Vector3.forward * -90),Space.World);
			leftWall ();
		}
		if(facing == faceStates.FACERIGHT)

		{
			hitBox.transform.Rotate((Vector3.forward * 180),Space.World);
			leftWall ();
		}
		if(facing == faceStates.FACEUP)
		{
			hitBox.transform.Rotate((Vector3.forward * 90),Space.World);
			leftWall ();
		}
		facing =faceStates.FACELEFT;
	}
	void MoveUpAction()
	{
		if(facing == faceStates.FACEDOWN)
		{
			hitBox.transform.Rotate((Vector3.forward * 180),Space.World);
			frontWall();
			//Instantiate(brick, hitBox.transform.position+(transform.forward*22), Quaternion.identity);
		}
		if(facing == faceStates.FACERIGHT)
		{
			hitBox.transform.Rotate((Vector3.forward * 90),Space.World);
			frontWall();
			//Instantiate(brick, hitBox.transform.position+(transform.up*2), Quaternion.identity);
		}
		if(facing == faceStates.FACELEFT)
		{
			hitBox.transform.Rotate((Vector3.forward * -90),Space.World);
			frontWall();
			//Instantiate(brick, hitBox.transform.position+(transform.forward*222), Quaternion.identity);
		}
		facing =faceStates.FACEUP;
	}
	void MoveDownAction()
	{
		if(facing == faceStates.FACEUP)
		{
			hitBox.transform.Rotate((Vector3.forward * 180),Space.World);
		}
		if(facing == faceStates.FACERIGHT)
		{
			hitBox.transform.Rotate((Vector3.forward * -90),Space.World);
		}
		if(facing == faceStates.FACELEFT)
		{
			hitBox.transform.Rotate((Vector3.forward * 90),Space.World);
		}
		facing =faceStates.FACEDOWN;
	}
	
	void WalkingSound()
	{
		if (anim.GetBool("isWalking") == true)
		{
			isWalking = true;
			if (!source.isPlaying)
			{
//				if (!controller.win && !controller.gameOver)
//				{
//					source.clip = (auidoWalkingSound);
//					source.Play();
//				}
			}
		}
	}
	public void frontWall(){
		randomrange = Random.Range (1, 3);
		Instantiate(brick_left, hitBox.transform.position+(transform.up*(randomrange)),Quaternion.identity);
	}
	public void rightWall(){
		randomrange = Random.Range (1, 4);
		Instantiate(brick_left, hitBox.transform.position+(transform.right*(randomrange)), brick_left.transform.rotation);
	}
	public void leftWall(){
		randomrange = Random.Range (1, 4);
		Instantiate(brick_left, hitBox.transform.position+(transform.right*(-randomrange)), brick_left.transform.rotation);
	
	}
	public void upPressed()
	{
		up = true;
	}
	public void upReleased()
	{
		up = false;
	}
	public void downPressed()
	{
		down = true;
	}
	public void downReleased()
	{
		down = false;
	}
	public void leftPressed()
	{
		left = true;
	}
	public void leftReleased()
	{
		left = false;
	}
	public void rightPressed()
	{
		right = true;
	}
	public void rightReleased()
	{
		right = false;
	}
	public void ReleaseAll()
	{
		right = false;
		left = false;
		up = false;
		down = false;
	}
}

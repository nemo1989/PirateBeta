using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Move : MonoBehaviour 
{

	public static bool BootsOn=false;
	public static bool RefreshBoots=false;
    public GameController controller;
	public enum faceStates{FACEUP,FACEDOWN,FACELEFT,FACERIGHT};
	public	CharacterStates playerStates;
	bool isSliding;
	public bool windPushBack;
	Animator anim;
	Rigidbody2D _rigibody2d;
	public float speed;
	public  faceStates facing =  faceStates.FACEDOWN;
	GameObject hitBox;
    AudioSource source;
    public AudioClip auidoWalkingSound;
	bool left,right,down,up;
    public bool isWalking;
	public static int BunnyCaught=0;
	public Text UpdateBunnies;
	int temp=BunnyCaught;
	bool isOnIce=false;

	int moveStateX;
	int moveStateY;
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
		if (BunnyCaught > temp) {
		
			UpdateBunnies.text="Bunnies Caught "+BunnyCaught.ToString()+"/"+BunnyController.TotaLBunnies.ToString();
			temp=BunnyCaught;
		}


        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
			checkDirection();
		if (BootsOn) {

		}
		if (windPushBack)
		{
			playerStates.state = CharacterStates.playerStates.PUSHBACK;
		}
		
	}
    
	void FixedUpdate()
	{
	
		MoveCharacter();
		WindPushing ();
		OnIce ();
	}
	void OnCollisionStay2D(Collision2D col)
	{
		if(col.gameObject.tag == "wall" )
		{
		
			playerStates.state = CharacterStates.playerStates.IDLE;
			isSliding = false;
			windPushBack = false;
			_rigibody2d.velocity = Vector2.zero;
			if(isOnIce)
			{
			if(moveStateX == 1)
			{
				_rigibody2d.transform.position = new Vector2 (_rigibody2d.transform.position.x -0.05f,_rigibody2d.transform.position.y);
				
			}
			if(moveStateX == -1)
			{
				_rigibody2d.transform.position = new Vector2 (_rigibody2d.transform.position.x +0.05f,_rigibody2d.transform.position.y);
				
			}
			if(moveStateY == 1)
			{
				_rigibody2d.transform.position = new Vector2 (_rigibody2d.transform.position.x ,_rigibody2d.transform.position.y-0.05f);
				
			}
			if(moveStateY == -1)
			{
				_rigibody2d.transform.position = new Vector2 (_rigibody2d.transform.position.x ,_rigibody2d.transform.position.y+0.05f);
				
			}
		
			}
		}
	}



	void OnTriggerEnter2D(Collider2D colide)
	{
		if (colide.gameObject.tag == "Boots"){
			speed = 300;
			BootsOn = true;
			RefreshBoots = true;
			colide.gameObject.SetActive(false);
		}
		if (colide.gameObject.tag == "wall") 
		{
			windPushBack = false;
			playerStates.state = CharacterStates.playerStates.IDLE;
		}


		if(colide.gameObject.tag == "Ice" )
		{
			
			playerStates.state = CharacterStates.playerStates.SLIDING;

			//Debug.Log("on ICE ");
		}
	}

	void OnTriggerStay2D(Collider2D colide)
	{
		

		if (colide.gameObject.tag == "Grass" && !BootsOn) {
			speed = 50;
			Debug.Log("we are on Grass");
		}
		else if(colide.gameObject.tag == "Grass" && BootsOn)
		{
			speed = 200;

		}
		if (colide.gameObject.tag == "wall") 
		{
			windPushBack = false;

		}

		 if(colide.gameObject.tag == "Ice" )
		{
			isOnIce =true;
			if(isSliding)
			{
			playerStates.state = CharacterStates.playerStates.SLIDING;
			}
			else
			{
				//playerStates.state = CharacterStates.playerStates.IDLE;
			}
		
		//	Debug.Log("on ICE ");
		}
	}
	void OnTriggerExit2D(Collider2D colide)
	{
		
		if (colide.gameObject.tag == "Grass" && !BootsOn) 
			speed = 200;
        else if (colide.gameObject.tag == "Grass" && BootsOn)
			speed = 300;
		if(colide.gameObject.tag == "Ice" )
		{
			
			playerStates.state = CharacterStates.playerStates.IDLE;
			isOnIce = false;
			Debug.Log("Not On ICE ");
		}
		if(colide.gameObject.tag == "Wind" )
		{
			windPushBack =false;
			playerStates.state = CharacterStates.playerStates.IDLE;
		}
	}
	void OnIce()
	{
		if (playerStates.state == CharacterStates.playerStates.SLIDING)
		{
			float dirX = anim.GetFloat ("speedx");
			float dirY = anim.GetFloat ("speedy");

			if(isSliding)
			
				_rigibody2d.velocity = new Vector2 (dirX,dirY)*speed*Time.fixedDeltaTime;
			
			
			else 
			{
				_rigibody2d.velocity = Vector2.zero;
			}

		}
	}
	void WindPushing()
	{
		if (playerStates.state == CharacterStates.playerStates.PUSHBACK)
		{
			float dirX = 0;
			float dirY = 1;
			
			if(windPushBack)
			{
				_rigibody2d.velocity = new Vector2 (dirX,dirY)*speed*Time.fixedDeltaTime;
				
			}
		
			
		}
	}
	void checkDirection()
	{
		if (playerStates.state == CharacterStates.playerStates.IDLE  || playerStates.state == CharacterStates.playerStates.WALKING  )
        {
            if (Input.GetKey(KeyCode.UpArrow) || up)
            {
                WalkAnimation(0, 1, true);
				isSliding =true;
				moveStateY = 1;
				moveStateX =0;
                MoveUpAction();
            }
            else if (Input.GetKey(KeyCode.DownArrow) || down)
            {
                WalkAnimation(0, -1, true);
				isSliding =true;
				moveStateY = -1;
				moveStateX =0;
                MoveDownAction();

            }
            else if (Input.GetKey(KeyCode.LeftArrow) || left)
            {
                WalkAnimation(-1, 0, true);
				isSliding =true;
				moveStateX = -1;
				moveStateY =0;
                MoveLeftAction();

            }
            else if (Input.GetKey(KeyCode.RightArrow) || right)
            {
                WalkAnimation(1, 0, true);
				isSliding =true;

				moveStateX = 1;
				moveStateY =0;
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
		if (playerStates.state != CharacterStates.playerStates.SLIDING)
		{
			if (walking)
			{
				_rigibody2d.velocity = new Vector2 (dirX, dirY) * speed * Time.fixedDeltaTime;
				playerStates.state = CharacterStates.playerStates.WALKING;
			} else
			{
				_rigibody2d.velocity = Vector2.zero;
			}
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
		}
		if(facing == faceStates.FACELEFT)
		{
			hitBox.transform.Rotate((Vector3.forward * 180),Space.World);
		}
		if(facing == faceStates.FACEUP)
		{
			hitBox.transform.Rotate((Vector3.forward * -90),Space.World);
		}
		facing =faceStates.FACERIGHT;
	}
	void MoveLeftAction()
	{
		if(facing == faceStates.FACEDOWN)
		{
			hitBox.transform.Rotate((Vector3.forward * -90),Space.World);
		}
		if(facing == faceStates.FACERIGHT)
		{
			hitBox.transform.Rotate((Vector3.forward * 180),Space.World);
		}
		if(facing == faceStates.FACEUP)
		{
			hitBox.transform.Rotate((Vector3.forward * 90),Space.World);
		}
		facing =faceStates.FACELEFT;
	}
	void MoveUpAction()
	{
		if(facing == faceStates.FACEDOWN)
		{
			hitBox.transform.Rotate((Vector3.forward * 180),Space.World);
		}
		if(facing == faceStates.FACERIGHT)
		{
			hitBox.transform.Rotate((Vector3.forward * 90),Space.World);
		}
		if(facing == faceStates.FACELEFT)
		{
			hitBox.transform.Rotate((Vector3.forward * -90),Space.World);
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
                if (!controller.win && !controller.gameOver)
                {
                    source.clip = (auidoWalkingSound);
                    source.Play();
                }
            }
        }
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

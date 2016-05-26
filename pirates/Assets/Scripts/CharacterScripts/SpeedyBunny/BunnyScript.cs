using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BunnyScript : MonoBehaviour {
    public GameController controller;
	public int coins =0;
	public float speed = 4;
	public Text CoinScore;
	Animator anim;
	Rigidbody2D rigi; 
	float x;
	float y;
    AudioSource source;
    public AudioClip boingSound;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		rigi = GetComponent<Rigidbody2D> ();
		x = transform.position.x;
		y = transform.position.y;
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		CoinScore.text = coins.ToString ();
        playWalkingNoise();

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
    void playWalkingNoise()
    {
        if(anim.GetBool("isWalking"))
        {
        if (!source.isPlaying)
        {
            if (!controller.win && !controller.gameOver)
            {
                source.clip = (boingSound);
                source.Play();
            }
        }
        }
    }
	
	void WalkAnimation(float x, float y, bool walking)
	{
		anim.SetFloat("speedX", x);
		anim.SetFloat("speedY", y);
		anim.SetBool("isWalking",walking);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Coin")
		{
			Destroy (col.gameObject);
			coins++;
		}
	}
}

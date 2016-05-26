using UnityEngine;
using System.Collections;

public class CannonBallScript : MonoBehaviour {
public	float speed  = 1000f;
	GameObject player;
    GameObject controller;
	 Move state;
 float Xspeed;
	 float Yspeed ;


public	bool isHit = false;
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		state = player.gameObject.GetComponent<Move> ();
        controller = GameObject.FindGameObjectWithTag("GameCon");
	}
    public void moveRight()
    {
        Xspeed = speed;
    }
    public void moveLeft()
    {
        Xspeed = -speed;
    }
    public void moveUp()
    {
        Yspeed = speed;

    }
    public void moveDown()
    {
        Yspeed = -speed;
       
    }
	
	// Update is called once per frame
	void Update () 
	{


	if (state.facing == Move.faceStates.FACERIGHT && isHit)
		{
			Yspeed = 0;
			Xspeed = speed;
			isHit = false;
		}
		if (state.facing == Move.faceStates.FACEUP && isHit)
		{
			Yspeed = speed;
			Xspeed = 0;
			isHit = false;
		}
		if (state.facing == Move.faceStates.FACELEFT && isHit)
		{
			Yspeed = 0;
			Xspeed = -speed;
			isHit = false;
		}
		if (state.facing == Move.faceStates.FACEDOWN && isHit)
		{
			Yspeed = -speed;
			Xspeed = 0;
			isHit = false;
		}
        transform.position = new Vector2(transform.position.x + Xspeed * Time.deltaTime, transform.position.y + Yspeed * Time.deltaTime);

	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            controller.GetComponent<GameController>().gameOver = true;
            Debug.Log("Game Over");
        }
       
    }
}

using UnityEngine;
using System.Collections;

public class CharacterStates : MonoBehaviour 
{
	public enum playerStates{BELLSTATE,IDLE,WALKING,BAT,BARREL};
	float exitTimeBell = 0;
	float exitTimeBat = 0;
	public bool bellPressed =false;
	bool actionGiven = false;
    AudioSource source;
    public AudioClip BellSound;

public  playerStates state =  playerStates.IDLE;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim=GetComponent <Animator>();
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		States();
		StateBell();
		batState();
	}
    void BarrelState()
    { 

    }
	void States()
	{
		if ( state == playerStates.IDLE ) 
		{
			if (Input.GetKeyDown (KeyCode.B)) 
			{
				state = playerStates.BELLSTATE;
			}

			if (Input.GetKeyDown (KeyCode.S))
			{
				state = playerStates.BAT;
			}
		}
	}
	void StateBell()
	{

		if (state == playerStates.BELLSTATE )
		{
			anim.SetBool("BellPressed",true);
			exitTimeBell += Time.deltaTime;
			bellPressed = true;
            if (!source.isPlaying)
            {
                source.clip = (BellSound);
                source.Play();

            }
		}

		if(exitTimeBell >= 1)
		{

			exitTimeBell = 0;
            source.Stop();
			anim.SetBool("BellPressed",false);
			bellPressed =false;
			state = playerStates.IDLE;
				anim.SetBool ("isStriking", false);

		}
	}

	void batState ()
	{

		if (state == playerStates.BAT)
		{
            if (exitTimeBat == 0)
            {
                anim.SetBool("isStriking", true);
            }
			exitTimeBat += Time.deltaTime;
			if (exitTimeBat >= 0.35) 
			{
				
			}

		
			if (exitTimeBat >= 0.5) 
			{
				exitTimeBat = 0;
                anim.SetBool("isStriking", false);
				state = playerStates.IDLE;
			}
		}

	}
	public void getTouchButtonForBell()
	{
		if ( state == playerStates.IDLE ) 
		{

			state = playerStates.BELLSTATE;

		}

	}
	public void getTouchButtonForBat()
	{
        if (state == playerStates.IDLE || state == playerStates.WALKING)
            
		{
			
			state = playerStates.BAT;
			
		}
	
	}


}

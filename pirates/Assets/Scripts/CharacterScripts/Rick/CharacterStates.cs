using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterStates : MonoBehaviour 
{
	public int countdownForBoots=10;
	float BootsDuration;
	public enum playerStates{BELLSTATE,IDLE,WALKING,BAT,BARREL,DIGGING,BOMB,TAKEDMG,SLIDING,PUSHBACK};
	float exitTimeBell = 0;
	float exitTimeBat = 0;
    float exitTimeDig = 0;
	public bool bellPressed =false;
	public float recoveryTime;
	 float damageTime;
	bool actionGiven = false;
	public bool isTakingDamage;
    public GameObject Bombs;
    public TrapScript trap;
    AudioSource source;
    public AudioClip BellSound;
	SpriteRenderer spriteBlink;
    List<TrapScript> trapArray = new List<TrapScript>();
    int count = 0;
	int stateBlinkOnOff;
	float blinkTime;

public  playerStates state =  playerStates.IDLE;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim=GetComponent <Animator>();
        source = GetComponent<AudioSource>();
		spriteBlink = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		DmgState ();
		States();
		StateBell();
		batState();
        digState();
		StateBoots ();
	}
    void BarrelState()
    { 

    }
	void States()
	{
		if (state == playerStates.PUSHBACK || state == playerStates.SLIDING)
		{
			anim.SetBool("BellPressed",false);
			anim.SetBool("isStriking", false);
		}
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
            if (Input.GetKeyDown(KeyCode.X))
            {
                GameObject bomb = (GameObject)Instantiate (Bombs);
                bomb.transform.position = transform.position;
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (trapArray.Count < 2)
                {
                    TrapScript traps = (TrapScript)Instantiate(trap);
                    traps.transform.position = transform.position;
                    trapArray.Add(traps);
                }
                else 
                {
                    if (count == 0)
                    {
                        trapArray[count].transform.position = gameObject.transform.position;
                        count = 1;
                    
                    }
                    else if (count == 1)
                    {
                        trapArray[count].transform.position = gameObject.transform.position;
                        count = 0;
                    
                    }
                
                }
            }
		}
	}
	void DmgState(){

	if (isTakingDamage) {
		

			damageTime += Time.deltaTime;
			blinkTime += Time.deltaTime;
			if (blinkTime > 0.1) {
				if (stateBlinkOnOff == 0) {
					stateBlinkOnOff = 1;
					spriteBlink.enabled = false;
					blinkTime = 0;
				} else if (stateBlinkOnOff == 1) {
					stateBlinkOnOff = 0;
					spriteBlink.enabled = true;
					blinkTime = 0;
				}
			}
			if (damageTime > recoveryTime) {
				damageTime = 0;
				isTakingDamage = false;
			}
		} 
		else 
		{
			spriteBlink.enabled = true;
		}
	

		
		

	
	
	}





	
	void StateBoots(){

		if (Move.BootsOn) {
		
			BootsDuration += Time.deltaTime;
			if(Move.RefreshBoots)
			{
				BootsDuration = 0;
				Move.RefreshBoots = false;
			}
			if (BootsDuration >= countdownForBoots)
			{
				BootsDuration = 0;
				Move.BootsOn = false;
		
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
    void digState()
    {

        if (state == playerStates.DIGGING)
        {
            if (exitTimeDig == 0)
            {
                anim.SetBool("isDigging", true);
            }
            exitTimeDig += Time.deltaTime;
            if (exitTimeDig >= 0.5)
            {
                anim.SetBool("isDigging", false);
            }

            if (exitTimeDig >= 1)
            {
                exitTimeDig = 0;
               
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
    public void getTouchButtonForDig()
    {
        if (state == playerStates.IDLE || state == playerStates.WALKING)
        {

            state = playerStates.DIGGING;

        }

    }


}

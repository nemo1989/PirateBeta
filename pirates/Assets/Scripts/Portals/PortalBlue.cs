using UnityEngine;
using System.Collections;

public class PortalBlue : MonoBehaviour {
	public GameObject Yellow;
	public bool active =true;
	public bool faceGiven;
	//public	Move pBStates; 
	public float gap;

	// Use this for initialization
	void Start () {
		active = true;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col)
	{	
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "puzzleObj")
		{	
			if(Yellow && active&& PortalWeapon.gatesSpawned==2)
			{

				col.gameObject.transform.position = Yellow.transform.position;
				Yellow.gameObject.GetComponent<PortalYellow>().active = false;

				//if(Yellow.gameObject.GetComponent<PortalYellow>().pStates == Move.faceStates.FACEDOWN){


				}

			}
		}


	void OnTriggerExit2D(Collider2D col)
	{	
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "puzzleObj")
		{	
			active = true;
		}
		
	}

public	void whichWayToFace(int pstate)
	{
		switch(pstate)
		{
		case(1):
			{
				transform.position = new Vector2(transform.position.x,transform.position.y +gap );
			break;
			}
		case(2):
		{
			transform.position = new Vector2(transform.position.x,transform.position.y -gap );
			break;
		}
		case(3):
		{
			transform.position = new Vector2(transform.position.x-gap,transform.position.y  );
			break;
		}
		case(4):
		{
			transform.position = new Vector2(transform.position.x+gap,transform.position.y );
			break;
		}
		}
	/*	if (pstate.facing == Move.faceStates.FACEDOWN)
		{
			transform.position = new Vector2(transform.position.x,transform.position.y +gap );


		}
		if (pstate.facing== Move.faceStates.FACEUP)
		{
			transform.position = new Vector2(transform.position.x,transform.position.y -gap );
			
			
		}
		if (pstate.facing == Move.faceStates.FACELEFT)
		{
			transform.position = new Vector2(transform.position.x+gap,transform.position.y  );
			
			
		}
		if (pstate.facing == Move.faceStates.FACERIGHT)
		{
			transform.position = new Vector2(transform.position.x-gap ,transform.position.y );
			
			
		}*/
	}
}

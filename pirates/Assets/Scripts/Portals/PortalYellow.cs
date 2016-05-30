using UnityEngine;
using System.Collections;

public class PortalYellow : MonoBehaviour {
	public GameObject Blue;
	public bool active=true;
	public bool faceGiven;
	public	Move pStates; 
	public float gap;
	public static bool yellowcheck=false;
	// Use this for initialization
	void Start () {
		active = true;
		yellowcheck = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "puzzleObj")
		{
			if(Blue && active &&  PortalWeapon.gatesSpawned==2)
			{
				col.gameObject.transform.position = Blue.transform.position;
				Blue.gameObject.GetComponent<PortalBlue>().active = false;
			
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
	public	void whichWayToFace(int state)
	{
		switch(state)
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
		/*if (pStates.facing == Move.faceStates.FACEDOWN)
		{
			transform.position = new Vector2(transform.position.x,transform.position.y +gap );
				
				
		}
		if (pStates.facing == Move.faceStates.FACEUP)
		{
			transform.position = new Vector2(transform.position.x,transform.position.y -gap );
				
				
		}
		if (pStates.facing == Move.faceStates.FACELEFT)
		{
			transform.position = new Vector2(transform.position.x+gap,transform.position.y  );
				
				
		}
		if (pStates.facing == Move.faceStates.FACERIGHT)
		{
			transform.position = new Vector2(transform.position.x-gap ,transform.position.y );
				
				
		}*/
	}
}
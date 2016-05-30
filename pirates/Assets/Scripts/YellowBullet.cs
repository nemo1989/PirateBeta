using UnityEngine;
using System.Collections;

public class YellowBullet : MonoBehaviour {

	float speed;
	GameObject player;
	bool up;
	bool south,east,north,west;
	GameObject yellowPortal;
	int state;
	// Use this for initialization
	void Start ()
	{
		yellowPortal=GameObject.FindGameObjectWithTag("YellowPortal");
		player = GameObject.FindGameObjectWithTag("Player");
		speed = 10;

		//		state = player.GetComponent<Move> ().facing;
		//bluePortal.gameObject.GetComponent<PortalBlue>().whichWayToFace();
		speed = 10;
		
		
		if (player.GetComponent<Move>().facing == Move.faceStates.FACEDOWN)
		{
			state =1;
			Debug.Log("PISSS OFFFF");
			south = true;
			up = true;
		}
		if (player.GetComponent<Move>().facing == Move.faceStates.FACEUP)
		{
			state =2;
			Debug.Log("PISSS OFFFF");
			north = true;
			up =true;
		}
		if (player.GetComponent<Move>().facing == Move.faceStates.FACERIGHT)
		{
			state =3;
			Debug.Log("PISSS OFFFF");
			east = true;
			up = false;
		}
		if (player.GetComponent<Move>().facing == Move.faceStates.FACELEFT)
		{
			state = 4;
			
			west = true;
			up = false;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (south) {
			MoveBulletToFaceTheRightDirection(0,-speed);
		}
		if (north) {
			MoveBulletToFaceTheRightDirection(0,speed);
		}
		if (east) {
			MoveBulletToFaceTheRightDirection(speed,0);
		}
		if (west)
		{
			MoveBulletToFaceTheRightDirection(-speed,0);
		}
	}
	public	void MoveBulletToFaceTheRightDirection(float x, float y)
	{
		if (!up) {
			transform.position = new Vector2 (transform.position.x + x * Time.deltaTime, transform.position.y);
		} else {
			transform.position = new Vector2 (transform.position.x, transform.position.y + y * Time.deltaTime);
		}
	}
	
	void OnTriggerExit2D(Collider2D col){
		//Debug.Log("out of collider");
		if (col.gameObject.tag == "RangeIndicator") {
			Destroy(gameObject);
			PortalWeapon.yellowDeployed=false;
			//Debug.Log ("am i in yellow?");
			
		}
		
	}
	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log("work??");
		if (col.gameObject.tag == "Rock") {
			PortalWeapon.yellowDeployed=false;
			Destroy(gameObject);
		}
		if (col.gameObject.tag == "PortalWall") {

			//Debug.Log ("am i in yellowWALL?");
			PortalWeapon.yellowDeployed=false;
			yellowPortal.transform.position=transform.position;
			yellowPortal.gameObject.GetComponent<PortalYellow>().whichWayToFace(state);
			//yellowPortal.SetActive(true);
			Destroy(gameObject);

		}
		
	}
	
}

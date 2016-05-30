using UnityEngine;
using System.Collections;
using Pathfinding;
public class CheetahGetPlayer : MonoBehaviour {

	public Transform homePosition;
	public Transform playerPosition;
	GameObject gamecon;
	private Seeker seeker;
	float checkTime = 0;
	Rigidbody2D rigi2d;
	//The calculated path
	public Path path;
	int random;
	//The AI's speed per second
	public float speed = 2;
	public static bool detectedPlayer;
	bool pathReached;
	//The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 3;
	
	//The waypoint we are currently moving towards
	private int currentWaypoint = 0;
	
	 void Start()
	{
		rigi2d = GetComponent<Rigidbody2D>();
		seeker = GetComponent<Seeker>();
		gamecon = GameObject.FindGameObjectWithTag ("GameCon");
		seeker.StartPath(rigi2d.position,homePosition.position, OnPathComplete);
		
	}
	
	public void OnPathComplete(Path p)
	{
		//Debug.Log( "Yay, we got a path back. Did it have an error? " + p.error );
		if (!p.error)
		{
			path = p;
			//Reset the waypoint counter
			currentWaypoint = 0;
		}
	}
	
	 void Update()
	{
		if (detectedPlayer) {
			FindPlayerByAstar ();
		} 
		else
		{
			if(!pathReached)
			FindHomeByAstar();
		}

		}
	void FindPlayerByAstar()
	{
		
		checkTime += Time.deltaTime;
		
		if (path == null)
		{
			//We have no path to move after yet
			return;
		}
		
		if (checkTime >= 0.5f) {
			
			checkTime = 0;
			
			
			Debug.Log ("aaaaaahhhhhhhhhhhhh");
			seeker.StartPath (rigi2d.position, playerPosition.position, OnPathComplete);
			pathReached = false;
			
			
		}
		
		if (currentWaypoint >= path.vectorPath.Count)
		{
			
			Debug.Log ("End Of Path Reached");
			
			rigi2d.velocity =Vector2.zero;
			
			//seeker.StartPath (rigi2d.position, playerPosition.position, OnPathComplete);
			
			return;

		}
		
		//Direction to the next waypoint
		Vector2 dir = new Vector2 (path.vectorPath [currentWaypoint].x - rigi2d.transform.position.x, path.vectorPath [currentWaypoint].y - rigi2d.transform.position.y).normalized;
		dir *= speed * Time.fixedDeltaTime;
		rigi2d.velocity = new Vector2 (dir.x, dir.y);
		
		
		//Check if we are close enough to the next waypoint
		//If we are, proceed to follow the next waypoint
		if (Vector2.Distance (rigi2d.position, path.vectorPath [currentWaypoint]) < nextWaypointDistance) {
			currentWaypoint++;
			return;
		}
	}
	void FindHomeByAstar()
	{
		
		checkTime += Time.deltaTime;
		
		if (path == null)
		{
			//We have no path to move after yet
			return;
		}
		
		if (checkTime >= 0.5f) 
		{
			
			checkTime = 0;
			
			
		
		seeker.StartPath (rigi2d.position, homePosition.position, OnPathComplete);
		
			
			
		}
		
		if (currentWaypoint >= path.vectorPath.Count)
		{
			
			Debug.Log ("End Of Path Reached");
			
			
			rigi2d.velocity =Vector2.zero;
		
			pathReached =true;
			
			return;
		}
		
		//Direction to the next waypoint
		Vector2 dir = new Vector2 (path.vectorPath [currentWaypoint].x - rigi2d.transform.position.x, path.vectorPath [currentWaypoint].y - rigi2d.transform.position.y).normalized;
		dir *= speed * Time.fixedDeltaTime;
		rigi2d.velocity = new Vector2 (dir.x, dir.y);
		
		
		//Check if we are close enough to the next waypoint
		//If we are, proceed to follow the next waypoint
		if (Vector2.Distance (rigi2d.position, path.vectorPath [currentWaypoint]) < nextWaypointDistance)
		{
			currentWaypoint++;
			return;
		}
	}

		void OnTriggerEnter2D(Collider2D col)
		{

			if (col.gameObject.tag == "Player")
			{
			gamecon.gameObject.GetComponent<GameController>().gameOver=true;

			}
		}
//		void OnTriggerExit2D(Collider2D col)
//		{
//			
//			if (col.gameObject.tag == "Player")
//			{
//				detectedPlayer =false;
//			}
//		}

	}

using UnityEngine;
using System.Collections;
using Pathfinding;
public class AICollectCoins : MonoBehaviour
{
	//The point to move to

	Transform[] coinHolder;
	public Transform COINHOLDER;
	private Seeker seeker;
	float checkTime = 0;
	Rigidbody2D rigi2d;
	//The calculated path
	public Path path;
	
	//The AI's speed per second
	public float speed = 2;

	
	//The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 3;
	
	//The waypoint we are currently moving towards
	private int currentWaypoint = 0;
	
	public void Start ()
	{	rigi2d = GetComponent<Rigidbody2D> ();
		seeker = GetComponent<Seeker>();
		
		//Start a new path to the targetPosition, return the result to the OnPathComplete function
		coinHolder = COINHOLDER.GetComponentsInChildren<Transform>();


			seeker.StartPath(rigi2d.position,coinHolder[1].position, OnPathComplete);
	
	}
	
	public void OnPathComplete ( Path p )
	{
		//Debug.Log( "Yay, we got a path back. Did it have an error? " + p.error );
		if (!p.error)
		{
			path = p;
			//Reset the waypoint counter
			currentWaypoint = 0;
		}
	}
	
	public void update()
	{
		coinHolder = COINHOLDER.GetComponentsInChildren<Transform>();
		checkTime += Time.deltaTime;

		if (path == null)
		{
			//We have no path to move after yet
			return;
		}
		if (checkTime >= 7)
		{

			checkTime = 0;

				if (coinHolder[1] == null)
				{

					return;
				}
			seeker.StartPath(rigi2d.position,coinHolder[1].position, OnPathComplete);
			AstarPath.active.Scan ();

		
		}

		if (currentWaypoint >= path.vectorPath.Count)
		{

		//	Debug.Log( "End Of Path Reached" );

				if (coinHolder[1] == null)
				{

				//Debug.Log("Game over");
					return;
				}
	
			seeker.StartPath(rigi2d.position,coinHolder[1].position, OnPathComplete);
		
			
			return;
		}
		
		//Direction to the next waypoint
		Vector2 dir =  new Vector2( path.vectorPath[ currentWaypoint ].x - rigi2d.transform.position.x, path.vectorPath[currentWaypoint].y - rigi2d.transform.position.y ).normalized;
		dir *= speed * Time.fixedDeltaTime;
		rigi2d.velocity = new Vector2(dir.x ,dir.y);
	

		//Check if we are close enough to the next waypoint
		//If we are, proceed to follow the next waypoint
		if (Vector2.Distance( rigi2d.position, path.vectorPath[ currentWaypoint ] ) < nextWaypointDistance)
		{
			currentWaypoint++;
			return;
		}
	}
}
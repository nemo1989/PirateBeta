using UnityEngine;
using System.Collections;
//Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
//This line should always be present at the top of scripts which use pathfinding
using Pathfinding;

public class AstarAI : MonoBehaviour
{
    float checkTime;
  //The point to move to
  public Transform target;

  private Seeker seeker;

  //The calculated path
  public Path path;

  //The AI's speed per second
  public float speed = 2;

  //The max distance from the AI to a waypoint for it to continue to the next waypoint
  public float nextWaypointDistance = 3;

  //The waypoint we are currently moving towards
  private int currentWaypoint = 0;
  Rigidbody2D body;
  public void Start ()
  {
    seeker = GetComponent<Seeker>();
    body = GetComponent<Rigidbody2D>();
    //Start a new path to the targetPosition, return the result to the OnPathComplete function
    seeker.StartPath(body.position,target.position,OnPathComplete );
  }

  public void OnPathComplete ( Path p )
  {
   // Debug.Log( "Yay, we got a path back. Did it have an error? " + p.error );
    if (!p.error)
    {
      path = p;
      //Reset the waypoint counter
      currentWaypoint = 0;
    }
  }

  public void update ()
  {
    
    if (path == null)
    {
      //We have no path to move after yet
      return;
    }

    if (currentWaypoint >= path.vectorPath.Count)
    {
      Debug.Log( "End Of Path Reached" );
      body.velocity = Vector2.zero;
      return;
    }

    //Direction to the next waypoint
    Vector2 dir = new Vector2 (path.vectorPath[currentWaypoint].x - body.transform.position.x, path.vectorPath[currentWaypoint].y - body.transform.position.y).normalized;
    dir *= speed * Time.fixedDeltaTime;
  //  this.gameObject.transform.Translate( dir );
    body.velocity = new Vector2(dir.x, dir.y);
		//AstarPath.active.Scan ();
    //Check if we are close enough to the next waypoint
    //If we are, proceed to follow the next waypoint
    if (Vector2.Distance( body.position, path.vectorPath[ currentWaypoint ] ) < nextWaypointDistance)
    {
      currentWaypoint++;
      return;
    }
  }
}
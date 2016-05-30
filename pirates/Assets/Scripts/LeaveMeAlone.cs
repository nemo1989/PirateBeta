using UnityEngine;
using System.Collections;
using Pathfinding;
public class LeaveMeAlone : MonoBehaviour {
    public GameObject[] Zones;
    GameObject player;
	Transform [] nodes;
	bool PathGiven=false;
    Transform[] TopLeftNodes;
    public Transform TopLeft;
    Transform[] TopRightNodes;
    public Transform TopRight;
    Transform[] BotLeftNodes;
    public Transform BotLeft;
    Transform[] BotRightNodes;
    public Transform BotRight;
    private Seeker seeker;
    float checkTime = 0;
    Rigidbody2D rigi2d;
    //The calculated path
    public Path path;
    int random;
	int curentRan =0;
    //The AI's speed per second
    public float speed = 2;
	bool BunnyFreeToMove;

    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance;

    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    public static float BunnySpeed=1.3f;
    public static bool RickWarning;
    public static int ZoneManager;
    public static int ZoneBunnyManager;
    float distanceY;
    float distanceX;
	float distanceZ;
  //  float delay;
    public float delay;
    float time;

    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rigi2d = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        ZoneNodes();
        //Start a new path to the targetPosition, return the result to the OnPathComplete function

		Debug.Log("if repeeat");

			seeker.StartPath (rigi2d.position, rigi2d.position, OnPathComplete);

		

	}
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;
		checkTime += Time.deltaTime;
       
		distanceX = player.transform.position.x - transform.position.x;
		distanceY = System.Math.Abs(player.transform.position.y) - System.Math.Abs(transform.position.y);
		//distanceZ = System.Math.Abs(player.transform.position.y) - System.Math.Abs(transform.position.y);
		if (ZoneBunnyManager == 1 && RickWarning)
        {
			if (System.Math.Abs(distanceX) > System.Math.Abs(distanceY))
                {
                    Debug.Log("Right or Left");
					nodes = BotLeftNodes;
					BunnyFreeToMove=true;
                    time = 0;
                }
                else if (distanceY > distanceX)
                {
                    Debug.Log("Bottom");
					BunnyFreeToMove=true;
					nodes = TopRightNodes;
                    time = 0;
                }
			else if (distanceY < 0)
			{
				Debug.Log("Top");
				BunnyFreeToMove=true;
				nodes = BotLeftNodes;
				time = 0;
			}
		}


		if (ZoneBunnyManager == 2&& RickWarning)
        {

            //if left
            //if bottom
			if (System.Math.Abs(distanceX) > System.Math.Abs(distanceY))
			{
				Debug.Log("Left or Right");
				nodes = BotRightNodes;
				BunnyFreeToMove=true;
				time = 0;
			}
			else if (distanceY > distanceX)
			{
				Debug.Log("Bottom");
				BunnyFreeToMove=true;
				nodes = TopLeftNodes;
				time = 0;
			}
			else if (distanceY < 0)
			{
				Debug.Log("Top");
				BunnyFreeToMove=true;
				nodes = BotRightNodes;
				time = 0;
			}
        }
		if (ZoneBunnyManager == 3&& RickWarning)
        {
			if (System.Math.Abs(distanceX) > System.Math.Abs(distanceY))
			{
				Debug.Log("Left");
				nodes = TopRightNodes;
				BunnyFreeToMove=true;
				time = 0;
			}
			else if (distanceY < 0)
			{
				Debug.Log("Top");
				BunnyFreeToMove=true;
				nodes = BotLeftNodes;
				time = 0;
			}
			else if (distanceY > distanceX)
			{
				Debug.Log("Bottom");
				BunnyFreeToMove=true;
				nodes = TopRightNodes;
				time = 0;
			}
            //if left
            //if top
        }
		if (ZoneBunnyManager == 4&& RickWarning)
        {
			if (System.Math.Abs(distanceX) > System.Math.Abs(distanceY))
			{
				Debug.Log("Right");
				nodes = TopLeftNodes;
				BunnyFreeToMove=true;
				time = 0;
			}
			else if (distanceY < 0)
			{
				Debug.Log("Top");
				BunnyFreeToMove=true;
				nodes = BotRightNodes;
				time = 0;
			}
			else if (distanceY > distanceX)
			{
				Debug.Log("Bottom");
				BunnyFreeToMove=true;
				nodes = TopLeftNodes;
				time = 0;
			}
            //if right
            //if top
        }
		if(BunnyFreeToMove&& nodes == BotLeftNodes)
		{
			GoToDestination(nodes);
		}
		if(BunnyFreeToMove&& nodes == TopLeftNodes)
		{
			GoToDestination(nodes);
		}
		if(BunnyFreeToMove&& nodes == TopRightNodes)
		{
			GoToDestination(nodes);
		}
		if(BunnyFreeToMove&& nodes == BotRightNodes)
		{
			GoToDestination(nodes);
		}
	}
    void ZoneNodes()
	{

		BotLeftNodes = BotLeft.GetComponentsInChildren<Transform>();
		BotRightNodes = BotRight.GetComponentsInChildren<Transform>();
        TopLeftNodes = TopLeft.GetComponentsInChildren<Transform>();
		TopRightNodes = TopRight.GetComponentsInChildren<Transform>();
        
        
        Debug.Log("zones are set");
	}
    public void OnPathComplete(Path p)
    {
        Debug.Log( "Yay, we got a path back. Did it have an error? " + p.error );
        if (!p.error)
        {
            path = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
        }
    }

    public void GoToDestination(Transform[] zoneNodes)
    {

     

		//Reset the waypoint counter

//
       if (path == null)
        {
           Debug.Log("null");
         //  We have no path to move after yet
            return;
       }
	

		if (checkTime >= 0.5&& !PathGiven) 
		{

			checkTime=0;
		
			random = Random.Range (1, zoneNodes.Length);
			while(curentRan == random)
			{

				random = Random.Range (1, zoneNodes.Length);


			}
			curentRan = random;
			PathGiven = true;


			seeker.StartPath (rigi2d.position, zoneNodes [random].position, OnPathComplete);
			 AstarPath.active.Scan();
		}

        
        if (currentWaypoint >= path.vectorPath.Count)
        {

            	Debug.Log( "End Of Path Reached" );
                rigi2d.velocity =new Vector2(0,0);
				BunnyFreeToMove=false;
			    RickWarning = false;
				PathGiven = false;

		
			seeker.StartPath(rigi2d.position, zoneNodes[random].position, OnPathComplete);


            return;
        }

        //Direction to the next waypoint
        Vector2 dir = new Vector2(path.vectorPath[currentWaypoint].x - rigi2d.transform.position.x, path.vectorPath[currentWaypoint].y - rigi2d.transform.position.y).normalized;
        dir *= speed * Time.fixedDeltaTime;
        rigi2d.velocity = new Vector2(dir.x, dir.y);


        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector2.Distance(rigi2d.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }

    }
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") 
		{

			Destroy(gameObject);
			Move.BunnyCaught++;
		}
	}
    void BunnyTrapped()
    { 
    // if trap ==  true then stop the bunny  speed;
    }


    
}





using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GhostRick : MonoBehaviour {

	List<Transform> points = new List<Transform>();
	public float delay;
	public float startFollowingDelay;
	public float speed;
	public Rigidbody2D player;

	float time;
	float timeToFollower;
	int count = 0;
	int count2 = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time > delay)
		{
			Transform playerPos = player.transform;
			points.Add (playerPos);
			time =0;
		
		}
		FollowPoints();
	
	}
	void FollowPoints()
	{
		timeToFollower += Time.deltaTime;
	if (startFollowingDelay < timeToFollower)
		{
			transform.position = Vector2.MoveTowards(transform.position,points[count2].position,speed*Time.deltaTime);
			Debug.Log(points[count2].position);
			if(transform.position == points[count2].position)
			{
				Debug.Log(count);
				count2++;
			}


		}
	}
}

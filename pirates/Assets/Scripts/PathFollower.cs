using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour 
{

	public enum FollowType{

		MoveTowards,
		Lerp
	}

	public FollowType Type = FollowType.MoveTowards;
	public Paths  Path;
	public float Speed = 1;
	public float MaxDistanceToGoal = .1f;

	private IEnumerator<Transform> currentPoint;

	public void Start()
	{
		if (Path == null) 
		{

			Debug.LogError("path cannot be nulll", gameObject);
				return;

				}

		currentPoint = Path.GetPathEnumerator();
		currentPoint.MoveNext();

		if (currentPoint == null)
						return;

		transform.position = currentPoint.Current.position;
	}

	public void Update()
	{
		if (currentPoint == null || currentPoint.Current == null)
			return;
		
		if (Type == FollowType.MoveTowards)
			transform.position =Vector3.MoveTowards (transform.position,(new Vector3( currentPoint.Current.position.x,currentPoint.Current.position.y,-1)), Time.deltaTime * Speed);
		else if (Type == FollowType.Lerp)
            transform.position = Vector3.Lerp(transform.position, (new Vector3(currentPoint.Current.position.x, currentPoint.Current.position.y, currentPoint.Current.position.z - 1)), Time.deltaTime * Speed);
		
		var distanceSquared = (transform.position - currentPoint.Current.position).sqrMagnitude;
		if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
			currentPoint.MoveNext();
	}
}

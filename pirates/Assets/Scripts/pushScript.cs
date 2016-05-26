using UnityEngine;
using System.Collections;

public class pushScript : MonoBehaviour {
	float speedX = 0;
	float speedY = 0;
	bool directionGiven = false;
	float y;
	float x;
	// Use this for initialization
	void Start () {
		y = transform.position.y;
		x = transform.position.x;

	}
	IEnumerator waitForSec()
	{
		Debug.Log("push me");
		while (directionGiven==true) 
		{

			yield return new WaitForSeconds(1.0f);
			y = transform.position.y;
			x = transform.position.x;

			directionGiven = false;
		}
	}
	// Update is called once per frame
	void Update () {
		if(transform.position.y > y && directionGiven == false)
		{
			directionGiven = true;
			speedY = 3;
		}

		if(transform.position.y < y && directionGiven == false)
		{
			speedY = -3;
			directionGiven = true;
		}

		if(transform.position.x > x && directionGiven == false)
		{
			directionGiven = true;
			speedX = 3;
		}

		
		if(transform.position.x < x && directionGiven == false)
		{
			directionGiven = true;
			speedX = -3;
		}

		transform.position = new Vector2(transform.position.x + Time.deltaTime * speedX,transform.position.y + Time.deltaTime * speedY);
	
	}
	void OnCollisionEnter2D (Collision2D other) 
	{
		if(other.gameObject.tag == "floor")
		{
		
			speedX = 0;
			speedY = 0;
		
			StartCoroutine (waitForSec ());

		}
	}
}

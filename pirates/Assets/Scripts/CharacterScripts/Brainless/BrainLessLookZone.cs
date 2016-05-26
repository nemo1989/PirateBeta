using UnityEngine;
using System.Collections;

public class BrainLessLookZone : MonoBehaviour {
	public Transform starLineCastPoint;

	RaycastHit2D[] hit= new RaycastHit2D[39];
	public int distance = 7;
	float reduction = 0.05f;
	public bool left = false;

	// Use this for initialization
	void Start ()
	{


	}
	
	// Update is called once per frame
	void Update ()
	{
		Raycasting ();
	}
	void Raycasting()
	{
		if (left) {
			distance = -7;
		} else
		{
			distance = 7;
		}

		for (int i =0; i <= 38; i++) 
		{
			hit [i] = Physics2D.Raycast (starLineCastPoint.position, new Vector2 (1, 1f - reduction * i), distance, 1 << LayerMask.NameToLayer ("Obstacles"));
			Debug.DrawRay (starLineCastPoint.position, new Vector2 (1, 1f*180 - reduction * i));

			if (i >= 40) 
			{
				i = 0;
			}
		}
	
		foreach (RaycastHit2D whatHit in hit)
			{
			if(whatHit)
			{
				if (whatHit.collider.gameObject.tag == "Player")
					Debug.Log (" Game Over ");

			}
			
		}


	}
}

using UnityEngine;
using System.Collections;

public class BulletHitBox : MonoBehaviour {
	BoxCollider2D boxcollision;
	public CaptainBullet Cbullet;
	// Use this for initialization
	void Start () 
	{
		boxcollision = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!Cbullet.hasReachedDestination) 
		{
			boxcollision.enabled = true;
		} 
		else 
		{
			boxcollision.enabled = false;
		}
		
	}
void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			Debug.Log(" Player is hit ");
			Debug.Log(" player take damge or game over ");
		}
	}
}

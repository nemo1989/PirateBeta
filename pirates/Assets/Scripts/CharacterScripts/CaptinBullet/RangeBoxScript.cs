using UnityEngine;
using System.Collections;

public class RangeBoxScript : MonoBehaviour {
	public CaptainBullet CBullet;
	// Use this for initialization
	void Start()
	{

	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			CBullet.inRange = true;
		}
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			CBullet.inRange = true;
		}
	}
}

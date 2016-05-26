using UnityEngine;
using System.Collections;

public class ZoneScripts : MonoBehaviour {

	// Use this for initialization
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{

		}

	}
}

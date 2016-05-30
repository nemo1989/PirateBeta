using UnityEngine;
using System.Collections;

public class MirrorTwist : MonoBehaviour {
	public DarkWorld dWorld;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	if (Input.GetKey (KeyCode.M))
		{
			dWorld.DarkWorldActive();
		}
	}
}

﻿using UnityEngine;
using System.Collections;

public class RotateWalls : MonoBehaviour {
	public float speed = 10f;
	
	
	void Update ()
	{
		transform.Rotate(0,0, speed * Time.deltaTime);
	}
}

﻿using UnityEngine;
using System.Collections;

public class FollowPathBrainless : MonoBehaviour {
	public GameObject[] node;
	public GameController controller;
	
	int numberOfNodes;
	bool reachedArrayLenth =false;
	
	int i =0;
	// Use this for initialization
	void Start () {
		
		numberOfNodes = node.Length;
	}
	
	// Update is called once per frame
	void Update () {
		if(numberOfNodes >0)
		{
			
			if (!controller.win && !controller.gameOver)
			{
				transform.position = Vector3.MoveTowards(transform.position, node[i].transform.position, gameObject.GetComponent<Brainless>().speed * Time.deltaTime);
				if (transform.position == node[i].transform.position && !reachedArrayLenth)
				{
					Debug.Log("run bitch run");
					if (i < numberOfNodes - 1)
					{
						i++;
						
					}
					else
					{
						//reachedArrayLenth = true;
						i = 0;
					}
					
				}
			}
}
	}
}
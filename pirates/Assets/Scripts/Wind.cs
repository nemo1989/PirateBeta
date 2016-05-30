using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {
	public GameObject windMeshObject;
	public float delay;

	float time;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () 
	{

	
	}

	void OnTriggerStay2D(Collider2D col)
	{
	if (col.gameObject.tag == "Player")
		{

			time += Time.deltaTime;
			if(time>delay)
			{

			col.gameObject.GetComponent<Move>().windPushBack =true;

			}
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			
			time =0;
		}
	}

}

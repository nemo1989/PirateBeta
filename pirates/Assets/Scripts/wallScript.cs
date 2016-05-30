using UnityEngine;
using System.Collections;

public class wallScript : MonoBehaviour {

	public GameObject wall;
	// Use this for initialization
	void Start () {
		wall.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{	
		wall.SetActive (true);
	}
}

using UnityEngine;
using System.Collections;

public class HiddenBunniesCollision : MonoBehaviour {
	public GameObject objectBunny;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	 void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "rightHitBox") 
		{
			objectBunny.SetActive(true);
		}

	}
}

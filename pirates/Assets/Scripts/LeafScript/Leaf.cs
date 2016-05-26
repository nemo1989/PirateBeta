using UnityEngine;
using System.Collections;

public class Leaf : MonoBehaviour {
     float speed;
	// Use this for initialization
	void Start () 
    {
        speed = Random.Range(1, 3);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
     
	}
   
}

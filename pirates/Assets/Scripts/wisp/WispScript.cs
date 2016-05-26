using UnityEngine;
using System.Collections;

public class WispScript : MonoBehaviour {
    public float positonY;
    float time = 1;
    public float speed;
     
     bool hasReachedY;
	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        time += Time.fixedDeltaTime; 
        transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.fixedDeltaTime); 
        if(time >= 5 )
        {

            speed = -speed;
            time = 0;
        }
       
	}
}

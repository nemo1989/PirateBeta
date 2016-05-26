using UnityEngine;
using System.Collections;

public class collisionScript : MonoBehaviour {
	public CharacterStates states2;
	BoxCollider2D boxcollision;
    float delayBatCollision;
	// Use this for initialization
	void Start () 
	{
		boxcollision = GetComponent<BoxCollider2D> ();
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (states2.state == CharacterStates.playerStates.BAT) 
		{
            delayBatCollision += Time.fixedDeltaTime; 
            if (delayBatCollision > 0.4f)
            {
                boxcollision.enabled = true;
               
            }
		} 
		else 
		{
			boxcollision.enabled = false;
            delayBatCollision = 0;
		}
	
	}



	void OnTriggerEnter2D(Collider2D collide)
	{
		if (collide.gameObject.tag == "puzzleObj")
		{
			collide.gameObject.GetComponent<movigObjectScript> ().isHit = true;

		}

		if (collide.gameObject.tag == "Obst")
		{
			collide.gameObject.GetComponent<CannonBallScript> ().isHit = true;

		}
		}

}

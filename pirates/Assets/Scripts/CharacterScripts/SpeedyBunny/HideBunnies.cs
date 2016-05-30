using UnityEngine;
using System.Collections;

public class HideBunnies : MonoBehaviour {
    public bool ishiding;
   public SpriteRenderer render;
	// Use this for initialization
	void Start () 
    {
        ishiding = true;
       
	}
	
	// Update is called once per frame
	void Update () {
        hide();
	}
    void hide()
    {
        if (ishiding)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            
            if (collider.gameObject.GetComponent<CharacterStates>().state == CharacterStates.playerStates.DIGGING)
            {
                ishiding = false;
                Debug.Log("Player Has entered");
            }
        }
    
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (collider.gameObject.GetComponent<CharacterStates>().state == CharacterStates.playerStates.DIGGING)
            {
                ishiding = false;
            }
        }

    }
}

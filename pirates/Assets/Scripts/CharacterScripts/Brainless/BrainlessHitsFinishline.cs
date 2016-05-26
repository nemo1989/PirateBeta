using UnityEngine;
using System.Collections;

public class BrainlessHitsFinishline : MonoBehaviour {
    public GameController controller;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "Finishline")
        {
            controller.gameOver = true;
        }
    }
}

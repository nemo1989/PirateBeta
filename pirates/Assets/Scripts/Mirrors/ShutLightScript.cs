using UnityEngine;
using System.Collections;

public class ShutLightScript : MonoBehaviour {
    private GameObject controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindGameObjectWithTag("GameCon");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
    
    void OnTriggerEnter2D(Collider2D colide)
    {
       
        if (colide.gameObject.tag == "Mirror")
        {
            //Debug.Log("Light has Entered");
            colide.gameObject.GetComponent<MirrorScript>().showLight = false;
        }
        if (colide.gameObject.tag == "Player")
        {
            controller.gameObject.GetComponent<GameController>().isInLight = false;
        }
    }

   
}

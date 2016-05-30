using UnityEngine;
using System.Collections;

public class RayLightScript : MonoBehaviour {
     GameObject controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindGameObjectWithTag("GameCon");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D colide)
    {
        if (colide.gameObject.tag == "Player")
        {
            controller.gameObject.GetComponent<GameController>().isInLight = true;
        }
        if (colide.gameObject.tag == "Mirror")
        {
          //  Debug.Log("Light has Entered");
            colide.gameObject.GetComponent<MirrorScript>().showLight = true;
        }
    }
    void OnTriggerExit2D(Collider2D colide)
    {

        if (colide.gameObject.tag == "Player")
        {
            controller.gameObject.GetComponent<GameController>().isInLight = false;
        }
        if (colide.gameObject.tag == "Mirror")
        {
            colide.gameObject.GetComponent<MirrorScript>().showLight = false;
        }

    }
    void OnTriggerStay2D(Collider2D colide)
    {

        if (colide.gameObject.tag == "Player")
        {
            controller.gameObject.GetComponent<GameController>().isInLight = true;
        }
        if (colide.gameObject.tag == "Mirror")
        {
           // Debug.Log("RAYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY");
            colide.gameObject.GetComponent<MirrorScript>().showLight = true;
        }

    }
   
}

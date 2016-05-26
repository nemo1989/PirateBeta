using UnityEngine;
using System.Collections;

public class RayLightScript : MonoBehaviour {
    public GameController controller;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D colide)
    {
        if (colide.gameObject.tag == "Player")
        {
            controller.isInLight = true;
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
            controller.isInLight = false; 
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
            controller.isInLight = true;
        }
        if (colide.gameObject.tag == "Mirror")
        {
           // Debug.Log("RAYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY");
            colide.gameObject.GetComponent<MirrorScript>().showLight = true;
        }

    }
   
}

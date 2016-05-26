using UnityEngine;
using System.Collections;

public class ShutLightScript : MonoBehaviour {
    public GameController controller;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
    
    void OnTriggerEnter2D(Collider2D colide)
    {
       
        if (colide.gameObject.tag == "Mirror")
        {
            Debug.Log("Light has Entered");
            colide.gameObject.GetComponent<MirrorScript>().showLight = false;
        }
        if (colide.gameObject.tag == "Player")
        {
            controller.isInLight = false;
        }
    }

   
}

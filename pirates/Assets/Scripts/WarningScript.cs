using UnityEngine;
using System.Collections;

public class WarningScript : MonoBehaviour {
  
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            LeaveMeAlone.RickWarning = true;
           
        }
    }
	void OnTriggerStay2D(Collider2D col)
	{
		
		if (col.gameObject.tag == "Player")
		{
			LeaveMeAlone.RickWarning = true;
			
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		
		if (col.gameObject.tag == "Player")
		{
			LeaveMeAlone.RickWarning = false;
			
		}
	}
}

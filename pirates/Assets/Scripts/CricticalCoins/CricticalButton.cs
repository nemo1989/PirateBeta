using UnityEngine;
using System.Collections;

public class CricticalButton : MonoBehaviour {
  public  AreaCollision AC;
  
	// Use this for initialization
	void Start () {
        AC.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player")
        {
          
           
            AC.bunnyOrplayer = "Player";
            Debug.Log("CRITICAL AREA");
            AC.gameObject.SetActive(true);
        }

        if (collider.gameObject.tag == "Bunny")
        {
            AC.bunnyOrplayer = "Bunny";
            AC.gameObject.SetActive(true);
         
        }
    }
}

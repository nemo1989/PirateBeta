using UnityEngine;
using System.Collections;

public class LeafDestroyScript : MonoBehaviour {
  
	// Use this for initialization
	void Start () 
    {
      
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D colide)
    {
      
        if (colide.gameObject.tag == "leaf") 
        {
            Destroy(colide.gameObject);
        }
    }

}

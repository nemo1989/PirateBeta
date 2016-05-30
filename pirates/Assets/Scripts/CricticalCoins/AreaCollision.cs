using UnityEngine;
using System.Collections;

public class AreaCollision : MonoBehaviour {
    public string bunnyOrplayer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
    void OnTriggerEnter2D(Collider2D collider)
    { 
    if(collider.gameObject.tag == "Coin")
    {
       
        if (bunnyOrplayer == "Bunny")
        {
            CoinCollector.coinsum++;
            Destroy(collider.gameObject);
        }
        if (bunnyOrplayer == "Player")
        {
            CoinCollection.coinCount++;
            Destroy(collider.gameObject);
        }

    }
    }
}

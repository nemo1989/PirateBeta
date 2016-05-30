using UnityEngine;
using System.Collections;

public class LightDestroyer : MonoBehaviour {
    public GameObject[] ListOfDestruction;
    public static bool Checkpoint=false;
    //int j;
    bool AlreadyDestroyed = false;
    public Transform SpawnPoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player" && !AlreadyDestroyed)
        {
            //SpawnPoint.position = new Vector2(transform.position.x, transform.position.y);
          //  Checkpoint = true;

            foreach (GameObject j in ListOfDestruction)
            {
                Destroy(j);
                AlreadyDestroyed = true;

            }

        }
    }
}

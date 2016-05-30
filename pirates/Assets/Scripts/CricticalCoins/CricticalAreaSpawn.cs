using UnityEngine;
using System.Collections;

public class CricticalAreaSpawn : MonoBehaviour {
    public float SpawnTime;
    public float unspawnDuration;
    float timerForSpawn;
    float timerForunspawn;
   public bool hasSpawn;
   public GameObject[] spawnLocation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timerForSpawn += Time.deltaTime;
        if (timerForSpawn >= SpawnTime && !hasSpawn)
        {
            hasSpawn = true;

        }
        if (hasSpawn)
        {
            timerForunspawn += Time.deltaTime;
            if (timerForunspawn >= unspawnDuration)
            {
                hasSpawn = false;
                timerForunspawn = 0;
                timerForSpawn = 0;
            }
        }
	}

 
}
